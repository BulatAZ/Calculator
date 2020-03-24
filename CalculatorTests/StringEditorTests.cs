using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Calculator.Tests
{
    [TestClass()]
    public class StringEditorTests
    {
        [TestMethod()]        
        public void IsAction_WhenActionSymbol()
        {
            

            //Action
            var result = ExpressionEditor.IsAction('+');

            //Assert
            Assert.AreEqual(true, result);
        }
    }
}