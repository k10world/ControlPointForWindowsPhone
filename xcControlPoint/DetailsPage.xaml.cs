using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Telerik.Windows.Controls.Chart;
using System.IO;
using Newtonsoft.Json;
using xcControlPoint.Auth;
using xcControlPoint.Model.ListTypes;
using System.Collections.ObjectModel;
using xcControlPoint.Model;
using Telerik.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace xcControlPoint
{
    public partial class DetailsPage : PhoneApplicationPage
    {        
        string rptOperation;
        xcrFileTypeStorageResult cList;
        ObservableCollection<Result> chartData;

        private CartesianSeries barSeries;
        private LineSeries lineSeries;
        private PieSeries pieSeries;
        private ChartSeries[] seriesArray;
        private int seriesIndex = 0;
        private int dataIndex;

        // Constructor
        public DetailsPage()
        {
            InitializeComponent();
            this.barSeries = this.CartesianChart.Series[0] as BarSeries;
            this.lineSeries = this.CartesianChart.Series[1] as LineSeries;
            this.pieSeries = this.PieChart.Series[0];



            this.DataContext = this;
            this.seriesArray = new ChartSeries[] { this.barSeries, this.lineSeries, this.pieSeries };

            Dictionary<int, string> operationMap = new Dictionary<int, string>();
            operationMap.Add(0, Operations.xcrStorageByFileType);

            ReportData(Operations.xcrStorageByFileType);
        }


        public void ReportData(string rptType)
        {
            string url = "http://ketansp2010:3434/_vti_bin/ListData.svc/XcrFileTypeStorageReport_m_Storage_VirtualServersDS()?$orderby=TotalSize&$select=Extension,TotalSize,TotalFiles";
                //CredentialsAndURL.LIST_WEB_URL +  GetRESTUrl(rptType);

            System.Net.HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.CookieContainer = App.CookieJar;
            request.Accept = @"application/json";

            request.Method = "GET";
            request.BeginGetResponse(new AsyncCallback(ListCallBack), request);
        }

        private void ListCallBack(IAsyncResult asyncResult)
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

                        Dispatcher.BeginInvoke(() =>
                        {
                            chartData = cList.d.results;
                            SetSeries(cList.d.results);
                        });
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

        private void Bar_Click(object sender, RoutedEventArgs e)
        {
            this.seriesIndex = 0;
            ToggleDataButtons(sender as ToggleButton);
            SetSeries(null);
        }

        private void Line_Click(object sender, RoutedEventArgs e)
        {
            this.seriesIndex = 1;
            ToggleDataButtons(sender as ToggleButton);
            SetSeries(null);
        }

        private void Pie_Click(object sender, RoutedEventArgs e)
        {
            this.seriesIndex = 2;
            ToggleDataButtons(sender as ToggleButton);
            SetSeries(null);
        }


        private void SetSeries(ObservableCollection<Result> data)
        {
            this.CartesianChart.Series.Clear();

            PieSeries pSeries = this.seriesArray[this.seriesIndex] as PieSeries;

            CartesianSeries cartesianSeries = this.seriesArray[this.seriesIndex] as CartesianSeries;

           
            if (cartesianSeries != null)
            {                
                // hide the series
                //currentSeries.Opacity = 0;
                cartesianSeries.ItemsSource = chartData;                                

                CartesianChart.Visibility = System.Windows.Visibility.Visible;
                PieChart.Visibility = System.Windows.Visibility.Collapsed;

                this.CartesianChart.Series.Add(cartesianSeries);

                // use the dispatcher to allow the series to update its visuals (chart invalidation is done asynchronously)
                this.Dispatcher.BeginInvoke(() =>
                {
                    cartesianSeries.Opacity = 1;
                });
            }

            if (pSeries != null)
            {                
                pSeries.ItemsSource = chartData;
                // hide the series
                pSeries.Opacity = 0;

                CartesianChart.Visibility = System.Windows.Visibility.Collapsed;
                PieChart.Visibility = System.Windows.Visibility.Visible;


                // use the dispatcher to allow the series to update its visuals (chart invalidation is done asynchronously)
                this.Dispatcher.BeginInvoke(() =>
                {
                    pSeries.Opacity = 1;
                });
            }
        }


        private void ToggleDataButtons(ToggleButton toCheck)
        {
            foreach (ToggleButton button in this.dataButtonHolder.Children)
            {
                button.IsChecked = false;
            }

            toCheck.IsChecked = true;
        }

        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            // Switch the placement of the buttons based on an orientation change.

            if ((e.Orientation & PageOrientation.Portrait) == (PageOrientation.Portrait))
            {
                //Grid.SetRow(buttonList, 1);
                //Grid.SetColumn(buttonList, 0);
                dataButtonHolder.Visibility = System.Windows.Visibility.Visible;
                tbChartType.Visibility = System.Windows.Visibility.Visible;
            }

            // If not in the portrait mode, move buttonList content to a visible row and column.

            else
            {
                dataButtonHolder.Visibility = System.Windows.Visibility.Collapsed;
                tbChartType.Visibility = System.Windows.Visibility.Collapsed;
                //Grid.SetRow(buttonList, 0);
                //Grid.SetColumn(buttonList, 1);
            }
        }
    }    
}
