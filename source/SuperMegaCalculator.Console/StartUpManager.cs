namespace SuperMegaCalculator.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SuperMegaCalculator.Interfaces;

    internal class StartUpManager
    {
        private readonly ICalculator _calculator;

        private readonly IDictionary<char, Operator> _operatorMapping;

        public StartUpManager()
        {
            _calculator = new Calculator();
            _operatorMapping = new Dictionary<char, Operator>
                                   {
                                       {
                                           'a', Operator.Addition
                                       },
                                       {
                                           's', Operator.Subtraction
                                       },
                                       {
                                           'm', Operator.Multiplication
                                       },
                                       {
                                           'd', Operator.Division
                                       }
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

            Calculate();
        }

        private void AskForNewCalculation()
        {
            while (true)
            {
                Console.WriteLine("Want a new calculation? ( y = yes | n = abort )");

                var i = Console.ReadKey().KeyChar;
                switch (i)
                {
                    case 'y':
                        Calculate();
                        break;
                    case 'n':
                        return;
                    default:
                        Console.WriteLine("Wrong input!");
                        continue;
                }

                break;
            }
        }

        private void Calculate()
        {
            Console.WriteLine();

            var firstNumber = GetNumber("Write the first number");
            var calculationOperator = GetOperator();
            var secondNumber = GetNumber("Write the second number");

            try
            {
                var result = _calculator.Calculate(firstNumber, secondNumber, calculationOperator);
                Console.WriteLine();
                Console.WriteLine($"Result is '{result}'");
                Console.WriteLine();
            }
            catch (DivideByZeroException exception)
            {
                ShowError(exception);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                ShowError(exception);
            }

            AskForNewCalculation();
        }

        private static void ShowError(Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Error: {exception.Message}");
            Console.ResetColor();
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

        private Operator GetOperator()
        {
            while (true)
            {
                Console.WriteLine("Write an operator ( Addition (a) | Subtraction (s) | Multiplication (m) | Division (d) )");
                var operatorChar = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (_operatorMapping.Keys.Any(o => o == operatorChar))
                {
                    var value = _operatorMapping.Single(o => o.Key == operatorChar).Value;
                    Console.WriteLine($"Your input '{operatorChar}' matches to operator '{value}'");
                    return value;
                }

                Console.WriteLine($"Your input '{operatorChar}' is not correct!");
            }
        }
    }
}