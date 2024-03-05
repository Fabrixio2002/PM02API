using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PM02API.Models
{
    public class Posts
    {
        public Name? Name { get; set; }
        public Flags? Flags { get; set; }
        public CapitalInfo? capitalInfo { get; set; }
        public string Region { get; set; }


    }
    public class Name
    {
        public string? Common { get; set; }
        

    }
    public class Flags
    {
        public string? png { get; set; }

    }

    public class CapitalInfo
    {
        public List<double>? latlng { get; set; }
    }

   


}

