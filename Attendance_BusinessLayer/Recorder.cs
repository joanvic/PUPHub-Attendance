using System;
using System.Collections.Generic;
using Attendance_DataLayer;
using Attendance_Models;

namespace Attendance_BusinessLayer
{
    public class AttendanceManager
    {
        public static void RecordAttendance()
        {
            Console.Write("Enter student name: ");
            string studentName = Console.ReadLine();

            StudentAttendanceRecord studentRecord = Students.StudentList.Find(record => record.StudentName == studentName);

            if (studentRecord == null)
            {
                Console.WriteLine("Invalid student name! Attendance not marked.");
                return;
            }

            Console.WriteLine("Select attendance status:");
            Console.WriteLine("1. Present");
            Console.WriteLine("2. Absent");
            Console.WriteLine("3. Excused");
            Console.Write("Enter your choice: ");
            string statusChoice = Console.ReadLine();

            string attendanceStatus;

            switch (statusChoice)
            {
                case "1":
                    attendanceStatus = "Present";
                    break;
                case "2":
                    attendanceStatus = "Absent";
                    break;
                case "3":
                    attendanceStatus = "Excused";
                    break;
                default:
                    Console.WriteLine("Invalid choice! Attendance not marked.");
                    return;
            }

            DateTime currentTime = DateTime.Now;

            studentRecord.StudentList.Add(new RecordDateTime(currentTime, attendanceStatus));
            Console.WriteLine("Attendance marked successfully.");
        }
        public static void ViewAttendanceRecordsByStudent()
        {
            Console.Write("Enter student name: ");
            string studentName = Console.ReadLine();

            StudentAttendanceRecord studentRecord = Students.StudentList.Find(record => record.StudentName == studentName);

            if (studentRecord == null)
            {
                Console.WriteLine("No attendance records found for this student.");
                return;
            }

            Console.WriteLine($"Attendance records for {studentName}:");
            foreach (var record in studentRecord.StudentList)
            {
                Console.WriteLine($"Date: {record.Time.ToShortDateString()}, Time: {record.Time.ToShortTimeString()}, Status: {record.Status}");
            }
        }
        public static void ViewAttendanceRecordsForAllStudents()
        {
            Console.WriteLine("Attendance records for all students:");

            if (Students.StudentList.Count == 0)
            {
                Console.WriteLine("No attendance records found for any student.");
                return;
            }

            foreach (var student in Students.StudentList)
            {
                Console.WriteLine($"Student: {student.StudentName}");
                foreach (var record in student.StudentList)
                {
                    Console.WriteLine($"Date: {record.Time.ToShortDateString()}, Time: {record.Time.ToShortTimeString()}, Status: {record.Status}");
                }
                Console.WriteLine();
            }
        }
    }
}

