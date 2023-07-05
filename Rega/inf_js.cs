using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rega
{
    public class inf_js
    {
        public string StartCity { get; set; }
        public string StartCityCode { get; set; }
        public string EndCity { get; set; }
        public string EndCityCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Price { get; set; }
        public string SearchToken { get; set; }
    }
}
