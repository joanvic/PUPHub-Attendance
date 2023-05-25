using System;
using System.Collections.Generic;
using Attendance_Models;

namespace Attendance_DataLayer
{
    public class Students
    {
        public static List<StudentAttendanceRecord> StudentList = new List<StudentAttendanceRecord>();
        public static void InMemoryDataStudents()
        {
            StudentList.Add(new StudentAttendanceRecord("Nico Ampoloquio"));
            StudentList.Add(new StudentAttendanceRecord("Joanvic Vargas"));
            StudentList.Add(new StudentAttendanceRecord("Mekaila Aguila"));
        }
    }
}
