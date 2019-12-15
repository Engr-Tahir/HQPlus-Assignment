using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Hosting;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Task3.WebServiceAPI.Models;

namespace Task3.WebServiceAPI.Controllers {
    public class HotelsController : ApiController  {

        /// <summary>
        /// Gets list of hotel rates for given hotel Id and arrival date
        /// </summary>
        /// <param name="hotelId">hotel id</param>
        /// <param name="arrivalDate">arrival date</param>
        /// <returns></returns>
        public string Get(int hotelId, DateTime arrivalDate)  {
            var requestedHotel = this.GetRequestedHotel(hotelId, arrivalDate);
            return requestedHotel;
        }

        private string GetRequestedHotel(int hotelId, DateTime arrivalDate)  {
            try   {

                var jsonString = (Encoding.UTF8.GetString(Properties.Resources.task_3___hotelsrates));
                if (!string.IsNullOrWhiteSpace(jsonString))
                {
                    var obj = HotelParser.Hotels.FromJson(jsonString);
                    if (obj != null)
                    {
                        var hotel = obj.FirstOrDefault(x => x.Hotel.HotelId == hotelId);
                        if (hotel != null)
                        {
                            hotel.HotelRates = hotel.HotelRates.Where(x => x.TargetDay.Value.Date == arrivalDate.Date).ToList<HotelParser.HotelRate>();
                            return Newtonsoft.Json.JsonConvert.SerializeObject(hotel);
                        }
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.InnerException.ToString());
            }
            return null;
        }

    }
}
