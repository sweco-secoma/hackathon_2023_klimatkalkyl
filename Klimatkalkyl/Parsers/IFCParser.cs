using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klimatkalkyl.Parsers
{
    internal class IFCParser
    {
        public IFCParser() 
        { 
        }

        public string ParseIFCFile(string pathToIFCFile)
        {
            using (StreamReader reader = new StreamReader(pathToIFCFile))
            {
                string ifc_file = reader.ReadToEnd();
                return ifc_file;
            }

            return null;
        }

        public static double AddAllConcreteVolumes(string IFCFile, List<string> matches)
        {
            List<string> ifc_rows = IFCFile.Split("\n").ToList<string>();
            var matchedRows = ifc_rows.Where(row => matches.Any(match => row.Contains(match)));

            List<string> concreteNumbers = new List<string>();
            foreach (string matchedRow in matchedRows)
            {
                string[] splitedString = matchedRow.Split("(#");
                var rawNumbers = splitedString.Last();
                rawNumbers = rawNumbers.Replace(")", string.Empty);
                rawNumbers = rawNumbers.Replace(";", string.Empty);
                rawNumbers = rawNumbers.Replace("#", string.Empty);
                string[] numbers = rawNumbers.Split(",");
                concreteNumbers.AddRange(numbers);
            }

            double volume = 0;
            foreach (string number in concreteNumbers)
            {
                var matchedNumberRows = ifc_rows.Where(x => x.StartsWith("#" + number));
                foreach (string matchedNumberRow in matchedNumberRows)
                {
                    if (matchedNumberRow.ToLower().Contains("volume"))
                    {
                        string parsedDouble = new string(matchedNumberRow.Split("VOLUME")[1].Where(c => char.IsNumber(c) || c == '.').ToArray());
                        parsedDouble = parsedDouble.Remove(7);
                        parsedDouble = parsedDouble.Replace(".", ",");
                        volume += double.Parse(parsedDouble, NumberStyles.AllowDecimalPoint);
                    }
                }
            }

            return volume;
        }
    }
}
