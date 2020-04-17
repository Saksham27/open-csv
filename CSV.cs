using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            try
            {
                // read csv file
                using CsvReader csvReader = new CsvReader(new StreamReader(File.OpenRead(@"C:\Users\Saksham\source\repos\OpenCSV\StateCensusData.csv")), true);
                // getting no of fields
                int fieldsCount = csvReader.FieldCount;
                Console.WriteLine(fieldsCount);

                // reading the headers in array
                string[] headers = csvReader.GetFieldHeaders();

                

                List<string[]> records = new List<string[]>();
                int i = 0;
                // adding all rows to list
                while (csvReader.ReadNextRecord())
                {
                    string[] recordsInARow = new string[fieldsCount];

                    csvReader.CopyCurrentRecordTo(recordsInARow);
                    records.Add(recordsInARow);
                    i++;
                }


                // print the records
                foreach (string[] rec in records)
                {
                    Console.WriteLine(String.Join(" ", rec));
                }
            }
            catch (FileNotFoundException file_not_found)
            {
                throw new Exception(file_not_found.FileName);
            }


            CsvDataToFile.WriteData();
        }

        
        }
    }

