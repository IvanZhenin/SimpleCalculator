using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator.Model.Interfaces
{
    public interface IOperation
    {
        public double Operation(double firstNum, double secondNum);
    }
}