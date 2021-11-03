using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program9
{
    class Employee
    {
        private string name;
        private string surname;
        private Task task;       
        public Task Task
        {
            get { return task; }          
        }

        public Employee(string name,string surname)
        {
            this.name = name;
            this.surname = surname;
        }
        public string PrintInfo()
        {
            return $"{name} {surname}";
        }
        public static void GiveTasks(List<Employee> workers,List<Task> tasks)
        {
            var tmp = new List<Task>();
            tmp.AddRange(tasks);
            for (int i = 0; i < workers.Count; i++)
            {
                for (int j= 0; j < tmp.Count; j++)
                {
                    if (workers[i].Task == null) 
                    {
                        Console.WriteLine("Задача:");
                        tmp[j].PrintInfo();
                        Console.WriteLine("Исполнитель:");
                        Console.WriteLine(workers[i].PrintInfo());
                        Console.WriteLine("Будет ли он брать задачу?(да/нет)");
                        string answer = Console.ReadLine().ToLower();
                        while (!answer.Equals("да") && !answer.Equals("нет"))
                        {
                            Console.WriteLine("Повторите ввод!");
                            answer = Console.ReadLine();
                        }
                        if (answer.Equals("да") || j == tmp.Count - 1)
                        {
                            workers[i].task = tmp[j];
                            Task.SwitchStatus(workers[i],tmp[j]);
                            tmp.Remove(tmp[j]);                          
                            Console.WriteLine("Работник получил задачу");
                        }
                        else
                        {
                            Console.WriteLine("Выбирайте другую задачу!");
                        }
                    }
                    

                }
            }
        }
    }
}
