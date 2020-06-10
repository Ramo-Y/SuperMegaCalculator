namespace SuperMegaCalculator.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUpManager
    {
        private readonly List<string> _operatorItems;

        public StartUpManager()
        {
            _operatorItems = new List<string>
                                 {
                                     "+",
                                     "-",
                                     "*",
                                     "/"
                                 };
        }

        internal void Start()
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            Console.WriteLine("+++++++++++++++++++ SuperMegaCalculator started... +++++++++++++++++++");

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            while (true)
            {
                Calculate();
                Console.WriteLine("Want a new calculation? ( y )");
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    return;
                }

                if (!input.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
            }
        }

        private void Calculate()
        {
            Console.WriteLine();

            var firstNumber = GetNumber("Write the first number");
            var calculationOperator = GetOperator();
            var secondNumber = GetNumber("Write the second number");

            var calculator = new Calculator();
            var result = calculator.Calculate(firstNumber, secondNumber, calculationOperator);
            Console.WriteLine();
            Console.WriteLine($"Result is '{result}'");
            Console.WriteLine();
        }

        private int GetNumber(string outputText)
        {
            var number = 0;
            var tryParse = false;
            while (!tryParse)
            {
                Console.WriteLine(outputText);
                var input = Console.ReadLine();
                tryParse = int.TryParse(input, out number);
                if (!tryParse)
                {
                    Console.WriteLine($"'{input}' is not a nuber!");
                }
            }

            return number;
        }

        private string GetOperator()
        {
            var outputText = "Write an operator (";
            var count = _operatorItems.Count - 1;
            for (var i = 0; i <= count; i++)
            {
                outputText += $" {_operatorItems[i]} ";
                if (i != count)
                {
                    outputText += "|";
                }
            }

            outputText += ")";

            while (true)
            {
                Console.WriteLine(outputText);
                var calculationOperator = Console.ReadLine();

                if (_operatorItems.Any(o => o == calculationOperator))
                {
                    return calculationOperator;
                }

                Console.WriteLine($"Your input '{calculationOperator}' is not correct!");
            }
        }
    }
}