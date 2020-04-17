using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LumenWorks.Framework.IO.Csv;

namespace OpenCSV
{
    class Poco
    {
        public string StateName { get; set; }
        public int Population { get; set; }
        public int AreaInSqKm { get; set; }
        public int DensityPerSqKm { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public Poco()
        {

        }

        /// <summary>
        /// parameterized constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="population"></param>
        /// <param name="area"></param>
        /// <param name="density"></param>
        public Poco(string name, int population, int area, int density)
        {
            this.StateName = name;
            this.Population = population;
            this.AreaInSqKm = area;
            this.DensityPerSqKm = density;
        }

    }

    public class PocoCsvToBean
    {
        public void PocoCsv()
        {
            try
            {
                //read csv file
                using CsvReader csv = new CsvReader(new StreamReader(File.OpenRead(@"C:\Users\Saksham\source\repos\OpenCSV\StateCensusData.csv")), true);

                int fieldCount = csv.FieldCount;
                List<Poco> data = new List<Poco>();

                // mapping the csv file data to Poco object and adding it to data list
                while (csv.ReadNextRecord())
                {
                    Poco pocoObject = new Poco(csv[0], Int32.Parse(csv[1]), Int32.Parse(csv[2]), Int32.Parse(csv[3]));
                    data.Add(pocoObject);
                }

                // printing the csv file data
                foreach(Poco record in data)
                {
                    Console.WriteLine($"State : {record.StateName}\n Population : {record.Population}\n Area : {record.AreaInSqKm}\n Density : {record.DensityPerSqKm}");
                    Console.WriteLine();
                }
            }
            catch(FileNotFoundException file_not_found)
            {
                throw new Exception(file_not_found.FileName);
            }
        }
    }
}
