using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCG_UML.ConfigurableParser.Lexer;

namespace TCG_UML.UnitTests
{
    [TestClass]
    public class NFA_GRAPH_Tests
    {
        [TestMethod]
        public void Get_NFAFromRE_Test()
        {
            //Arrange

            NFA_GRAPH nfaGraph = new NFA_GRAPH("AB");

            //Act

            //Assert

            Assert.IsTrue(true);

        }
    }
}
