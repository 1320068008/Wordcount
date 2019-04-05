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
    public class MajorFun
    {
        ArrayList list = new ArrayList();
        List<string> Cout = new List<string>();
        long Count1 = 0;
        //此函数用于计算文本Ascii码字符个数
        public long CountChar(byte [] data)
        {
            long Count=0;
            for(long i=0;i<data.Length;i++)
            {
                if (data[i] >= 0 && data[i] <= 127)
                {
                    Count++;
                }
                if(data[i]=='\n')
                {
                    Count1++;
                }
            }
            long c = Count - Count1;
            Cout.Add("字符个数："+c);
            Console.WriteLine("字符个数："+(Count-Count1));
            return Count;
        }
        //此函数用于计算统计出现次数在前十的单词
       public int CountE_word(string path, int m,int n)
        {
            List<string> list = new List<string>();
            List<string> list1 = new List<string>();
            Dictionary<string, int> frequencies = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            Dictionary<string, int> frequencies1 = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            string s = "";
            string s1 = "";
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
                            list1.Add(word);
                        }
                    }

                }
                sr.Close();

                for (int i = 0; i <= list.Count - 1; i++)
                {
                    int j;
                    for (s = list[i], j = 0; j < 0; j++)
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
                int o = 0;
                Console.WriteLine("单词频率前" + n + "名及其出现的次数：");
                Dictionary<string, int> item = frequencies.OrderByDescending(r => r.Value).ThenBy(r => r.Key).ToDictionary(r => r.Key, r => r.Value);
                foreach (KeyValuePair<string, int> entry in item)
                {
                    o++;
                    if (o > n)
                        break;
                    string word = entry.Key;
                    int frequency = entry.Value;
                    Console.WriteLine("No." + o + " " + word + "  :  " + frequency + "次 ");
                    Cout.Add("No." + o + " " + word + "  :  " + frequency + "次 ");
                }
                for (int i = 0; i <= list1.Count - m; i++)
                {
                    int j;
                    for (s1 = list1[i], j = 0; j < m - 1; j++)
                    {
                        s1 += " " + list1[i + j + 1];
                    }
                    if (frequencies1.ContainsKey(s1))
                    {
                        frequencies1[s1]++;
                    }
                    else
                        frequencies1[s1] = 1;
                }
                Dictionary<string, int> item1 = frequencies1.OrderByDescending(r => r.Value).ThenBy(r => r.Key).ToDictionary(r => r.Key, r => r.Value);
                Console.WriteLine("输出长度为" + m + "的单词组：");
                Cout.Add("输出长度为" + m + "的单词组：");
                foreach (var dic1 in item1)
                {
                    Console.Write(" {0}  {1}次\n", dic1.Key, dic1.Value);
                    Cout.Add(dic1.Key.ToString() + "  " + dic1.Value + "次");
                }
                Console.WriteLine("单词总数：");
                Console.WriteLine("{0}个", list.Count);
                Cout.Add("单词总数：" + list.Count);
                return 1;
            }
            else
            {
                return -1;
            }
        }
        //此函数用于计算文本有效行数
        public void GetRows(string path)
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
                    Cout.Add("行数 ："+Countline);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        //此函数用于将屏幕上输出内容写入指定文件
        public void  WritoFile(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("路径不存在！");
            }
            else
            {
                FileStream fs = new FileStream(path,FileMode.Create, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                foreach(string w in Cout)
                {
                    sr.WriteLine(w);
                }
                Console.WriteLine("写入成功");
                sr.Close();
                fs.Close();
            }
        }
    }
}
