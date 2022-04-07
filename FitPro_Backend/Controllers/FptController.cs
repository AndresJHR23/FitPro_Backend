using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitPro_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [EnableCors()]
    public class FptController : ControllerBase
    {

        [HttpGet]
        public ActionResult Get()
        {
            using (Models.FitProTrackerContext db = new Models.FitProTrackerContext())
            {
                var lst = (from d in db.Customer
                           select d).ToList();

                return Ok(lst);
            }


        }
        [HttpPost]


        public ActionResult Post([FromBody] Models.request.CustomerRequest model)
        {
            using (Models.FitProTrackerContext db = new Models.FitProTrackerContext())
            {
                Models.Customer oCustomer = new Models.Customer();
              
                oCustomer.Name = model.name;
                oCustomer.Phone = model.phone;
                oCustomer.Email = model.email;
                oCustomer.Notes = model.notes;

                db.Customer.Add(oCustomer);

                db.SaveChanges();

            }

            return Ok();
        }


        [HttpDelete]


        public ActionResult Delete([FromBody] Models.request.CustomerRequest model)
        {
            using (Models.FitProTrackerContext db = new Models.FitProTrackerContext())
            {
                Models.Customer oCustomer = db.Customer.Find(model.id);
                db.Customer.Remove(oCustomer);
                db.SaveChanges();

            }

            return Ok();
        }



    }
}
