using System;
using System.Collections.Generic;
using Attendance_BusinessLayer;
using Attendance_DataLayer;
using Attendance_UserInterface;

namespace Attendance
{
    internal class MainProgram
    {
        static void Main(string[] args)
        {
            UserInterfaceMenu.DisplayMainTitle();
            //Console.WriteLine("Attendance is a Must, attendance muna bago umalis mga ya.");
            //Console.WriteLine("-------------------------------------------");

            Students.InMemoryDataStudents();

            while (true)
            {
                UserInterfaceMenu.DisplayMainMenu();
                //Console.WriteLine("\nPlease select an option:");
                //Console.WriteLine("1. Record attendance");
                //Console.WriteLine("2. View attendance records by student");
                //Console.WriteLine("3. View attendance records for all students");
                //Console.WriteLine("4. Edit attendance records");
                //Console.WriteLine("5. Exit");
                //Console.Write("Enter your choice: ");

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        AttendanceManager.RecordAttendance();
                        break;
                    case "2":
                        AttendanceManager.ViewAttendanceRecordsByStudent();
                        break;
                    case "3":
                        AttendanceManager.ViewAttendanceRecordsForAllStudents();
                        break;
                    case "4":
                        AttendanceManager.EditAttendance();
                        break;
                    case "5":
                        UserInterfaceMenu.DisplayExitMessage();
                        return;
                    default:
                        UserInterfaceMenu.DisplayInvalidChoiceMessage();
                        break;
                }
            }
        }
    }
}
