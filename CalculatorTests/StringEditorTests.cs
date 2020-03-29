using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Calculator.Tests
{
    [TestClass()]
    public class StringEditorTests
    {
        [TestMethod()]        
        public void IsAction_WhenActionSymbol_ReturnTrue()
        {
            //Arrange   
            var symbol = "+";
            //Action
            var result = ExpressionEditor.IsAction(symbol);

            //Assert
            Assert.AreEqual(true, result);
        }
    }
}