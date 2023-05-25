using System;
using Attendance_DataLayer;
using Attendance_Models;

namespace Attendance_UserInterface
{
    public class UserInterface
    {
        public static void RecordAttendance()
        {
            ConsoleUI ui = new ConsoleUI();
            string studentName = ui.GetUserInput("Enter student name: ");

            StudentAttendanceRecord studentRecord = Students.StudentList.Find(record => record.StudentName == studentName);

            if (studentRecord == null)
            {
                ui.DisplayMessage("Invalid student name! Attendance not marked.");
                return;
            }

            string statusChoice = ui.GetChoiceFromUser("Select attendance status:\n1. Present\n2. Absent\n3. Excused\nEnter your choice: ");

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
                    ui.DisplayMessage("Invalid choice! Attendance not marked.");
                    return;
            }

            DateTime currentTime = DateTime.Now;

            studentRecord.StudentList.Add(new RecordDateTime(currentTime, attendanceStatus));
            ui.DisplayMessage("Attendance marked successfully.");
        }
    }
    public class ConsoleUI
    {
        public string GetUserInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string GetChoiceFromUser(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
