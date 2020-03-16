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
 
    public class SinifController : Controller
    {
        private readonly ISinifProvider sinifPvider;
        private readonly ISinifProcessor sinifPces;

        public SinifController(ISinifProvider sinifPvider,ISinifProcessor sinifPces )
        {
            this.sinifPvider = sinifPvider;
            this.sinifPces = sinifPces;
        }
        [HttpPost("/api/sinif/getir")]
        public IEnumerable<Sinif> Get()
        {
            return sinifPvider.Get();
        }

        [HttpGet("{id}", Name = "GetSinif")]
        public string Get(int id)
        {
            return "value";
        }
        [EnableCors]
        [HttpPost("api/sinif/ekle")]
        public void Post([FromBody]Sinif sinif)
        {
            sinifPces.EkleSinif(sinif);
        }
        [EnableCors]
        [HttpPost("api/sinif/guncelle")]
        public void Put(int id, [FromBody]Sinif sinif)
        {
            sinifPces.GuncelleSinif(sinif);
        }
        [EnableCors]
        [HttpPost("api/sinif/sil")]
        public void Delete(int id)
        {
            sinifPces.SilSinif(id);
        }
    }
}