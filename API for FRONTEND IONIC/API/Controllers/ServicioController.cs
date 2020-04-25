using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Http.Cors;
using System.Data.Entity.Core.Objects;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ServicioController : ApiController
    {
        HBEntities hb = new HBEntities();
        // GET api/<controller>
        public List<object> Get()
        {
            ObjectResult<getServicios_Result> lista = hb.getServicios();
            return lista.ToList<object>();
        }

        // GET api/<controller>/5
        public object Get(int id)
        {
            ObjectResult<ServicioEspecifico_Result> lista = hb.ServicioEspecifico(id);
            return lista.ToList<object>().First();
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}