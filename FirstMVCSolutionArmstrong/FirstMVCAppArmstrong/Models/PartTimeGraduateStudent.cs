using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCAppArmstrong.Models
{
    public class PartTimeGraduateStudent : GraduateStudent
    {
        private const double tuitionPerCreadit = 1500;
        public Double GraduateAssistantship { get; set; }
        public Double CreditHours { get; set; }
        public PartTimeGraduateStudent(int StudentID, string StudentName, double StudentGPA, Double graduateAssistantship, double creditHours) : base()
        {
            this.StudentID = StudentID;
            this.StudentName = StudentName;
            this.StudentGPA = StudentGPA;
            this.GraduateAssistantship = graduateAssistantship;
            this.CreditHours = creditHours;
        }

        public override void calculateTuition()
        {
            base.calculateTuition();
            this.Tuition = tuitionPerCreadit * this.CreditHours;
            if (GraduateAssistantship > this.Tuition)
                this.Tuition = 0;
            else
                this.Tuition = this.Tuition - GraduateAssistantship;

        }
    }
}