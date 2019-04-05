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
        public byte[] ReadFile(string path)
        {
              if (File.Exists(path))
              {
                FileStream fs = new FileStream(path, FileMode.Open);
                zipdata = new byte[fs.Length];
                fs.Read(zipdata, 0, zipdata.Length);
                fs.Close();
                return zipdata;
              }
              else
              {
                Console.WriteLine("路径不存在！");
                return zipdata;
              }
        }
        //此函数用于调用主功能函数
        public void Movedata(int m,int n,string p)
        {
            MajorFun Maj = new MajorFun();
            Maj.CountChar(zipdata);
            Maj.CountE_word(path,m,n);
            Maj.GetRows(path);
            Maj.WritoFile(p);
        }      
    }
    class Program
    {
        static void Main(string[] args)
        {
            FileOp f = new FileOp();
            int m=1, n=10;
            int i = 0;
            string[] arg;
            arg = Sort(args);
            if (arg.Length != 0)
            {
                for (i = 0; i < arg.Length; i++)
                {
                    if (arg[i] == "-m")
                    {
                        m = int.Parse(arg[i + 1]);
                    }
                    if (arg[i] == "-n")
                    {
                        n = int.Parse(arg[i + 1]);
                    }
                }
                f.path = arg[1];
                f.ReadFile(f.path);
                f.Movedata(m, n, arg[arg.Length - 1]);
                Console.ReadKey();
                }
            else
            {
                Console.WriteLine("缺少有效读入或输出文件路径或命令指示标志");
            }
            
        }
        static string [] Sort(string[] w)
        {
            int i=0;
            int count=0;
            while(i<w.Length)
            {
                if(w[i]=="-i"||w[i]=="-o")
                {
                    count++;
                }
                i++;
            }
            if(count==2)
            {
                string tempO,tempS;
                for(i=0;i<w.Length;i++)
                {
                    if(w[i]=="-i")
                    {
                        
                        tempO = w[i];
                        tempS = w[i + 1];
                        w[i] = w[0];
                        w[i + 1] = w[1];
                        w[0] = tempO;
                        w[1] = tempS;
                    }
                    if(w[i]=="-o")
                    {
                        tempO = w[i];
                        tempS = w[i + 1];
                        w[i] = w[w.Length-2];
                        w[i + 1] = w[w.Length-1];
                        w[w.Length - 2] = tempO;
                        w[w.Length - 1] = tempS;
                    }
                }
                return w;
            }
            else
            {
                string[] x = new string[0];
                return x;
            }
            
        }
    }
}
