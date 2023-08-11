using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace ConsoleApp1_1
{
    internal class Task3
    {
        public void doSomething(string path)
        {
            string connectionString = "Data Source=WIN-B9PG27IQF4T;Database=B1; Persist Security Info=False; User ID='sa'; Password='sa'; MultipleActiveResultSets=True;Trusted_Connection=False;TrustServerCertificate=True;Connection Timeout=120;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int numberOfLines = 0;
                int maxLines = File.ReadAllLines(path).Length;
                
                    using (StreamReader reader = new StreamReader(path, false))
                    {
                        while (reader.ReadLine != null)
                        {
                            
                            string? str = reader.ReadLine();
                            string[] values = str.Split("||");

                            string sqlExpression = string.Format("insert Table3 values ('{0}','{1}','{2}',{3},{4});", values[0], values[1], values[2], values[3], values[4].Replace(",","."));
                            Console.WriteLine(sqlExpression);
                            SqlCommand command = new SqlCommand(sqlExpression, connection);
                        try
                        {
                            command.BeginExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {

                            

                            Console.WriteLine(ex.ToString());
                            
                        }
                        //Console.WriteLine(sqlExpression);
                        numberOfLines++;
                        if (numberOfLines>20) {
                            break;
                        }
                            Console.WriteLine("Импортировано {0} строк. Осталось {1} строк.", numberOfLines, maxLines - numberOfLines);
                        }

                    }
                
                


            }
        }



        }
    }

