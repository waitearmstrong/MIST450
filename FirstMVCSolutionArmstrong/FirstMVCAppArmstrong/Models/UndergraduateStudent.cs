using System;

namespace FirstMVCAppArmstrong.Models
{
    public class UndergraduateStudent : Student
    {
        public bool isInState;
        private const double baseTuition = 8000;
        private const double outOfStateMultiplier = 3.0;


        public UndergraduateStudent(int StudentID, string StudentName, double StudentGPA, bool isInState) : base()
        {
            this.StudentID = StudentID;
            this.StudentName = StudentName;
            this.StudentGPA = StudentGPA;
            this.isInState = isInState;
        }

        public override void calculateTuition()
        {
            base.calculateTuition();

            if (isInState)
                this.Tuition = baseTuition;
            else
            {
                this.Tuition = baseTuition * outOfStateMultiplier;
            }
        }
    }
} // make undergrad and grad students