using System;
using System.Collections.Generic;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace Task2.Reporting {

    public class CsvOutput {

        [Name("ARRIVAL_DATE")]
        public DateTime ArrivalDate { get; set; }
        [Name("DEPARTURE_DATE")]
        public DateTime DepartureDate { get; set; }
        [Name("PRICE")]
        public double Price { get; set; }
        [Name("CURRENCY")]
        public string Currency { get; set; }
        [Name("RATENAME")]
        public string RateName { get; set; }
        [Name("ADULTS")]
        public int Adults { get; set; }
        [Name("BREAKFAST_INCLUDED")]
        public int Breakfast_Included { get; set; }
    }

    public class Hotel {
        public int classification { get; set; }
        public int hotelID { get; set; }
        public string name { get; set; }
        public double reviewscore { get; set; }
    }

    public class Price {
        public string currency { get; set; }
        public double numericFloat { get; set; }
        public int numericInteger { get; set; }
    }

    public class RateTag {
        public string name { get; set; }
        public bool shape { get; set; }
    }

    public class HotelRate  {
        public int adults { get; set; }
        public int los { get; set; }
        public Price price { get; set; }
        public string rateDescription { get; set; }
        public string rateID { get; set; }
        public string rateName { get; set; }
        public List<RateTag> rateTags { get; set; }
        public DateTime targetDay { get; set; }
    }

    public class RootObject  {
        public Hotel hotel { get; set; }
        public List<HotelRate> hotelRates { get; set; }
    }
}