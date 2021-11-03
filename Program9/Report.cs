using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program9
{
    class Report
    {
        private string text;
        private DateTime time;
        private Employee worker;

        public Report(Employee worker,string text)
        {
            this.worker = worker;
            this.text = text;
        }
        public static Report CreateNewReport(Employee worker)
        {
            Console.WriteLine("Введите описание отчета");
            string text = Console.ReadLine();
            Task.SendOnCheck(worker);
            return new Report(worker,text);
        }
        public void PrintInfoReport()
        {
            Console.WriteLine($"{text}");           
        }

    }
}
