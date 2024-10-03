﻿using SimpleCalculator.Model.Interfaces;

namespace SimpleCalculator.Model
{
    public class Addition : IOperation
    {
        public char Symbol => '+';
        public byte Priority => 2;
        public double Operation(double firstNum, double secondNum) => firstNum + secondNum;
    }
}