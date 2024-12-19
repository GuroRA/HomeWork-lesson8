using System;
using System.Collections.Generic;


namespace HomeWork_File
{
    enum ProjectStatus
    {
        PROJECT,
        EXECUTION,
        CLOSED
    }

    class Project
    {
        public string Discription {  get; set; }
        public DateTime Deadline { get; set; }
        public string СustomerName { get; set; }
        public Employee TeamLead { get; set; }
        public ProjectStatus Status = ProjectStatus.PROJECT;
        public Queue<Task> TasksList = new Queue<Task>();
        public Project(string discription, DateTime deadline, string customerName, Employee teamLead)
        {
            Discription = discription;
            Deadline = deadline;
            СustomerName = customerName;
            TeamLead = teamLead;
        }
    }
}
