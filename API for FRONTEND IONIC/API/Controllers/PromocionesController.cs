using API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PromocionesController : ApiController
    {
        // GET api/<controller>
        HBEntities hb = new HBEntities();
        // GET api/<controller>
        public List<object> Get()
        {
            ObjectResult<getPromociones_Result> lista = hb.getPromociones();
            return lista.ToList<object>();
        }

        // GET api/<controller>/5
        public object Get(int id)
        {
            ObjectResult<PromocionEspecifica_Result> lista = hb.PromocionEspecifica(id);
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