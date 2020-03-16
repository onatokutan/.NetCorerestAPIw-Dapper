using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace Api.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly IOgrenciProvider ogrenciPvider;
        private readonly IOgrenciProcessor ogrenciPces;

        public OgrenciController(IOgrenciProvider ogrenciPvider, IOgrenciProcessor ogrenciPces)
        {
            this.ogrenciPvider = ogrenciPvider;
            this.ogrenciPces = ogrenciPces;
        }
        [EnableCors]
        [HttpPost("api/ogrenci/getir")]
        public IEnumerable<Ogrenci> Get()
        {
            return ogrenciPvider.Get();
        }
        [EnableCors]
        [HttpGet("{id}", Name = "GetOgrenci")]
        public string Get(int id)
        {
            return "value";
        }

        [EnableCors]
        [HttpPost("api/ogrenci/ekle")]
        public bool Post([FromBody]Ogrenci ogrenci)
        {
            int ogrenciID = ogrenciPces.EkleOgrenci(ogrenci);
            ogrenciPces.OgrenciDersEkle(ogrenciID, ogrenci);
            return true;
        }


        [EnableCors]
        [HttpPut("api/ogrenci/guncelle")]
        public void Put(int id, [FromBody]Ogrenci ogrenci)
        {
            ogrenci.id = id;
            ogrenciPces.GuncelleOgrenci(ogrenci);
        }

        [EnableCors]
        [HttpDelete("api/ogrenci/sil")]
        public void Delete(int id)
        {
            ogrenciPces.SilOgrenci(id);
        }
    }
}