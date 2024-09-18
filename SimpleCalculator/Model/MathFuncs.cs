using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator.Model
{
    public class MathFuncs
    {
        public static double Addition(double firstNum, double secondNum)
        {
            return firstNum + secondNum;
        }

        public static double Subtract(double firstNum, double secondNum)
        {
            return firstNum - secondNum;
        }

        public static double Multiply(double firstNum, double secondNum)
        {
            return firstNum * secondNum;
        }

        public static double Divide(double firstNum, double secondNum)
        {
            return firstNum / secondNum;
        }
    }
}