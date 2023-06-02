using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TMMapiTest1.Model;
using TMMapiTest1.Models;

namespace TMMapiTest1.Controllers
{
    public class MeetsController : ApiController
    {
        private TheMeetManagerDbEntities db = new TheMeetManagerDbEntities();

        //GET: api/Meets
        public IQueryable<Meets> GetMeets()
        {
            return db.Meets;
        }

        [Route("api/Meets")]
        [ResponseType(typeof(Meets))]
        public IHttpActionResult Meets()
        {
            var meets = db.Meets;
            if (meets == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(meets);
            }
        }

        // GET: api/Meets/5
        [ResponseType(typeof(Meets))]
        public IHttpActionResult GetMeets(int id)
        {
            Meets meets = db.Meets.Find(id);
            if (meets == null)
            {
                return NotFound();
            }

            return Ok(meets);
        }

        // PUT: api/Meets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMeets(int id, Meets meets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meets.Id)
            {
                return BadRequest();
            }

            db.Entry(meets).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Meets
        [ResponseType(typeof(Meets))]
        public IHttpActionResult PostMeets(Meets meets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Meets.Add(meets);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MeetsExists(meets.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = meets.Id }, meets);
        }

        // DELETE: api/Meets/5
        [ResponseType(typeof(Meets))]
        public IHttpActionResult DeleteMeets(int id)
        {
            Meets meets = db.Meets.Find(id);
            if (meets == null)
            {
                return NotFound();
            }

            db.Meets.Remove(meets);
            db.SaveChanges();

            return Ok(meets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MeetsExists(int id)
        {
            return db.Meets.Count(e => e.Id == id) > 0;
        }
    }
}