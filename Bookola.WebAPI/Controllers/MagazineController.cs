using Bookola.Models.Magazine;
using Bookola.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bookola.WebAPI.Controllers
{
    public class MagazineController : ApiController
    {

        private MagazineService CreateMagazineService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var magazineService = new MagazineService(userId);
            return magazineService;
        }
        public IHttpActionResult Get()
        {
            MagazineService magazineService = CreateMagazineService();
            var magazines = magazineService.GetMagazines();
            return Ok(magazines);
        }
        public IHttpActionResult Post(MagazineCreate magazine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateMagazineService();
            if (!service.CreateMagazine(magazine))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            MagazineService magazineService = CreateMagazineService();
            var magazine = magazineService.GetMagazineById(id);
            return Ok(magazine);
        }
        public IHttpActionResult Put(MagazineEdit note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateMagazineService();
            if (!service.UpdateMagazines(note))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateMagazineService();
            if (!service.DeleteMagazine(id))
            {
                return InternalServerError();
            }
            return Ok();
        }

    }
}


