using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Data;

namespace DZ2
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = @"Data Source=DESKTOP-C67817K;Initial Catalog=TestADO;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();
                Console.WriteLine(connection.State);
                //string FirstName = Console.ReadLine();
                //string SecondName = Console.ReadLine();
                //string ThirdName = Console.ReadLine();
                //int NumberBilets = Convert.ToInt32(Console.ReadLine());
                //string Facultet= Console.ReadLine();
                //DateTime DataBirth = Convert.ToDateTime(Console.ReadLine());
                //string Phone = Console.ReadLine();
                //SqlCommand com = new SqlCommand("INSERT INTO Library (FirstName,SecondName,ThirdName,NumberBilets,Facultet,DataBirth,Phone) VALUES (@FirstName,@SecondName,@ThirdName,@NumberBilets,@Facultet,@DataBirth,@Phone)", connection);
                //com.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar).Value = FirstName;
                //com.Parameters.Add("@SecondName", System.Data.SqlDbType.NVarChar).Value = SecondName;
                //com.Parameters.Add("@ThirdName", System.Data.SqlDbType.NVarChar).Value = ThirdName;
                //com.Parameters.Add("@NumberBilets", System.Data.SqlDbType.Int).Value = NumberBilets;
                //com.Parameters.Add("@Facultet", System.Data.SqlDbType.NVarChar).Value = Facultet;
                //com.Parameters.Add("@DataBirth", System.Data.SqlDbType.DateTime2).Value = DataBirth;
                //com.Parameters.Add("@Phone", System.Data.SqlDbType.NVarChar).Value = Phone;
                
                



                //com.ExecuteNonQuery();
                //SqlCommand read = new SqlCommand("SELECT * FROM Library", connection);
                //SqlDataReader reader = read.ExecuteReader();

                //if (reader.HasRows) // если есть данные
                //{
                //    // выводим названия столбцов
                //    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4), reader.GetName(5), reader.GetName(6));

                //    while (reader.Read()) // построчно считываем данные
                //    {
                //        object FirstName = reader.GetValue(0);
                //        object SecondName = reader.GetValue(1);
                //        object ThirdName = reader.GetValue(2);
                //        object NumberBilets= reader.GetValue(3);
                //        object Facultet = reader.GetValue(4);
                //        object DataBirth = reader.GetValue(5);
                //        object Phone = reader.GetValue(6);

                //        Console.WriteLine("{0}\t{1}\t{2}\t{3} \t{4} \t{5}\t{6}", FirstName, SecondName, ThirdName, NumberBilets, Facultet, DataBirth, Phone);
                //    }
                //}

                //reader.Close();
                string ResultName = Console.ReadLine();
                SqlCommand readname = new SqlCommand("SELECT * FROM Library WHERE SecondName ='"+ResultName+"'", connection);
                SqlDataReader readername = readname.ExecuteReader();

                if (readername.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", readername.GetName(0), readername.GetName(1), readername.GetName(2), readername.GetName(3), readername.GetName(4), readername.GetName(5), readername.GetName(6));

                    while (readername.Read()) // построчно считываем данные
                    {
                        object FirstName = readername.GetValue(0);
                        object SecondName = readername.GetValue(1);
                        object ThirdName = readername.GetValue(2);
                        object NumberBilets = readername.GetValue(3);
                        object Facultet = readername.GetValue(4);
                        object DataBirth = readername.GetValue(5);
                        object Phone = readername.GetValue(6);

                        Console.WriteLine("{0}\t{1}\t{2}\t{3} \t{4} \t{5}\t{6}", FirstName, SecondName, ThirdName, NumberBilets, Facultet, DataBirth, Phone);
                    }
                }

                readername.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
            }
            finally 
            {
                connection.Close();
                Console.WriteLine(connection.State);

            
            }
            Console.Read();

        }
    }
}
