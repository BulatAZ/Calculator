using System;
using CalculatorAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorAPITest
    {
        [TestMethod]
        [DataRow("123-2+23/112*1")]
        [DataRow("123-2+23/112*1")]
        [DataRow("-123-2+23/112*1")]
        public void IsCorrect_WhenExpressIsCorrect_ReturnTrue(string expression)
        {
            //Arrange
            
            //Action
            var result = ExpressionChecker.IsCorrect(expression);

            //Assert
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        [DataRow("123+22R2-3")]
        [DataRow("123+22!-3")]
        [DataRow("22o-3")]
        public void IsCorrect_WhenExpressionHaveExtraSymbols_ReturnFalse(string expression)
        {
            //Arrange
            
            //Action
            var result = ExpressionChecker.IsCorrect(expression);

            //Assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        [DataRow("123+22R+-3")]
        [DataRow("123+22--3")]
        [DataRow("22-3*+4")]
        [DataRow("22/*-+-3")]
        public void IsCorrect_WhenExpressionHaveDoubleActionSymbols_ReturnFalse(string expression)
        {
            //Arrange

            //Action
            var result = ExpressionChecker.IsCorrect(expression);

            //Assert
            Assert.AreEqual(result, false);
        }     

        [TestMethod]        
        public void IsCorrect_WhenExpressionIsNull_ReturnFalse()
        {
            //Arrange
            string expression = null;

            //Action
            var result = ExpressionChecker.IsCorrect(expression);

            //Assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void IsCorrect_WhenExpressionIsEmpty_ReturnFalse()
        {
            //Arrange
            string expression = string.Empty;

            //Action
            var result = ExpressionChecker.IsCorrect(expression);

            //Assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void IsCorrect_WhenExpressionHaveOnlyWhiteSpace_ReturnFalse()
        {
            //Arrange
            string expression = "      ";

            //Action
            var result = ExpressionChecker.IsCorrect(expression);

            //Assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        [DataRow("*123+22-3")]
        [DataRow("+123+22-3")]
        [DataRow("/22-3+4")]
        public void IsCorrect_WhenExpressionDidntStartWithdigitalOrMinus_ReturnFalse(string expression)
        {
            //Arrange          

            //Action
            var result = ExpressionChecker.IsCorrect(expression);

            //Assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]               
        public void ParseToExpression_WhenExpressionOnTheEndHaveExtraSymbols_ReturnWithoutExtraSymbols()
        {
            //Arrange          
            var wrongExpression = "123-133+321/*-";
            var rightExpression = "123-133+321";
            //Action
            ExpressionChecker.ParseToExpress(ref wrongExpression);

            //Assert
            Assert.AreEqual(wrongExpression, rightExpression);
        }
    }
}
 