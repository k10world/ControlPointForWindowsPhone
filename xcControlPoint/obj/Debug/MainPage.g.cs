﻿#pragma checksum "C:\Users\kthakkar\Documents\Visual Studio 2010\Projects\xcControlPoint\xcControlPoint\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "56F4EA3E9159A82FDE856CC2FB2CFDAE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;
using Telerik.Windows.Controls;


namespace xcControlPoint {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Image AxcelerLogo;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock tbControlPointSite;
        
        internal Telerik.Windows.Controls.RadTextBox txtControlPointURL;
        
        internal System.Windows.Controls.TextBlock tbUserName;
        
        internal Telerik.Windows.Controls.RadTextBox txtUserName;
        
        internal System.Windows.Controls.TextBlock tbPassword;
        
        internal System.Windows.Controls.PasswordBox passPassword;
        
        internal System.Windows.Controls.TextBlock tbResult;
        
        internal System.Windows.Controls.Button btnGo;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/xcControlPoint;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.AxcelerLogo = ((System.Windows.Controls.Image)(this.FindName("AxcelerLogo")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.tbControlPointSite = ((System.Windows.Controls.TextBlock)(this.FindName("tbControlPointSite")));
            this.txtControlPointURL = ((Telerik.Windows.Controls.RadTextBox)(this.FindName("txtControlPointURL")));
            this.tbUserName = ((System.Windows.Controls.TextBlock)(this.FindName("tbUserName")));
            this.txtUserName = ((Telerik.Windows.Controls.RadTextBox)(this.FindName("txtUserName")));
            this.tbPassword = ((System.Windows.Controls.TextBlock)(this.FindName("tbPassword")));
            this.passPassword = ((System.Windows.Controls.PasswordBox)(this.FindName("passPassword")));
            this.tbResult = ((System.Windows.Controls.TextBlock)(this.FindName("tbResult")));
            this.btnGo = ((System.Windows.Controls.Button)(this.FindName("btnGo")));
        }
    }
}

