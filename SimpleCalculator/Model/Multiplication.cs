﻿using SimpleCalculator.Model.Interfaces;

namespace SimpleCalculator.Model
{
    public class Multiplication : IOperation
    {
        public char Symbol => '*';
        public byte Priority => 3;
        public double Operation(double firstNum, double secondNum) => firstNum * secondNum;
    }
}