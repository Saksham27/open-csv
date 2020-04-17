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

                while (csv.ReadNextRecord())
                {
                    Poco pocoObject = new Poco(csv[0], Int32.Parse(csv[1]), Int32.Parse(csv[2]), Int32.Parse(csv[3]));
                    data.Add(pocoObject);
                }

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
