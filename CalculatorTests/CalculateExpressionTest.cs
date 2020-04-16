using CalculatorAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class CalculateExpressionTest
    {
        [TestMethod]
        [DataRow("5+7", 12)]
        [DataRow("5+7*8", 61)]
        [DataRow("5+7/7", 6)]
        [DataRow("5*7/5", 7)]
        [DataRow("50-7+3", 40)]
        [DataRow("5-8", -3)]
        [DataRow("-5-8", -13)]
        [DataRow("-3/2", -1.5f)]
        [DataRow("5-1-4", 0)]
        [DataRow("5-1-5", -1)]

        public void GetResult_CompareCalculatedResult_ReturnEqualResult(string expression, float result)
        {
            //Arrange
            var calc = new CalculateExpression();

            //Action
            var calculatedResult = calc.GetResult(expression);

            //Assert
            Assert.AreEqual(calculatedResult, result);
        }

        [TestMethod]
        [DataRow(null)]

        public void GetResult_WhenExpressionIsNull_ReturnZero(string expression)
        {
            //Arrange
           var calc = new CalculateExpression();

            //Action
            var calculatedResult = calc.GetResult(expression);

            //Assert
            Assert.AreEqual(calculatedResult, 0);
        }

        [TestMethod]   
        [DataRow("58+578/2", 2, "58")] // When left number from index is first
        [DataRow("58+578/2", 6, "578")] // When left number from index in middle
        [DataRow("58+578-2*8", 8, "2")] // When left number from index is last

        public void GetLeftNumber_WhenLeftNumberIsFirstMiddleLast_ReturnLeftNumber(string expression, int index, string leftNumber)
        {
            //Arrange
            var calc = new CalculateExpression();    

            //Action
            var returnedLeftNumber = calc.GetLeftNumber(expression, index);

            //Assert
            Assert.AreEqual(leftNumber, returnedLeftNumber);
        }

        [TestMethod]
        [DataRow("58+578/2", 6)] 
        [DataRow("58+578", 2)] 

        public void GetLastActSymIndex_WhenActionSymbolExist_ReturnRightIndex(string expression, int index)
        {
            //Arrange
            var calc = new CalculateExpression();

            //Action
            var reternedIndex = calc.GetStartIndexOfLastNumber(expression);

            //Assert
            Assert.AreEqual(index, reternedIndex);
        }

        [TestMethod]
        [DataRow("585782")]      
        public void GetLastActSymIndex_WhenActionSymbolNotExist_ReturnMinusOne(string expression)
        {
            //Arrange
            var calc = new CalculateExpression();

            //Action
            var reternedIndex = calc.GetStartIndexOfLastNumber(expression);

            //Assert
            Assert.AreEqual(-1, reternedIndex);
        }

        [TestMethod]
        [DataRow(null)]
        public void GetLastActSymIndex_WhenExpressionIsNull_ReturnMinusOne(string expression)
        {
            //Arrange
            var calc = new CalculateExpression();

            //Action
            var reternedIndex = calc.GetStartIndexOfLastNumber(expression);

            //Assert
            Assert.AreEqual(-1, reternedIndex);
        }

        [TestMethod]
        [DataRow("58+578/2", 2, "578")] // When right number from index is on the first part of exp
        [DataRow("58+578/2", 6, "2")] // When right number from index in on the middle part of exp
        [DataRow("58+578-2*8", 8, "8")] // When right number from index is on the last part of exp

        public void GetRightNumber_WhenRightNumberIsFirstMiddleLast_ReturnLeftNumber(string expression, int index, string rightNumber)
        {
            //Arrange
            var calc = new CalculateExpression();

            //Action
            var returnedRightNumber = calc.GetRightNumber(expression, index);

            //Assert
            Assert.AreEqual(rightNumber, returnedRightNumber);
        }

        [TestMethod]
        [DataRow(null)]      
        public void GetRightNumber_WhenExpIsNull_ReturnNull(string expression)
        {
            //Arrange
            var calc = new CalculateExpression();

            //Action
            var returnedRightNumber = calc.GetRightNumber(expression, 5);

            //Assert
            Assert.AreEqual(null, returnedRightNumber);
        }

        [TestMethod]
        [DataRow("58+578/2", 2)]
        [DataRow("58+578", 2)]

        public void GetFirstActSymIndex_WhenActionSymbolExist_ReturnRightIndex(string expression, int index)
        {
            //Arrange
            var calc = new CalculateExpression();

            //Action
            var reternedIndex = calc.GetEndIndexOfFirstNumber(expression);

            //Assert
            Assert.AreEqual(index, reternedIndex);
        }
    }
}
