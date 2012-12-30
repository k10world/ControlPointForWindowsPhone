using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Text;
using System.IO;

namespace xcControlPoint.Auth
{
    public class Authorization
    {
        public event EventHandler<AuthenticatedEventArgs> OnAuthenticated;

        private CookieContainer cookieJar = new CookieContainer();

        public string UserName { get; private set; }
        public string UserPassword { get; private set; }
        public string ControlPointSiteUrl { get; private set; }
        private string AuthenticationServiceURL { get; set; }

        public Authorization(string UserName, string UserPassword, string ControlPointSiteUrl)
        {
            this.UserName = UserName;
            this.UserPassword = UserPassword;
            this.ControlPointSiteUrl = ControlPointSiteUrl;
            this.AuthenticationServiceURL = ControlPointSiteUrl.TrimEnd('/') + "/_vti_bin/authentication.asmx";
        }

        public void Authenticate()
        {
            System.Uri authServiceUri = new Uri(AuthenticationServiceURL);
            HttpWebRequest spAuthReq = HttpWebRequest.Create(authServiceUri) as HttpWebRequest;
            spAuthReq.CookieContainer = cookieJar;
            spAuthReq.Headers["SOAPAction"] = "http://schemas.microsoft.com/sharepoint/soap/Login";
            spAuthReq.ContentType = "text/xml; charset=utf-8";
            spAuthReq.Method = "POST";

            spAuthReq.BeginGetRequestStream(new AsyncCallback(spAuthReqCallBack), spAuthReq);

        }

        private void spAuthReqCallBack(IAsyncResult asyncResult)
        {
            string envelope =
                    @"<?xml version=""1.0"" encoding=""utf-8""?>
                    <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                      <soap:Body>
                        <Login xmlns=""http://schemas.microsoft.com/sharepoint/soap/"">
                          <username>{0}</username>
                          <password>{1}</password>
                        </Login>
                      </soap:Body>
                    </soap:Envelope>";

            UTF8Encoding encoding = new UTF8Encoding();
            HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;
            using (Stream _body = request.EndGetRequestStream(asyncResult))
            {
                envelope = string.Format(envelope, UserName, UserPassword);
                byte[] formBytes = encoding.GetBytes(envelope);

                _body.Write(formBytes, 0, formBytes.Length);
                _body.Close();
            }
            request.BeginGetResponse(new AsyncCallback(ResponseCallback), request);
        }

        private void ResponseCallback(IAsyncResult asyncResult)
        {
            HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asyncResult);
            using (Stream content = response.GetResponseStream())
            {
                if (request != null && response != null)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (StreamReader reader = new StreamReader(content))
                        {
                            string _responseString = reader.ReadToEnd();
                            reader.Close();
                        }
                    }
                }
            }


            //authentication complete
            //This demo does not handle failed authentication attempts
            // this implemention of the event avoids race conditions in threaded apps...
            EventHandler<AuthenticatedEventArgs> authenticated = OnAuthenticated;

            if (authenticated != null)
            {
                authenticated(this, new AuthenticatedEventArgs(cookieJar));
            }
        }
    }


    public class AuthenticatedEventArgs : EventArgs
    {
        public CookieContainer CookieJar { get; private set; }

        public AuthenticatedEventArgs(CookieContainer c)
        {
            CookieJar = c;
        }
    }

}
