using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceLyC969.Model
{
    public class City
    {
        public int cityId { get; set; }
        public string cityName { get; set; }
        public int countryId { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
    }
}
