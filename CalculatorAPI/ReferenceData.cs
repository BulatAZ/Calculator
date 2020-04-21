using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorAPI
{
    internal class ReferenceData
    {
        public readonly List<string> ActionSymbols = new List<string>()
        {
            "/","*","+","-"
        };

        public readonly List<string> NumberSymbols = new List<string>()
        {
            "1", "2", "3"
        };
    }
}
