using SimpleCalculator.Model.Interfaces;
using System.Reflection;

namespace SimpleCalculator.Model
{
    public static class OperationsRepository
    {
        public static readonly IReadOnlyList<IOperator> OperatorList = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => typeof(IOperator).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
            .Select(Activator.CreateInstance).Cast<IOperator>().ToList();

        public static readonly IReadOnlyList<IOperation> OperationList = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => typeof(IOperation).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
            .Select(Activator.CreateInstance).Cast<IOperation>().ToList();
    }
}