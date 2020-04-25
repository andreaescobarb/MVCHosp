using API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PacientesController : ApiController
    {
        HBEntities hb = new HBEntities();
        public List<object> Get()   //Controlador que la API utiliza procedimiento almacenado getPacientes
        {            
            ObjectResult<getPacientes_Result> lista = hb.getPacientes();
            return lista.ToList<object>();
        }


        // GET api/<controller>/5
        public List<object> Get(string id)
        {
                if (id.ToCharArray()[0] == '-')
              {
                  ObjectResult<getPacienteUsuario_Result> lista = hb.getPacienteUsuario((id.Substring(1)));
                  return lista.ToList<object>();
              }
              else
              {
                  ObjectResult<PacienteEspecifico_Result> lista = hb.PacienteEspecifico(int.Parse(id));
                  return lista.ToList<object>();
              }
        }

        // POST api/<controller>
        public void Post([FromBody]Paciente paciente)
        {
            hb.Pacientes.Add(paciente);
            hb.SaveChanges();
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