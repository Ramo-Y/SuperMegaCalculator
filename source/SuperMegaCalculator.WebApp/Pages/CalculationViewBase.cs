namespace SuperMegaCalculator.WebApp.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Components;

    using SuperMegaCalculator.Interfaces;
    using SuperMegaCalculator.WebApp.Data;

    public class CalculationViewBase : ComponentBase
    {
        protected readonly IDictionary<string, Operator> _operatorMapping;

        public CalculationViewBase()
        {
            CurrentCalculation = new Calculation
                                     {
                                         CalculationID = 1
                                     };

            _operatorMapping = new Dictionary<string, Operator>
                                   {
                                       {
                                           "+", Operator.Addition
                                       },
                                       {
                                           "-", Operator.Subtraction
                                       },
                                       {
                                           "*", Operator.Multiplication
                                       },
                                       {
                                           "/", Operator.Division
                                       }
                                   };

            CurrentCalculation.Operator = _operatorMapping.Keys.First();
            CalculationItems = new List<Calculation>();
        }

        private int CalculationID { get; set; }

        protected List<Calculation> CalculationItems { get; }

        protected Calculation CurrentCalculation { get; private set; }

        [Inject]
        private ICalculator Calculator { get; set; }

        protected void CalculateAndAddToHistory()
        {
            var selectedOperator = _operatorMapping.Single(o => o.Key == CurrentCalculation.Operator).Value;
            try
            {
                var result = Calculator.Calculate(CurrentCalculation.FirstNumber, CurrentCalculation.SecondNumber, selectedOperator);
                CurrentCalculation.Result = result;
                CurrentCalculation.CalculationProcess =
                    $"{CurrentCalculation.FirstNumber} {CurrentCalculation.Operator} {CurrentCalculation.SecondNumber} = {CurrentCalculation.Result}";
            }
            catch (DivideByZeroException exception)
            {
                AddError(exception);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                AddError(exception);
            }

            CalculationItems.Add(CurrentCalculation);

            CurrentCalculation = new Calculation
                                     {
                                         Operator = _operatorMapping.Keys.First(),
                                         CalculationID = CalculationID++
                                     };

            StateHasChanged();
        }

        private void AddError(Exception exception)
        {
            CurrentCalculation.CalculationProcess = $"{CurrentCalculation.FirstNumber} {CurrentCalculation.Operator} {CurrentCalculation.SecondNumber} = {exception.Message}";
        }
    }
}