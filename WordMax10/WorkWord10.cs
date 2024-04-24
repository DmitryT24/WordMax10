using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMax10
{
    internal class WorkWord10
    {
        Dictionary<string, int> list;
        IEnumerable<KeyValuePair<string, int>> topWord10;

        string setWordDictionary
        {
            set
            {
                if (list.ContainsKey(value))
                {
                    list[value] += 1;
                }
                else
                {
                    list.Add(value, 1);
                }
            }
        }

        Dictionary<string, int> getWordDictionary
        {
            get => list;
        }

        static StreamReader OpenFile()
        {
            var directoryFile = Path.Combine(Directory.GetCurrentDirectory(), "Text1.txt");
            if (File.Exists(directoryFile))
            {
                return File.OpenText(directoryFile);
            }
            else
            {
                //  Console.WriteLine($"Ошибка открытия файла: {directoryFile}!");
                throw new MyException($"Ошибка открытия файла: {directoryFile}!");
            }
        }

        public void LoadToDistionary()
        {
            list = new Dictionary<string, int>();
            char[] delimiterChars = { '>', '<', '"', '–', '«', '»', ' ', ',', '.', ':', '\t', '\n' };
            using (StreamReader fileRead = OpenFile())
            {
                if (fileRead != null)
                {
                    string[] strings = fileRead.ReadToEnd().Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string str in strings)
                        setWordDictionary = str;

                    CountingWord10();
                }
                fileRead.Close();
            }
        }

        void CountingWord10()
        {
           topWord10 =  getWordDictionary.OrderByDescending(pair => pair.Value).Take(10);
        }

        public void WriteDisplayTopWords10()
        {
            int count = 0;
           // Console.WriteLine($">>{list.Count}");
            foreach (var word in topWord10)
            {
                count++;
                Console.WriteLine($"\t {count}:\t  слово:{word.Key}\t  повторений: {word.Value}.\t");
            }
        }

    }

}
