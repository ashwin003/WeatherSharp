using Microsoft.AspNetCore.Components;

namespace WeatherSharp.Client.Shared {
    public partial class DonutChart 
    {
        [Parameter]
        public double Value 
        {
            get;
            set;
        }

        [Parameter]
        public string Name 
        {
            get;
            set;
        }

        [Parameter]
        public string StrokeColor 
        {
            get;
            set;
        } = "#69aff4";

        private double Radius {get;set;} = 69.85699;

        private double FilledStroke {get;set;}

        protected override void OnInitialized()
        {
            var circumference = 2 * System.Math.PI * Radius;
            System.Console.WriteLine(circumference);
            FilledStroke = Value * circumference / 100;
            base.OnInitialized();
        }
    }
}