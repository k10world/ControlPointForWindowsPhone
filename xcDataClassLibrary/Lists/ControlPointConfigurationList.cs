using System;
using System.Net;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Linq;
using System.Data;
using System.Data.Services.Client;
using System.Collections.Generic;
using System.Windows;


namespace xcDataClassLibrary.Lists
{
    public class ControlPointConfigurationListItem
    {
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
        public string Description { get; set;}
        public string Notes { get; set; }

        public ControlPointConfigurationListItem(string parameterName, string parameterValue, string description, string notes)
        {
            ParameterName = parameterName;
            ParameterValue = parameterValue;
            Description = description;
            Notes = notes;
        }
    }

    public class ControlPointConfigurationList
    {
    }
}
