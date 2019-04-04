using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wordcount
{
    class FileOp
    {
        public string path;
        public byte[] zipdata;
        public void GetPath()
        {
            Console.WriteLine("请输入文件路径：");
            path = Console.ReadLine();
        }
        //此函数用于读取文本文件内容
        public void ReadFile(string path)
        {
              if (File.Exists(path))
              {
                FileStream fs = new FileStream(path, FileMode.Open);
                zipdata = new byte[fs.Length];
                fs.Read(zipdata, 0, zipdata.Length);
                fs.Close();
              }
              else
                Console.WriteLine("路径不存在！");
        }
        //此函数用于调用主功能函数
        public void Movedata()
        {
            MajorFun Maj = new MajorFun(zipdata.Length, zipdata,path );
            Maj.CountChar();
            Maj.CountE_word(path,1);
            Maj.GetRows();
        }      
    }
    class Program
    {
        static void Main(string[] args)
        {
            FileOp f = new FileOp();
            f.GetPath();
            f.ReadFile(f.path );
            f.Movedata();
            Console.ReadKey();
        }
    }
}
