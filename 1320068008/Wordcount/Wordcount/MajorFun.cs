using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;

namespace Wordcount
{
    class MajorFun
    {
        byte[] data;
        long length;
        string path;
        public MajorFun(long length,byte [] data,string path)
        {
            this.data = new byte[length];
            this.data = data;
            this.length = length;
            this.path = path;
        }  
        ArrayList list = new ArrayList();
        long Count1 = 0;
        //此函数用于计算文本Ascii码字符个数
        public void CountChar()
        {
            long Count=0;
            for(long i=0;i<length;i++)
            {
                if (data[i] >= 0 && data[i] <= 127&&data[i]!='\n')
                {
                    Count++;
                }
                if(data[i]=='\n')
                {
                    Count1++;
                }
            }
            Console.WriteLine("字符个数："+(Count-Count1));
        }
        //此函数用于计算统计出现次数在前十的单词
       public void CountE_word(string path, long n)
        {
            List<string> list = new List<string>();
            Dictionary<string, int> frequencies = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            string s = "";
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] wordsArr1 = Regex.Split(line.ToLower(), "\\s*[^0-9a-zA-Z]+");
                    foreach (string word in wordsArr1)
                    {
                        if (Regex.IsMatch(word, "^[a-zA-Z]{4,}[a-zA-Z0-9]*"))
                        {
                            list.Add(word);
                        }
                    }
                }
                sr.Close();
            }
            for (int i = 0; i <= list.Count - n; i++)
            {
                int j;
                for (s = list[i], j = 0; j < n - 1; j++)
                {
                    s += " " + list[i + j + 1];
                }
                if (frequencies.ContainsKey(s))
                {
                    frequencies[s]++;
                }
                else
                    frequencies[s] = 1;
            }
            Dictionary<string, int> item = frequencies.OrderByDescending(r => r.Value).ThenBy(r => r.Key).ToDictionary(r => r.Key, r => r.Value);
            int o = 0;
            Console.WriteLine("单词频率前十名及其出现的次数：");
            foreach (var dic in item)
            {
                o++;
                if (o > 10)
                    break;
                Console.Write("No.{0}: {1}  {2}次\n",o,dic.Key,dic.Value );    
            }
            Console.WriteLine("单词总数：");
            Console.WriteLine("{0}个",list.Count );
        }
        //此函数用于计算文本有效行数
        public void GetRows()
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    String line;
                    int Countline=0;
                    for(int i=0;i<=Count1;i++)
                    {      
                       if((line = sr.ReadLine()).Trim()!=string.Empty)
                        {
                            Countline++;
                        }
                    }
                    Console.WriteLine("行数 ："+Countline);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
