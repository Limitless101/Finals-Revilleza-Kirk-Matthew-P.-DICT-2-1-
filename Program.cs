using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace final_exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EMPLOYEE TIME KEEPING ");
            Console.WriteLine("WELCOME!!! ");
            DateTime companyStartTime = new DateTime(2023, 2,28, 8, 0, 0); //Date that will input here should be the date today
            DateTime companyEndTime = new DateTime(2023, 2, 28, 17, 0, 0);//Date that will input here should be the date today
            TimeSpan gracePeriod = new TimeSpan(0, 30, 0);
            TimeSpan lunchBreak = new TimeSpan(1, 0, 0);
            TimeSpan totalLateHours = new TimeSpan(0, 0, 0);
            TimeSpan totalUndertimeHours = new TimeSpan(0, 0, 0);
            TimeSpan totalOvertimeHours = new TimeSpan(0, 0, 0);
            TimeSpan InitTime = new TimeSpan(0, 0, 0);
            TimeSpan totalRegularHours = new TimeSpan(0, 0, 0);
            TimeSpan totalWorkedHours = new TimeSpan(0, 0, 0);
            TimeSpan RegularHours = new TimeSpan(8, 0, 0);
            TimeSpan lateAmount = new TimeSpan(0, 0, 0);
            TimeSpan undertimeAmount = new TimeSpan(0, 0, 0);
            TimeSpan hoursWorked = new TimeSpan(0, 0, 0);

            Console.WriteLine("Input working days: ");
            int workingDays = Convert.ToInt32(Console.ReadLine());

            for (int a = 0; a < workingDays; a++)

            {
                Console.WriteLine("");
                Console.WriteLine("Please input Time-In:(Military Time) ");

                DateTime startTime = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Please Input Time-out:(Military Time) ");
                DateTime endTime = DateTime.Parse(Console.ReadLine());


                hoursWorked = endTime - startTime - lunchBreak;

                Console.WriteLine("Total Hours Worked today: " + hoursWorked);

                DateTime startTimeGracePeriod = companyStartTime + gracePeriod;
                DateTime overTimeGracePeriod = companyEndTime + gracePeriod;


                if (startTime > startTimeGracePeriod)
                {
                    lateAmount = startTime - companyStartTime;
                    Console.WriteLine("The Employee is Late");
                    Console.WriteLine("Late Hours: " + lateAmount);
                }

                if (endTime < companyEndTime)
                {
                    undertimeAmount = companyEndTime - endTime;
                    Console.WriteLine("The Employee is Undertime");
                    Console.WriteLine("Undertime Hours: " + undertimeAmount);
                }

                else if (endTime >= overTimeGracePeriod)
                {
                    TimeSpan overtimeAmount = endTime - companyEndTime;
                    Console.WriteLine("The Employee is Overtime");
                    Console.WriteLine("Overtime Hours: " + overtimeAmount);

                }

                if (lateAmount == InitTime && undertimeAmount == InitTime)
                {
                    totalRegularHours = totalRegularHours + RegularHours;
                }

                totalWorkedHours = hoursWorked + totalWorkedHours;
            }
            
                Console.WriteLine("");
                Console.WriteLine("Total Number of Hours Worked: " + totalWorkedHours);
                Console.WriteLine("Total Regular Hours Worked: " + totalRegularHours);

            

            Console.ReadLine();
        }
       
    
}
}


