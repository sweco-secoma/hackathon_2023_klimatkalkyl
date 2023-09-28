using System;
using System.Collections.Generic;
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
    }
}
