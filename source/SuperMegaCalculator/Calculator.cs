namespace SuperMegaCalculator
{
    using SuperMegaCalculator.Helper;
    using SuperMegaCalculator.Interfaces;

    public class Calculator : ICalculator
    {
        public double Calculate(int firstNumber, int secondNumber, Operator operatorEnum)
        {
            var calculationExpression = $"{firstNumber}{operatorEnum}{secondNumber}";
            var calculationStrategy = StrategyHelper.GetMatchingStrategy(calculationExpression);
            var result = calculationStrategy.GetCalculationResult();
            return result;
        }
    }
}