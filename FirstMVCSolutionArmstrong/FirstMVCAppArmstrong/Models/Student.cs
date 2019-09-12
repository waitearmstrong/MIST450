using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCAppArmstrong.Models
{
    public class Student
    {
        private Major major;
        public int StudentID { get; set; }
        public String StudentName { get; set; }
        public double StudentGPA { get; set; }

        public Student(int studentID)
        {
            this.StudentID = studentID;
        }

        public Student(int StudentID, string StudentName, double StudentGPA)
        {
            this.StudentID = StudentID; 
            this.StudentName = StudentName;
            this.StudentGPA = StudentGPA;
          //  this.major = new Major();
        }
        //accepts 3 parameters of the student type

        public static Student findStudentWithHighestGPA(Student first,Student second,Student third)
        {
            if (first.StudentGPA > second.StudentGPA && first.StudentGPA > third.StudentGPA)
                return first;
            else if (first.StudentGPA < second.StudentGPA && second.StudentGPA > third.StudentGPA)
                return second;
            else
                return third;
        }
    }
}
