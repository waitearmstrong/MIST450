using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCAppArmstrong.Models
{
    public class GraduateStudent : Student
    {
        private const double baseGradTuition = 20000;
        public Double GraduateAssistantship { get; set; }
        public GraduateStudent(int StudentID, string StudentName, double StudentGPA, Double graduateAssistantship) : base()
        {
            this.StudentID = StudentID;
            this.StudentName = StudentName;
            this.StudentGPA = StudentGPA;
            this.GraduateAssistantship = graduateAssistantship;
        }

        public GraduateStudent()
        {

        }

        public override void calculateTuition()
        {
            base.calculateTuition();
            if (GraduateAssistantship > baseGradTuition)
                this.Tuition = 0;
            else
                this.Tuition = baseGradTuition - GraduateAssistantship;

        }
    }
}
