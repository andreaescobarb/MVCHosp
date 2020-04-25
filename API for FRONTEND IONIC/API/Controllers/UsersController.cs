using API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        //[RoutePrefix("api/Users")]
        // GET api/<controller>
        HBEntities hb = new HBEntities();
        public List<object> Get()
        {
            ObjectResult<getUsers_Result> lista = hb.getUsers();
            return lista.ToList<object>();
        }

        // GET api/<controller>/5
        public object Get(int id)
        {
            ObjectResult<UserEspecifico_Result> lista = hb.UserEspecifico(id);

            return lista.ToList<object>().First();
        }

        // POST api/<controller>
        public void Post([FromBody] User user)
        {
            /*  string Correo = value.Correo;
              string Password = value.Password;
              int? Cotizaciones = value.Cotizaciones;
              int? Rol = value.Rol;
              int? Estado = value.Estado;*/
            hb.Users.Add(user);
            hb.SaveChanges();
            // Console.WriteLine(Correo, Password, Cotizaciones, Rol, Estado);
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