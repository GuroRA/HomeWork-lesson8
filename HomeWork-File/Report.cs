using System;


namespace HomeWork_File
{
    internal class Report
    {
        public string Title { get; set; }
        public DateTime TaskEndDate { get; set; }
        public Employee Performer { get; private set; }
        public Report( string title, DateTime taskEndDate, Employee performer) 
        { 
            Title = title;
            TaskEndDate = taskEndDate;
            Performer = performer;
        }
    }
}
