using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program9
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("КФУ");
            DateTime deadline = DateTime.Now.AddDays(7);

            Employer employer = new Employer("Екатерина", "Фадеева");
            int countOfEmployees = 10;
            Project project = new Project("Обучить студентов программированию", deadline, employer, customer);
            
            List<Employee> employees = new List<Employee>(countOfEmployees);           
            ///
            employees.Add(new Employee("Анна", "Шипило"));
            employees.Add(new Employee("Мария", "Арещенко"));
            employees.Add(new Employee("Марьям", "Ахметсафина"));
            employees.Add(new Employee("Алиса", "Балаболина"));
            employees.Add(new Employee("Леонид", "Визель"));
            employees.Add(new Employee("Алмаз", "Зеастинов"));
            employees.Add(new Employee("Елена", "Конышева"));
            employees.Add(new Employee("Ришат", "Каримов"));
            employees.Add(new Employee("Диана", "Захарова"));         
            employees.Add(new Employee("Илья", "Игуменов"));
            ///

            List<Task> tasks = new List<Task>(countOfEmployees);
            ///
            tasks.Add(new Task("Решить лабу 1",employer));
            tasks.Add(new Task("Решить лабу 2", employer));
            tasks.Add(new Task("Решить лабу 3", employer));
            tasks.Add(new Task("Решить лабу 4", employer));
            tasks.Add(new Task("Решить лабу 5", employer));
            tasks.Add(new Task("Решить лабу 6", employer));
            tasks.Add(new Task("Решить лабу 7", employer));
            tasks.Add(new Task("Решить лабу 8", employer));
            tasks.Add(new Task("Решить лабу 9", employer));
            tasks.Add(new Task("Взломать Pentagon", employer));
            ///

            project.AddTasksInProject(tasks);
            Employee.GiveTasks(employees, tasks);
            Console.ReadKey();
            Console.Clear();

            while (employees.Count > 0)
            {
                Console.WriteLine("Чтобы сдать отчет работника выберите цифру, стоящую рядом с работником");
                Console.WriteLine("Работники:");
                for (int i = 0; i < employees.Count; i++)
                {
                    Console.WriteLine($"{i+1} {employees[i].PrintInfo()}");
                }
                int index;
                while (!int.TryParse(Console.ReadLine(),out index)|| index<1 || index > employees.Count)
                {
                    Console.WriteLine("Неверный ввод!");
                }
                Report onCheck=Report.CreateNewReport(employees[index - 1]);
                Console.WriteLine($"Инициатор к тебе вопрос!Нравится ли тебе отчет работника {employees[index-1].PrintInfo()}?да/нет");
                Console.WriteLine("Его отчет:");
                onCheck.PrintInfoReport();
                string answer = Console.ReadLine();
                while (!answer.Equals("да") && !answer.Equals("нет"))
                {
                    Console.WriteLine("Повторите ввод!");
                    answer = Console.ReadLine();
                }
                if (answer.Equals("да") )
                {
                    Task.CloseTask(employees[index-1]);
                    employees.Remove(employees[index-1]);
                    onCheck = null;
                }
                else
                {
                    Console.WriteLine("Отчет не завершен!Доработайте!");
                    onCheck = null;
                }
            }
            project.CloseProject();


            








        }
    }
}
