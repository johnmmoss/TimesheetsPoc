using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimesheetPoc.Domain;
using TimesheetPoc.Persistence;

namespace TimesheetPoc.Web.Controllers
{
    public class TimeCodeController : Controller
    {
        private TimesheetsContext db = new TimesheetsContext();

        // GET: /TimeCode/
        public async Task<ActionResult> Index()
        {
            return View(await db.TimeCodes.ToListAsync());
        }

        // GET: /TimeCode/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeCode timecode = await db.TimeCodes.FindAsync(id);
            if (timecode == null)
            {
                return HttpNotFound();
            }
            return View(timecode);
        }

        // GET: /TimeCode/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TimeCode/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Name,Description")] TimeCode timecode)
        {
            if (ModelState.IsValid)
            {
                db.TimeCodes.Add(timecode);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(timecode);
        }

        // GET: /TimeCode/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeCode timecode = await db.TimeCodes.FindAsync(id);
            if (timecode == null)
            {
                return HttpNotFound();
            }
            return View(timecode);
        }

        // POST: /TimeCode/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Name,Description")] TimeCode timecode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timecode).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(timecode);
        }

        // GET: /TimeCode/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeCode timecode = await db.TimeCodes.FindAsync(id);
            if (timecode == null)
            {
                return HttpNotFound();
            }
            return View(timecode);
        }

        // POST: /TimeCode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TimeCode timecode = await db.TimeCodes.FindAsync(id);
            db.TimeCodes.Remove(timecode);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
