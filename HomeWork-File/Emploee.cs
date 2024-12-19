using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_File
{
    
    internal class Employee
    {
        public string Name { get; set; }
        public int MaxTaskCount { get; set; }
        public bool IsTeamLead { get; set; }
        public List<Employee> Subordinates = new List<Employee>();
        public List<Task> tasks = new List<Task>();
        public List<Report> reportsFromSubordinates = new List<Report>();
        public Stack<Report> reportsRedcon = new Stack<Report>();
        public Employee(string name, int maxTaskCount, bool isTeamLead, List<Employee> subordinates)
        {
            Name = name;
            MaxTaskCount = maxTaskCount;
            IsTeamLead = isTeamLead;
            Subordinates = subordinates;
        }

        public Employee(string name, bool isTeamLead, List<Employee> subordinates = null)
        {
            Name = name;
            IsTeamLead = isTeamLead;
            Subordinates = subordinates;
        }

        private void TakeTask(Task task)
        {
            tasks.Add(task);
            task.Status = TaskStatus.IN_PROGRESS;
        }

        private void DelegateTask(Task task)
        {            
            List<Employee> freeSubordinates = new List<Employee>(); // фильтрованный список подчиненых (тех кто не привысил лимит по таскам)
            foreach (var subordinate in Subordinates)
            {
                if (subordinate.tasks.Count < subordinate.MaxTaskCount)
                {
                    freeSubordinates.Add(subordinate);
                }
            }
            if (freeSubordinates.Count != 0)
            {
                task.Initiator = this;
                task.Performer = freeSubordinates[freeSubordinates.Min(subordinate => subordinate.tasks.Count)];
                task.Performer.tasks.Add(task);
            }
            else if(!IsTeamLead)
            {
                TakeTask(task);
            }
            else
            {
                task.Status = TaskStatus.CLOSED;
            }

        }

        private void DeclineTask(Task task)
        {
            DelegateTask(task);
        }

        public void ProcessTask(Task task)
        {
            if (tasks.Count == MaxTaskCount)
            {
                DeclineTask(task);
            }
            else if (Subordinates.Count > 0)
            {
                DelegateTask(task);
            }
            else
            {
                TakeTask(task);
            }
        }

        public void CreateReport()
        {
            foreach (var task in tasks)
            {
                Console.Write("Введите год выполнения задания: ");
                int.TryParse(Console.ReadLine(), out int year);
                Console.Write("Введите месяц выполнения задания: ");
                int.TryParse(Console.ReadLine(), out int month);
                Console.Write("Введите день выполнения задания: ");
                int.TryParse(Console.ReadLine(), out int day);
                if (year > 3000 || year < 1000)
                {
                    year = 2026;
                }
                if (month > 12 || month <= 0)
                {
                    month = 6;
                }
                if (day <= 0 || day > 30)
                { 
                    day = 20;
                }
                Console.WriteLine("Описание выполненой работы работы: ");
                task.Initiator.reportsFromSubordinates.Add(new Report(Console.ReadLine()!, new DateTime(year, month, day), this));
                task.Status = TaskStatus.UNDER_REVIEW;
            }

        }
        public void SendReportToRedcon() {
            reportsFromSubordinates[3].Performer.reportsRedcon.Push(reportsFromSubordinates[3]);
        }
        public void SubmitTask()
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (!reportsFromSubordinates[i].Performer.reportsRedcon.Contains(reportsFromSubordinates[i]))
                {
                    reportsFromSubordinates[i].Performer.tasks[i].Status = TaskStatus.CLOSED;
                }
            }
        }
    }
}
