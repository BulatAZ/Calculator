using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Calculator.Tests
{
    [TestClass()]
    public class StringEditorTests
    {
        [TestMethod()]
        
        public void IsAction_WhenActionSymbol()
        {

            var result = StringEditor.IsAction("+");

            //Assert
            Assert.AreEqual(true, result);
        }
    }
}