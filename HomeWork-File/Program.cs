using System;

namespace HomeWork_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee Anna = new Employee("Аня", 2, false, []);
            Employee Petr = new Employee("Petr", 1, false, []);
            Employee Lena = new Employee("Лена", 2, false, []);
            Employee Tom = new Employee("Том", 2, false, []);
            Employee Sergey = new Employee("Сергей", 2, false, []);
            Employee Ivan = new Employee("Иван", 2, false, []);
            Employee Vita = new Employee("Витя", 1, false, [Ivan, Sergey, Tom]);
            Employee Oleg = new Employee("Олег", 1, false, [Anna, Lena]);
            Employee Olga = new Employee("Ольга", 1, false, [Vita, Oleg]);
            Employee Anton = new Employee("Антон", 1, false, [Olga]);
            Employee Bob = new Employee("Боб", true, [Vita, Oleg, Olga, Anton, Anna, Lena, Tom, Sergey, Ivan]);

            Console.WriteLine("Введите число заданий в проекте: ");
            int.TryParse(Console.ReadLine(), out int taskCount);

            Console.Write("Введите год дедлайна проекта: ");
            int.TryParse(Console.ReadLine(), out int year);
            Console.Write("Введите месяц дедлайна проекта: ");
            int.TryParse(Console.ReadLine(), out int month);
            Console.Write("Введите день дедлайна проекта: ");
            int.TryParse(Console.ReadLine(), out int day);

            Console.WriteLine("Описание проекта: ");
            Project project1 = new Project(Console.ReadLine()!, new DateTime(year, month, day), "ООО Агроторг", Bob);
            

            if (project1.Status == ProjectStatus.PROJECT)
            {
                for (int i = 0; i < taskCount; i++)
                {
                    Console.WriteLine("Описание задачи: ");
                    project1.TasksList.Enqueue(new Task(Console.ReadLine()!, new DateTime(year, month-2, day-5), Bob, Bob.Subordinates[i]));

                }
                project1.Status = ProjectStatus.EXECUTION;
            }

            for (int i = 0; i < Bob.Subordinates.Count; i++)
            {
                Bob.Subordinates[i].CreateReport();
            }

            Console.ReadKey();
        }
    }
}
