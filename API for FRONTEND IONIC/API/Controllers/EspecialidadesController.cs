﻿using API.Models;
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
    public class EspecialidadesController : ApiController
    {
        // GET api/<controller>
        HBEntities hb = new HBEntities();
        public List<object> Get()
        {
            ObjectResult<getEspecialidad_Result> lista = hb.getEspecialidad();
            return lista.ToList<object>();
        }

        // GET api/<controller>/5
        public List<object> Get(int id)
        {
            if (id <= 0)
            {
                ObjectResult<getMedicosE_Result> lista = hb.getMedicosE((id * -1));
                return lista.ToList<object>();
            }
            else
            {
                ObjectResult<getEspecialidadEspecifica_Result> lista = hb.getEspecialidadEspecifica(id);
                return lista.ToList<object>();
            }
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