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
using TimesheetPoc.Domain.Interfaces;
using TimesheetPoc.Persistence;

namespace TimesheetPoc.Web.Controllers
{
    public class TimeCodeController : Controller
    {
        private readonly ITimeCodeService _timeCodeService;

        
        public TimeCodeController(ITimeCodeService timeCodeService)
        {
            _timeCodeService = timeCodeService;
        }

        // GET: /TimeCode/
        public async Task<ActionResult> Index()
        {
            return View(_timeCodeService.GetAll());
        }

        // GET: /TimeCode/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeCode timecode = _timeCodeService.GetById(id.Value);
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
                _timeCodeService.Add(timecode);
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
            TimeCode timecode = _timeCodeService.GetById(id.Value);
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
                _timeCodeService.Update(timecode);
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
            TimeCode timecode = _timeCodeService.GetById(id.Value);
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
            _timeCodeService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
