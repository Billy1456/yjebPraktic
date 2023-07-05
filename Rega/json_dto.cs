using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rega
{
    public class json_dto
    {
        public string Departure_city { get; set; }
        public string Departure_city_code { get; set; }
        public string City_of_arrival { get; set; }
        public string City_of_arrival_code { get; set; }
        public DateTime Arrival_time { get; set; }
        public DateTime Dparture_time { get; set; }
        public int Price { get; set; }
    }
}
