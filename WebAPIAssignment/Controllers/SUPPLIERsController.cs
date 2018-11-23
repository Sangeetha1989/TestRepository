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
using WebAPIAssignment.Models;

namespace WebAPIAssignment.Controllers
{
    public class SUPPLIERsController : ApiController
    {
        private PODbEntities db = new PODbEntities();

        // GET: api/SUPPLIERs
        [Route("api/GetSUPPLIERs")]
        public IQueryable<SUPPLIER> GetSUPPLIERs()
        {
            return db.SUPPLIERs;
        }

        // GET: api/SUPPLIERs/5
        [ResponseType(typeof(SUPPLIER))]
        [Route("api/GetSUPPLIER")]
        public IHttpActionResult GetSUPPLIER(string id)
        {
            SUPPLIER sUPPLIER = db.SUPPLIERs.Find(id);
            if (sUPPLIER == null)
            {
                return NotFound();
            }

            return Ok(sUPPLIER);
        }

        // PUT: api/SUPPLIERs/5
        [ResponseType(typeof(void))]
        [Route("api/PutSUPPLIER")]
        public IHttpActionResult PutSUPPLIER(string id, SUPPLIER sUPPLIER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sUPPLIER.SUPLNO)
            {
                return BadRequest();
            }

            db.Entry(sUPPLIER).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SUPPLIERExists(id))
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

        // POST: api/SUPPLIERs
        [ResponseType(typeof(SUPPLIER))]
        [Route("api/PostSUPPLIER")]
        public IHttpActionResult PostSUPPLIER(SUPPLIER sUPPLIER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SUPPLIERs.Add(sUPPLIER);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SUPPLIERExists(sUPPLIER.SUPLNO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sUPPLIER.SUPLNO }, sUPPLIER);
        }

        // DELETE: api/SUPPLIERs/5
        [ResponseType(typeof(SUPPLIER))]
        [Route("api/DeleteSUPPLIER")]
        public IHttpActionResult DeleteSUPPLIER(string id)
        {
            SUPPLIER sUPPLIER = db.SUPPLIERs.Find(id);
            if (sUPPLIER == null)
            {
                return NotFound();
            }

            db.SUPPLIERs.Remove(sUPPLIER);
            db.SaveChanges();

            return Ok(sUPPLIER);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SUPPLIERExists(string id)
        {
            return db.SUPPLIERs.Count(e => e.SUPLNO == id) > 0;
        }
    }
}