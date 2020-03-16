using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data
{
    public class Ders
    {
        public int id { get; set; }
        public string name { get; set; }
        public string descript { get; set; }
        public int[] sinifId { get; set; }
    }
}
