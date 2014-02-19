﻿using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eManager.Web.ViewModels;
using eManager.Web.DAL.Repository;
using eManager.Web.DAL;
using System.Net;

namespace eManager.Web.Controllers
{
    public abstract class GenericController<T> :Controller
       // where T : class
       // where TRepo : IDepartmentRepository, new()
    {
        private IRepository<T> repository;

        public GenericController(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual ActionResult Index()
        {
            var model = this.repository.FindAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T @entity = this.repository.FindById(id);
            if (@entity == null)
            {
                return HttpNotFound();
            }
            return View(@entity);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Bind(Include = "Field1,Field2,Field3")] 
        public ActionResult Create(T @entity)
        {
            if (ModelState.IsValid)
            {
                this.repository.Add(@entity);
                this.repository.Save();
                return RedirectToAction("Index");
            }

            return View(@entity);
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T @entity = this.repository.FindById(id);
            if (@entity == null)
            {
                return HttpNotFound();
            }
            return View(@entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(T @entity)
        {
            if (ModelState.IsValid)
            {
                this.repository.Update(entity);
                this.repository.Save();

                return RedirectToAction("Index");
            }
            return View(@entity);
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T entity = this.repository.FindById(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T entity = this.repository.FindById(id);
            this.repository.Remove(entity);
            this.repository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
