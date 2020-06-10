﻿namespace SuperMegaCalculator.WebApp.Data
{
    public class Calculation
    {
        public int CalculationID { get; set; }

        public int FirstNumber { get; set; }

        public int SecondNumber { get; set; }

        public string Operator { get; set; }

        public string ResultText { get; set; }

        public string CalculationProcess { get; set; }
    }
}