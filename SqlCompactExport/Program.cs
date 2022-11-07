
namespace SqlCompactExport
{
    using CommandLine;
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Parser.Default.ParseArguments<ExportCsvOptions>(args)
                    .WithParsed(opt => new ExportCsv(opt));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
