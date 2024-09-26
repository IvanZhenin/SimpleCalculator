using SimpleCalculator.Model;
using SimpleCalculator.Model.Interfaces;

namespace SimpleCalculator.Helpers
{
    public static class OperatorRegistry
    {
        public static IOperation GetOperation(char symbol)
        {
            try
            {
                return OperationsRepository.OperationList.First(p => p.Symbol == symbol);
            }
            catch (Exception)
            {
                throw new ArgumentException("Некорректный тип операции");
            }
        }

        public static byte GetPriority(char symbol)
        {
            try
            {
                return OperationsRepository.OperatorList.First(p => p.Symbol == symbol).Priority;
            }
            catch (Exception)
            {
                throw new ArgumentException("Некорректный оператор");
            }
        }
    }
}
