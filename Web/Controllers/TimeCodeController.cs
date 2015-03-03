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
        private ITimesheetsContext _context;

        public TimeCodeController()
        {
            _context = new TimesheetsContext();
        }

        public TimeCodeController(ITimesheetsContext context)
        {
            _context = context;
        }

        // GET: /TimeCode/
        public async Task<ActionResult> Index()
        {
            return View(await _context.TimeCodes.ToListAsync());
        }

        // GET: /TimeCode/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeCode timecode = _context.TimeCodes.Find(id);
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
        public ActionResult Create([Bind(Include="Id,Name,Description")] TimeCode timecode)
        {
            if (ModelState.IsValid)
            {
                _context.TimeCodes.Add(timecode);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timecode);
        }

        // GET: /TimeCode/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeCode timecode = _context.TimeCodes.Find(id);
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
        public ActionResult Edit([Bind(Include="Id,Name,Description")] TimeCode timecode)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(timecode).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timecode);
        }

        // GET: /TimeCode/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeCode timecode = _context.TimeCodes.Find(id);
            if (timecode == null)
            {
                return HttpNotFound();
            }
            return View(timecode);
        }

        // POST: /TimeCode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeCode timecode = _context.TimeCodes.Find(id);
            _context.TimeCodes.Remove(timecode);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
