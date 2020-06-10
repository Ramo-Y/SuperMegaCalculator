namespace SuperMegaCalculator.WebApp.Pages
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Components;

    using SuperMegaCalculator.WebApp.Data;

    public class CalculationViewBase : ComponentBase
    {
        public CalculationViewBase()
        {
            CalculationID = 1;
            CurrentCalculation = new Calculation
                                     {
                                         CalculationID = CalculationID
                                     };

            OperatorItems = new List<string>
                                {
                                    "+",
                                    "-",
                                    "*",
                                    "/"
                                };

            CurrentCalculation.Operator = OperatorItems.First();
            CalculationItems = new List<Calculation>();
        }

        private int CalculationID { get; set; }

        protected List<Calculation> CalculationItems { get; }

        protected Calculation CurrentCalculation { get; set; }

        [Inject]
        private Calculator Calculator { get; set; }

        protected List<string> OperatorItems { get; }

        protected void CalculateAndAddToHistory()
        {
            CurrentCalculation.ResultText = Calculator.Calculate(CurrentCalculation.FirstNumber, CurrentCalculation.SecondNumber, CurrentCalculation.Operator);
            CurrentCalculation.CalculationProcess =
                $"{CurrentCalculation.FirstNumber} {CurrentCalculation.Operator} {CurrentCalculation.SecondNumber} = {CurrentCalculation.ResultText}";
            CalculationItems.Add(CurrentCalculation);
            CalculationID++;
            CurrentCalculation = new Calculation
                                     {
                                         Operator = OperatorItems.First(),
                                         CalculationID = CalculationID
                                     };

            StateHasChanged();
        }
    }
}