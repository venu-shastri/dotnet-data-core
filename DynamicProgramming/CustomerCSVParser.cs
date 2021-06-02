using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class CSVParser
    {
        public string FilePath { get; set; }
        public IEnumerable<CSVLine> GetAllLines()
        {
            System.IO.StreamReader _reader = new System.IO.StreamReader(FilePath);
            List<CSVLine> lines = new List<CSVLine>();
           CSVLine.HeaderContent= _reader.ReadLine().Split(',').ToList();
            while (!_reader.EndOfStream)
            {
                string line=_reader.ReadLine();
                string[] lineContent = line.Split(',');
                CSVLine _lineObj = new CSVLine() { LineContent = lineContent };
                lines.Add(_lineObj);
            }
            return lines;
            
        }
    }
}
