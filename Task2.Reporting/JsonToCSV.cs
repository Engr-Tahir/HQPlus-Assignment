using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using CsvHelper;
using Newtonsoft.Json;

namespace Task2.Reporting
{
    public class JsonToCSV
    {
        public string JsonString { get; private set; }
        public JsonToCSV(string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString))
                throw new ArgumentNullException("jsonString");

            this.JsonString = jsonString;
        }

        private List<CsvOutput> ConvetToList()
        {
            RootObject hotels;
            try
            {
                hotels = JsonConvert.DeserializeObject<RootObject>(JsonString);
            }
            catch (Exception ex)
            {
                throw;
            }

            if (hotels != null)
            {
                List<CsvOutput> output = new List<CsvOutput>();

                foreach (var rate in hotels.hotelRates)
                {
                    try
                    {

                        var record = new CsvOutput();
                        record.ArrivalDate = rate.targetDay;
                        record.DepartureDate = rate.targetDay;

                        if (rate.price != null)
                        {
                            record.Price = rate.price.numericFloat;
                            record.Currency = rate.price.currency;
                        }
                        record.RateName = rate.rateName;
                        record.Adults = rate.adults;
                        if (rate.rateTags != null)
                        {
                            if (rate.rateTags.FirstOrDefault() != null)
                            {
                                record.Breakfast_Included = rate.rateTags.FirstOrDefault().shape ? 1 : 0;
                            }
                        }
                        output.Add(record);

                    }
                    catch (Exception ex)
                    {

                        Debug.WriteLine(ex);
                    }
                }
                return output;
            }
            return null;
        }

        public bool ExportTo(string filename)
        {
            try
            {
                var output = this.ConvetToList();

                if (output != null && output.Count > 0)
                {
                    using (var writer = new StreamWriter(filename))
                    {
                        using (var csv = new CsvWriter(writer))
                        {
                            csv.WriteRecords(output);

                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
            }
            return false;
        }
    }
}
