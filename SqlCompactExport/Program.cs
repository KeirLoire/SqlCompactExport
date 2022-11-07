
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
                Parser.Default.ParseArguments<Options, ExportCsvOptions>(args)
                    .WithParsed<ExportCsvOptions>(opt => new ExportCsv(opt));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
