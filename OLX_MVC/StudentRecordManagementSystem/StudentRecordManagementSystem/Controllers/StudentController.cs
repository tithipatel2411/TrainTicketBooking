﻿using StudentRecordManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StudentRecordManagementSystem.Controllers
{
    public class StudentController : Controller
    {

        StudentDataAccessLayer studentDataAccessLayer = null;
        public StudentController()
        {
            studentDataAccessLayer = new StudentDataAccessLayer();
        }
        // GET: Student  
        public ActionResult Index()
        {
            //StudentDataAccessLayer std = new StudentDataAccessLayer();
            List<Student> students = studentDataAccessLayer.GetAllStudent();
            return View(students);
        }
        

        // GET: Student/Create  
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                // TODO: Add insert logic here  
                studentDataAccessLayer.AddStudent(student);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Student/Edit/5  
        public ActionResult Edit(int id)
        {
            Student student = studentDataAccessLayer.GetStudentData(id);
            return View(student);
        }

        // POST: Student/Edit/5  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                // TODO: Add update logic here  
                studentDataAccessLayer.UpdateStudent(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5  
        public ActionResult Delete(int id)
        {
            Student student = studentDataAccessLayer.GetStudentData(id);
            return View(student);
        }

        // POST: Student/Delete/5  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Student student)
        {
            try
            {
                // TODO: Add delete logic here  
                studentDataAccessLayer.DeleteStudent(student.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            Student student = studentDataAccessLayer.GetStudentData(id);
            return View(student);
        }
    }
}
