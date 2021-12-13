using Bookola.Models.Magazine;
using Bookola.Data;
using Bookola.Models;
using Bookola.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace Bookola.WebAPI.Controllers
{
    [Authorize]
    public class MagazineController : ApiController
    {

        private MagazineService CreateMagazineService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var magazineService = new MagazineService(userId);
            return magazineService;
        }
        [Route("api/Magazine/Create")]
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
            return Ok("Your magazine was added!");
        }
        [Route("api/Magazine/GetAll")]
        public IHttpActionResult Get()
        {
            MagazineService magazineService = CreateMagazineService();
            var magazines = magazineService.GetMagazines();
            return Ok(magazines);
        }
        [Route("api/Magazine/GetById")]
        public IHttpActionResult Get(int id)
        {
            MagazineService magazineService = CreateMagazineService();
            var magazine = magazineService.GetMagazineById(id);
            return Ok(magazine);
        }
        [Route("api/Magazine/GetByTitle")]
        public IHttpActionResult GetByTitle(string title)
        {
            MagazineService magazineService = CreateMagazineService();
            var magazine = magazineService.GetMagazineByTitle(title);
            return Ok(magazine);
        }
        [Route("api/Magazine/GetByVolume")]
        public IHttpActionResult GetMagazineByVolume(int volume)
        {
            MagazineService magazineService = CreateMagazineService();
            var magazine = magazineService.GetMagazineByVolume(volume);
            return Ok(magazine);
        }
        [Route("api/Magazine/GetByIssueDate")]
        public IHttpActionResult GetMagazineByIssueDate(DateTime issue)
        {
            MagazineService magazineService = CreateMagazineService();
            var magazine = magazineService.GetMagazineByIssueDate(issue);
            return Ok(magazine);
        }
        [Route("api/Magazine/GetByGenre")]
        public IHttpActionResult GetMagazineByGenre(MagazineGenre genre)
        {
            MagazineService magazineService = CreateMagazineService();
            var magazine = magazineService.GetMagazineByGenre(genre);
            return Ok(magazine);
        }
        [Route("api/Magazine/Update")]
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
        [Route("api/Magazine/Delete")]
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


