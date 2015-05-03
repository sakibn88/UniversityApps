using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UniversityApps.Models;

namespace UniversityApps.Controllers
{
    public class RoomAllocationsController : Controller
    {
        private UniversityDBcontext db = new UniversityDBcontext();

        // GET: /RoomAllocations/
        public ActionResult Index()
        {
            var roomallocations = db.RoomAllocations.Include(r => r.Course).Include(r => r.Day).Include(r => r.Department).Include(r => r.Room);
            return View(roomallocations.ToList());
        }

        // GET: /RoomAllocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomAllocation roomallocation = db.RoomAllocations.Find(id);
            if (roomallocation == null)
            {
                return HttpNotFound();
            }
            return View(roomallocation);
        }

        // GET: /RoomAllocations/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code");
            ViewBag.DayId = new SelectList(db.Days, "DayId", "Name");
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code");
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "Name");
            return View();
        }

        // POST: /RoomAllocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="RoomAllocationId,DepartmentId,CourseId,RoomId,DayId,StartTime,EndTime")] RoomAllocation roomallocation)
        {
            if (ModelState.IsValid)
            {
                db.RoomAllocations.Add(roomallocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", roomallocation.CourseId);
            ViewBag.DayId = new SelectList(db.Days, "DayId", "Name", roomallocation.DayId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code", roomallocation.DepartmentId);
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "Name", roomallocation.RoomId);
            return View(roomallocation);
        }

        // GET: /RoomAllocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomAllocation roomallocation = db.RoomAllocations.Find(id);
            if (roomallocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", roomallocation.CourseId);
            ViewBag.DayId = new SelectList(db.Days, "DayId", "Name", roomallocation.DayId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code", roomallocation.DepartmentId);
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "Name", roomallocation.RoomId);
            return View(roomallocation);
        }

        // POST: /RoomAllocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="RoomAllocationId,DepartmentId,CourseId,RoomId,DayId,StartTime,EndTime")] RoomAllocation roomallocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomallocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", roomallocation.CourseId);
            ViewBag.DayId = new SelectList(db.Days, "DayId", "Name", roomallocation.DayId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code", roomallocation.DepartmentId);
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "Name", roomallocation.RoomId);
            return View(roomallocation);
        }

        // GET: /RoomAllocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomAllocation roomallocation = db.RoomAllocations.Find(id);
            if (roomallocation == null)
            {
                return HttpNotFound();
            }
            return View(roomallocation);
        }

        // POST: /RoomAllocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomAllocation roomallocation = db.RoomAllocations.Find(id);
            db.RoomAllocations.Remove(roomallocation);
            db.SaveChanges();
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
