using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program9
{
    public enum StatusOfProject
    {
        Project,
        InProcess,
        Closed
    }
    class Project
    {
        private string description;
        private DateTime time;
        private Employer employer;
        private Customer customer;
        List<Task> tasksOfProject;
        private StatusOfProject status;
        public Project(string description,DateTime deadline,Employer employer,Customer customer)
        {
            this.description = description;
            time = deadline;
            this.employer = employer;
            this.customer = customer;
            status = StatusOfProject.Project;

        }
        public void AddTasksInProject(List<Task>tasks)
        {
            if (tasks != null && tasksOfProject==null)
            {
                tasksOfProject = tasks;
                status = StatusOfProject.InProcess;
            }
        }
        public void CloseProject()
        {
            if (status == StatusOfProject.InProcess)
            {
                status = StatusOfProject.Closed;
                if (time < DateTime.Now)
                {
                    Console.WriteLine("Проект закрыт не вовремя!");
                }
                else
                {
                    Console.WriteLine("Вам удалось уложиться в дедлайн!");
                }
            }
        }
        

    }
}
