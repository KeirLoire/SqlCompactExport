namespace SqlCompactExport
{
    using CommandLine;
    using System.Collections.Generic;
    using System.Data.SqlServerCe;
    using System.IO;
    using System.Text;

    public class ExportCsvOptions : Options
    {
        [Option('o', "outputfile", Default = "output.csv", HelpText = "The file path and name for the CSV output file.")]
        public string OutputFile { get; set; }

        [Option('s', "separator", Default = ",", HelpText = "The separator or delimiter to be used on the CSV output file.")]
        public string Separator { get; set; }
    }

    public class ExportCsv
    {
        public ExportCsv(ExportCsvOptions opt)
        {
            StringBuilder sb = new StringBuilder();

            using (SqlCeConnection connection = new SqlCeConnection(string.Format(@"Data Source={0};", opt.DatabaseFile)))
            {
                connection.Open();
                using (SqlCeCommand command = new SqlCeCommand(opt.Query, connection))
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

                            sb.AppendLine(string.Join(opt.Separator, row));
                        }
                        reader.Close();
                    }
                    command.Dispose();
                }
                connection.Close();
            }

            using (StreamWriter sw = new StreamWriter(opt.OutputFile))
            {
                sw.Write(sb);
            }
        }
    }
}
