using EaterShell;

namespace EaterShellTest
{
    [TestClass]
    public class VerTest
    {
        [TestMethod]
        public void VerCommand_OutputTest()
        {
            string expected = "Microsoft Windows NT 10.0.22621.0";
            TestOutputWriter testOutputWriter = new TestOutputWriter();
            VerCommand verCommand = new(testOutputWriter);


            verCommand.Execute();

            Assert.AreEqual(expected, testOutputWriter.OutputBuffer);
        }
    }
}