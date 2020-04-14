using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LumenWorks.Framework.IO.Csv;

namespace OpenCSV
{
    class CSV
    {
        /// <summary>
        /// main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // read csv file
            using (CsvReader csvReader = new CsvReader(new StreamReader(@"C:\Users\Saksham\source\repos\OpenCSV\StateCensusData.csv"), true))
            {
                // getting no of fields
                int fieldsCount = csvReader.FieldCount;

                // reading the headers in array
                string[] headers = csvReader.GetFieldHeaders();

                string[] recordsInARow = new string[fieldsCount];

                List<string[]> records = new List<string[]>();

                // adding all rows to list
                while (csvReader.ReadNextRecord() != false)
                {
                    csvReader.CopyCurrentRecordTo(recordsInARow);
                    records.Add(recordsInARow);
                    Console.WriteLine(recordsInARow);
                }
            }
        }
    }
}
