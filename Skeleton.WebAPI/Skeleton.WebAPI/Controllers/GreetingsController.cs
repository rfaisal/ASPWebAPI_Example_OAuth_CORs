using Skeleton.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Skeleton.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
   // [Authorize]
    public class GreetingsController : ApiController
    {
        private static List<Greeting> values = new List<Greeting>();
        // GET api/values
        public Greeting Get()
        {
            return values[0];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            int max = 0;
            for (int i = 0; i < values.Count; i++)
                if (values[i].id > max)
                    max = values[i].id;
            values.Add(new Greeting { id = max+1, content = value});
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i].id == id)
                {
                    values[i].content = value;
                    break;
                }
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i].id == id)
                {
                    values.RemoveAt(i);
                }
            }   
        }
    }
}
