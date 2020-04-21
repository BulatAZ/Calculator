using System.Text.RegularExpressions;

namespace CalculatorAPI
{
    public static class ExpressionChecker
    {
        //ReferenceData reference = new ReferenceData();
        public static bool IsCorrect(string exp)
        {
            if (string.IsNullOrEmpty(exp))
            {
                return false;
            }
            ExpressionChecker.ParseToExpress(ref exp);

            var pattern_1 = @"[^0-9+-/*]";    // exp contain only digitals and action symbols
            var pattern_2 = @"^?[0-9-]*\d$";  // exp can start with minus (-) or digital and must end with digital
            var pattern_3 = @"[-+/*][-+/*]";  // exp didn't must contain contractors digital symbols

            var checkResult_1 = !Regex.Match(exp, pattern_1).Success;
            var checkResult_2 = Regex.Match(exp, pattern_2).Success;
            var checkResult_3 = !Regex.Match(exp, pattern_3).Success;

            return checkResult_1 && checkResult_2 && checkResult_3;
        }

        public static void ParseToExpress(ref string exp)
        {
            DeleteActionSymbolsInTheEnd(ref exp);
            DeleteWhiteSpace(ref exp);
        }

        private static void DeleteActionSymbolsInTheEnd(ref string exp)
        {
            var patt = @"[-+*/]*$";
            exp = Regex.Split(exp, patt)[0];            
        }
        private static void DeleteWhiteSpace(ref string exp)
        {
            var patt = @"[-+*/]*$";
            //exp = Regex.Split(exp, patt)[0];
        }
    }
}
