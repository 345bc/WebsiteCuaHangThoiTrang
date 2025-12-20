using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ESHOPPER.Models;

namespace ESHOPPER.Controllers
{
    public class CategoryAPIController : ApiController
    {
        private QlyFashionShopEntities db = new QlyFashionShopEntities();

        public CategoryAPIController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        public IQueryable<DanhMucSanPham> GetDanhMucSanPhams()
        {
            return db.DanhMucSanPhams;
        }

        [ResponseType(typeof(DanhMucSanPham))]
        public IHttpActionResult GetDanhMucSanPham(int id)
        {
            DanhMucSanPham danhMucSanPham = db.DanhMucSanPhams.Find(id);
            if (danhMucSanPham == null)
            {
                return NotFound();
            }

            return Ok(danhMucSanPham);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutDanhMucSanPham(int id, DanhMucSanPham danhMucSanPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != danhMucSanPham.MaDM)
            {
                return BadRequest();
            }

            db.Entry(danhMucSanPham).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DanhMucSanPhamExists(id))
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

        [ResponseType(typeof(DanhMucSanPham))]
        public IHttpActionResult PostDanhMucSanPham(DanhMucSanPham danhMucSanPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DanhMucSanPhams.Add(danhMucSanPham);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DanhMucSanPhamExists(danhMucSanPham.MaDM))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = danhMucSanPham.MaDM }, danhMucSanPham);
        }

        [ResponseType(typeof(DanhMucSanPham))]
        public IHttpActionResult DeleteDanhMucSanPham(int id)
        {
            DanhMucSanPham danhMucSanPham = db.DanhMucSanPhams.Find(id);
            if (danhMucSanPham == null)
            {
                return NotFound();
            }

            db.DanhMucSanPhams.Remove(danhMucSanPham);
            db.SaveChanges();

            return Ok(danhMucSanPham);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DanhMucSanPhamExists(int id)
        {
            return db.DanhMucSanPhams.Count(e => e.MaDM == id) > 0;
        }
    }
}