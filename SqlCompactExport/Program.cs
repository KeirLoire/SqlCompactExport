
namespace SqlCompactExport
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlServerCe;
    using System.IO;
    using System.Linq;
    using System.Text;

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                using (SqlCeConnection connection = new SqlCeConnection(@"Data Source=..\..\..\SqlCompactExport.Test\sample.sdf;"))
                {
                    connection.Open();
                    using (SqlCeCommand command = new SqlCeCommand(@"SELECT * FROM [Products];", connection))
                    {
                        using (SqlCeDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                List<string> row = new List<string>();

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row.Add(reader.GetValue(i).ToString());
                                }

                                sb.AppendLine(string.Join(",", row));
                            }
                            reader.Close();
                        }
                        command.Dispose();
                    }
                    connection.Close();
                }

                using (StreamWriter sw = new StreamWriter(@"output.csv"))
                {
                    sw.Write(sb);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
