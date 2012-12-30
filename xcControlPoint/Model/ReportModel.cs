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
using System.Collections;
using xcControlPoint.Model.ListTypes;
using Newtonsoft.Json;
using System.IO;

namespace xcControlPoint.Model
{
    public static class Operations
    {
        public static string xcrStorageByFileType = "XCRSTORAGEBYFILETYPE";
        public static string xcrSiteActivityAnalysis = "XCRSITEACTIVITYANALYSIS";
        public static string xcrSitesMostActive = "XCRSITESMOSTACTIVE";
        public static string xcrPagesMostActive = "XCRPAGESMOSTACTIVE";
        public static string xcrDocumentsMostActive = "XCRDOCUMENTSMOSTACTIVE";
    }
   
    public class ReportModel
    {

        static xcrFileTypeStorageResult cList;

        public static void ReportData(string rptType)
        {
            string url = GetRESTUrl(rptType);

            System.Net.HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.CookieContainer = App.CookieJar;
            request.Accept = @"application/json";

            request.Method = "GET";
            request.BeginGetResponse(new AsyncCallback(ListCallBack), request);
        }

        private static void ListCallBack(IAsyncResult asyncResult)
        {
            HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;

            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asyncResult);
            using (Stream content = response.GetResponseStream())
            {
                if (request != null && response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    using (StreamReader reader = new StreamReader(content))
                    {
                        string responseString = reader.ReadToEnd();

                        cList = JsonConvert.DeserializeObject<xcrFileTypeStorageResult>(responseString);

                        //Dispatcher.BeginInvoke(() =>
                        //{
                            //chart.Series[0].ItemsSource = cList.d.results;
                        //});

                    }
                }
            }
        }

        static string GetRESTUrl(string rptType)
        {
            string baseRelURL = "/_vti_bin/ListData.svc/";
            
            if (rptType == Operations.xcrStorageByFileType)
                return baseRelURL + "XcrFileTypeStorageReport_m_Storage_VirtualServersDS";

            return null;
        }
    }
}
