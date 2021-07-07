using CrudTest.Context;
using CrudTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace CrudTest.Controllers
{
    public class UsersController : Controller
    {
        readonly CrudTest_DAL dbContext = new CrudTest_DAL();

        // GET: UsersController
        public ActionResult Index()
        {
            List<Users> usersList = dbContext.GetAllUsers().ToList();
            return View(usersList);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            if (id <=0) return NotFound();
            Users users = dbContext.GetUsersById(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Users users)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.CreateUsers(users);
                    return RedirectToAction("Index");
                }
                return View(users);
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0) return NotFound();
            Users users = dbContext.GetUsersById(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind] Users users)
        {
            try
            {
                if (id <= 0) return NotFound();
                if (ModelState.IsValid)
                {
                    dbContext.UpdateUsers(users);
                    return RedirectToAction("Index");
                }
                return View(dbContext);
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0) return NotFound();
            Users users = dbContext.GetUsersById(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: UsersController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                dbContext.DeleteUsers(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
