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
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace xcControlPoint.Model.ListTypes
{
    public class Metadata
    {
        public string uri { get; set; }
        public string etag { get; set; }
        public string type { get; set; }
    }

    public class Deferred
    {
        public string uri { get; set; }
    }

    public class CreatedBy
    {
        public Deferred __deferred { get; set; }
    }

    public class Deferred2
    {
        public string uri { get; set; }
    }

    public class ModifiedBy
    {
        public Deferred2 __deferred { get; set; }
    }

    public class Deferred3
    {
        public string uri { get; set; }
    }

    public class Attachments
    {
        public Deferred3 __deferred { get; set; }
    }

    public class Deferred4
    {
        public string uri { get; set; }
    }

    public class Predecessors
    {
        public Deferred4 __deferred { get; set; }
    }

    public class Deferred5
    {
        public string uri { get; set; }
    }

    public class Priority
    {
        public Deferred5 __deferred { get; set; }
    }

    public class Deferred6
    {
        public string uri { get; set; }
    }

    public class Status
    {
        public Deferred6 __deferred { get; set; }
    }

    public class Deferred7
    {
        public string uri { get; set; }
    }

    public class AssignedTo
    {
        public Deferred7 __deferred { get; set; }
    }

    public class Deferred8
    {
        public string uri { get; set; }
    }

    public class TaskGroup
    {
        public Deferred8 __deferred { get; set; }
    }

    public class Result
    {
        public Metadata __metadata { get; set; }
        public int Id { get; set; }
        public string ContentTypeID { get; set; }
        public string ContentType { get; set; }
        public string Title { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public CreatedBy CreatedBy { get; set; }
        public int CreatedById { get; set; }
        public ModifiedBy ModifiedBy { get; set; }
        public int ModifiedById { get; set; }
        public int Owshiddenversion { get; set; }
        public string Version { get; set; }
        public Attachments Attachments { get; set; }
        public string Path { get; set; }
        public Predecessors Predecessors { get; set; }
        public Priority Priority { get; set; }
        public string PriorityValue { get; set; }
        public Status Status { get; set; }
        public string StatusValue { get; set; }
        public object Complete { get; set; }
        public AssignedTo AssignedTo { get; set; }
        public object AssignedToId { get; set; }
        public TaskGroup TaskGroup { get; set; }
        public object TaskGroupId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public object DueDate { get; set; }
        public double TotalSize { get; set; }
        public double TotalFiles { get; set; }
        public string Extension { get; set; }
    }

    public class D
    {
        public ObservableCollection<Result> results { get; set; }
    }

    public class xcrFileTypeStorageResult
    {
        public D d { get; set; }
    }
}
