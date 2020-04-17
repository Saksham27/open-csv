using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;
using LumenWorks.Framework.IO.Csv;

namespace OpenCSV
{
    class CsvDataToFile
    {
        /// <summary>
        /// method to write data to csv file
        /// </summary>
        public static void WriteData()
        {
            // list of data to be added to csv file
            List<Poco> data = new List<Poco>()
            {
                new Poco {StateName= "London", Population = 23333, AreaInSqKm = 1230000, DensityPerSqKm = 230 },
                new Poco {StateName= "Arizona", Population = 123432, AreaInSqKm = 230000, DensityPerSqKm = 180 }
            };

            try
            {
                using CsvWriter csvWriter = new CsvWriter(new StreamWriter(@"C:\Users\Saksham\source\repos\OpenCSV\StateCensusData.csv", append: true), CultureInfo.InvariantCulture);

                csvWriter.Configuration.HasHeaderRecord = true;
                csvWriter.Configuration.AutoMap<Poco>();
                csvWriter.WriteRecords(data);
                csvWriter.Flush();
            }
            catch (FileNotFoundException file_not_found)
            {
                throw new Exception(file_not_found.FileName);
            }
        }

    }
}
