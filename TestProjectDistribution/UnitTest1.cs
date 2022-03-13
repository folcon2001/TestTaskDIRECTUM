using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTask;

namespace TestProjectDistribution
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodProp()
        {
            string summStr = "1000;2000;3000;5000;8000;5000";
            float distrSumm = 10000;
            string distrib = "опно";


            var actualResult = Program.Distribution(distrib, distrSumm, summStr);

            Assert.AreEqual(416.67, actualResult[0],0.01);
            Assert.AreEqual(833.33, actualResult[1], 0.01);
            Assert.AreEqual(1250, actualResult[2], 0.01);
            Assert.AreEqual(2083.33, actualResult[3], 0.01);
            Assert.AreEqual(3333.33, actualResult[4], 0.01);
            Assert.AreEqual(2083.34, actualResult[5], 0.01);

        }

        [TestMethod]
        public void TestMethodFirst()
        {
            string summStr = "1000;2000;3000;5000;8000;5000";
            float distrSumm = 10000;
            string distrib = "оепб";


            var actualResult = Program.Distribution(distrib, distrSumm, summStr);

            Assert.AreEqual(1000, actualResult[0]);
            Assert.AreEqual(2000, actualResult[1]);
            Assert.AreEqual(3000, actualResult[2]);
            Assert.AreEqual(4000, actualResult[3]);
            Assert.AreEqual(0, actualResult[4]);
            Assert.AreEqual(0, actualResult[5]);

        }
        [TestMethod]
        public void TestMethodLast()
        {
            string summStr = "1000;2000;3000;5000;8000;5000";
            float distrSumm = 10000;
            string distrib = "оняк";

            var actualResult = Program.Distribution(distrib, distrSumm, summStr);

            Assert.AreEqual(0, actualResult[0]);
            Assert.AreEqual(0, actualResult[1]);
            Assert.AreEqual(0, actualResult[2]);
            Assert.AreEqual(0, actualResult[3]);
            Assert.AreEqual(5000, actualResult[4]);
            Assert.AreEqual(5000, actualResult[5]);

        }

        [TestMethod]
        public void TestMethodProp1()
        {
            string summStr = "1000";
            float distrSumm = 10000;
            string distrib = "опно";


            var actualResult = Program.Distribution(distrib, distrSumm, summStr);

            Assert.AreEqual(10000, actualResult[0], 0.01);
       

        }




    }
}
