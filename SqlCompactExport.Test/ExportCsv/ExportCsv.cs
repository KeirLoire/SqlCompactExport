namespace SqlCompactExport.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SqlCompactExport;
    using System.Linq;
    using System.IO;

    [TestClass]
    public class ExportCsv
    {
        [TestMethod]
        [DataRow("sample.sdf", "output.csv", "SELECT * FROM [Products];", "ExportCsv/expected.csv", ",")]
        public void IsOutputEqualExpected(string databaseFile, string outputFile, string query, string expectedFile, string separator)
        {
            ExportCsvOptions opt = new ExportCsvOptions()
            {
                DatabaseFile = databaseFile,
                OutputFile = outputFile,
                Query = query,
                Separator = separator
            };

            new SqlCompactExport.ExportCsv(opt);

            bool equal = File.ReadLines(expectedFile).SequenceEqual(File.ReadLines(outputFile));

            Assert.IsTrue(equal);
        }
    }
}
