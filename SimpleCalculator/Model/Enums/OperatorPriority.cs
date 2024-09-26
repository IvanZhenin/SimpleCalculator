namespace SimpleCalculator.Model.Enums
{
    public enum OperatorPriority : byte
    {
        BracketOpen = 0,
        BracketClose = 1,
        AdditionSubtraction = 3,
        MultiplicationDivision = 4,
    }
}