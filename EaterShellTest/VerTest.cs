using EaterShell;

namespace EaterShellTest
{
    [TestClass]
    public class VerTest
    {
        [TestMethod]
        public void ShellIsOpen_UserInputEqualsVer_OutputWindowsVersion()
        {
            string expected = Environment.OSVersion.ToString();
            TestOutputWriter testOutputWriter = new TestOutputWriter();
            VerCommand verCommand = new(testOutputWriter);


            verCommand.Execute();

            Assert.AreEqual(expected, testOutputWriter.OutputBuffer);
        }
    }
}