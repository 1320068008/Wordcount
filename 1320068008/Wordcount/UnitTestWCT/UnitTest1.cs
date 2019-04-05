using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wordcount;
namespace UnitTestWCT
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            byte[] res = Enumerable.Repeat((byte)0x08, 10).ToArray();
            MajorFun majorFun = new MajorFun();
            Assert.AreEqual(res.Length,(int)(majorFun.CountChar(res)));
        }
        [TestMethod]
        public void TestMethod2()
        {
            MajorFun majorFun = new MajorFun();
            string path = @"D:\第二次vs存储位置作业\Wordcount\1320068008\新建文件夹\unittest.txt";
            string path1 = @"D:\第二次vs存储位置作业\Wordcount\1320068008\新建文件夹\unittest1.txt";
            Assert.AreEqual(1,majorFun.CountE_word(path,1,3));
            majorFun.WritoFile(path1);
        }
        [TestMethod]
        public void TestMethod3()
        {
            MajorFun majorFun = new MajorFun();
            string path = @"D:\第二次vs存储位置作业\Wordcount\1320068008\新建文件夹\unittest.txt";
            string path1 = @"D:\第二次vs存储位置作业\Wordcount\1320068008\新建文件夹\unittest1.txt";
            majorFun.GetRows(path);
            majorFun.WritoFile(path1);
        }
    }
}
