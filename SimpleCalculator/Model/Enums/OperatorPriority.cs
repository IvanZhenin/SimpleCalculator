namespace SimpleCalculator.Model.Enums
{
    public enum OperatorPriority : byte
    {
        BracketOpen = 0,
        BracketClose = 1,
        AdditionSubtraction = 2,
        MultiplicationDivision = 3,
    }
}