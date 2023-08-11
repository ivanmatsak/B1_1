using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_1
{
    internal class Task2
    {
        public void doSomething(string toRemove, int numberOfFiles)
        {
            int deleted = 0;
            string mergedPath = "merged.txt";
            using (StreamWriter mergedWriter = new StreamWriter(mergedPath, false))
            {
                for (int i = 1; i < numberOfFiles+1; i++)
                {
                    string path = "note" + i + ".txt";

                    using (StreamReader reader = new StreamReader(path, false))
                    {

                        for (int j = 0; j < 100000; j++)
                        {
                            string? str = reader.ReadLine();
                            if (str.Contains(toRemove)) {

                                Console.WriteLine(str);
                                deleted++;
                                continue;
                            }

                            
                            mergedWriter.WriteLine(str);
                        }

                    }
                }
                Console.WriteLine("Удалено: "+deleted);
            }

        }
    }
}
