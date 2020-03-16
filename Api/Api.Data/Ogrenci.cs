using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data
{
    public class Ogrenci
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int[] dersId { get; set; }
    }
}
