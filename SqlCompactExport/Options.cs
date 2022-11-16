using CommandLine;

namespace SqlCompactExport
{
    public class Options
    {
        [Option('d', "databasefile", Required = true, HelpText = "The file path to the SQL Compact database file.")]
        public string DatabaseFile { get; set; }

        [Option('q', "query", Required = true, HelpText = "The SQL query to be used on the SQL Compact database.")]
        public string Query { get; set; }
    }
}
