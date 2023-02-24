using System;

class EmployeeTimeKeeping {
static void Main(string[] args) {
DateTime startTime = new DateTime(2023, 2, 21, 8, 0, 0);
DateTime endTime = new DateTime(2023, 2, 21, 17, 0, 0);
TimeSpan gracePeriod = new TimeSpan(0, 30, 0);

    Console.Write("Enter employee time-in: ");
    DateTime timeIn = DateTime.Parse(Console.ReadLine());
    Console.Write("Enter employee time-out: ");
    DateTime timeOut = DateTime.Parse(Console.ReadLine());
    Console.Write("Enter employee hourly rate: ");
    double hourlyRate = double.Parse(Console.ReadLine());

    TimeSpan hoursWorked = timeOut - timeIn;
    DateTime regularStartTime = startTime.Add(gracePeriod);
    DateTime regularEndTime = endTime.Subtract(gracePeriod);
    TimeSpan regularHours = new TimeSpan();
    if (timeIn < regularStartTime) {
        regularHours = regularHours.Add(regularStartTime - timeIn);
    }
    if (timeOut > regularEndTime) {
        regularHours = regularHours.Add(timeOut - regularEndTime);
    }
    regularHours = regularHours.Add(regularEndTime - regularStartTime);

    Console.Write("Enter employee lunch break time-out: ");
    DateTime lunchBreakTimeOut = DateTime.Parse(Console.ReadLine());
    Console.Write("Enter employee lunch break time-in: ");
    DateTime lunchBreakTimeIn = DateTime.Parse(Console.ReadLine());
    TimeSpan lunchBreakHours = new TimeSpan();
    if (timeIn < lunchBreakTimeOut && timeOut > lunchBreakTimeIn) {
        lunchBreakHours = lunchBreakTimeIn - lunchBreakTimeOut;
    }

    TimeSpan lateTime = new TimeSpan();
    if (timeIn > regularStartTime) {
        lateTime = timeIn - regularStartTime;
    }
    TimeSpan undertime = new TimeSpan();
    if (timeOut < regularEndTime) {
        undertime = regularEndTime - timeOut;
    }
    TimeSpan overtime = new TimeSpan();
    if (timeOut > endTime) {
        overtime = timeOut - endTime;
    }

    
    double regularPay = regularHours.TotalHours * hourlyRate;
    double overtimePay = overtime.TotalHours * hourlyRate * 1.5;
    double totalPay = regularPay + overtimePay;

    
    Console.WriteLine("Hours worked: " + hoursWorked.TotalHours);
    Console.WriteLine("Regular hours worked: " + regularHours.TotalHours);
    Console.WriteLine("Lunch break hours: " + lunchBreakHours.TotalHours);
    Console.WriteLine("Late time: " + lateTime.TotalMinutes + " minutes");
    Console.WriteLine("Undertime: " + undertime.TotalMinutes + " minutes");
    Console.WriteLine("Overtime: " + overtime.TotalHours + " hours");
    Console.WriteLine("Regular pay: $" + regularPay);
    Console.WriteLine("Overtime pay: $" + overtimePay);
    Console.WriteLine("Total pay: $" + totalPay);

    Console.ReadLine();
}
}
