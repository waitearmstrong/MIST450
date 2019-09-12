using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCAppArmstrong.Models
{
    public class Calculator
    {
        //create a method to find the largest of three integer numbers
        public int FindLargestNumber(int one, int two, int three)
        {
            if (one > two && one > three)
                return one;
            else if (one < two && two > three)
                return two;
            else
                return three;
        }

        //Convert to 
        
    }//end class
}//end namespace
