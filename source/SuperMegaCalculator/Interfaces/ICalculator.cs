namespace SuperMegaCalculator.Interfaces
{
    public interface ICalculator
    {
        /// <summary>
        /// calculates two numbers with given operator ( + | - | * | / )
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <param name="operatorEnum">The operator for calculation ( Addition (+) | Subtraction (-) | Multiplication (*) | Division (/) )</param>
        /// <returns>result value as double</returns>
        double Calculate(int firstNumber, int secondNumber, Operator operatorEnum);
    }
}