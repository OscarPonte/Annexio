using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Annexio.Models
{
    public class Region
    {
        public string Name { get; set; }
        public long Population { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<string> Subregions { get; set; }


    }
}