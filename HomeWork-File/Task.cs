using System;

namespace HomeWork_File
{
    enum TaskStatus
    {
        ASSIGNED,
        IN_PROGRESS,
        UNDER_REVIEW,
        CLOSED
    }
    internal class Task
    {
        public string Discription { get; set; }
        public DateTime Deadline { get; set; }
        public Employee Initiator { get; set; }
        public Employee Performer { get; set; }

        public TaskStatus Status = TaskStatus.ASSIGNED;

        public Task(string discription, DateTime dateTime, Employee initator, Employee performer)
        {
            Discription = discription;
            DateTime deadline = dateTime;
            Initiator = initator;
            Performer = performer;
            Performer.ProcessTask(this);
        }

    }
}
