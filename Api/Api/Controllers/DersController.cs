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
    public class DersController : Controller
    {
        private readonly IDersProvider dersPvider;
        private readonly IDersProcessor dersPces;

        public DersController(IDersProvider dersPvider, IDersProcessor dersPces)
        {
            this.dersPvider = dersPvider;
            this.dersPces = dersPces;
        }
        [HttpPost("api/ders/getir")]
        public IEnumerable<Ders> Get()
        {
            return dersPvider.Get();
        }
        [HttpGet("{id}", Name = "GetDers")]
        public string Get(int id)
        {
            return "value";
        }

        
        [EnableCors]
        [HttpPost("api/ders/ekle")]
        public bool Post([FromBody]Ders ders)
        {
            int dersID = dersPces.EkleDers(ders);
            dersPces.DersSinifEkle(dersID,ders);
            return true;
        }

        [EnableCors]
        [HttpPost("api/ders/guncelle")]
        public void Put(int id, [FromBody]Ders ders)
        {
            ders.id = id;
            dersPces.GuncelleDers(ders);
        }

        [EnableCors]
        [HttpPost("api/ders/sil")]
        public void Delete(int id)
        {
            dersPces.SilDers(id);
        }
    }
}