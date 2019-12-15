using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Reporting {
    class Program {
        static async Task Main(string[] args) {
            Console.WriteLine("Exporting file using 'FILE NAME' as parameter");
            string fileName = "task 2 - hotelrates.json";
            string outputFileName = "output.csv";
            if (File.Exists(fileName))   {
                using var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                using var sr = new StreamReader(fs, Encoding.UTF8);
                string jsonText = await sr.ReadToEndAsync();
                if (!string.IsNullOrWhiteSpace(jsonText)) {
                    var convertor = new JsonToCSV(jsonText);
                    convertor.ExportTo(outputFileName);
                    Console.WriteLine("Export successfully with File Name :" + outputFileName);
                    Console.WriteLine("Press any key to exit program.");
                    Console.ReadKey();
                }
                else  {
                    Debug.WriteLine("No contents found in file.");
                }
            }
            else   {
                Debug.WriteLine("File not exist.");
            }

        }
    }
}
