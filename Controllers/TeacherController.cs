using CUMULITATIVE_ASSIGN_1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUMULITATIVE_ASSIGN_1.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        //GET : /Teachers/List
        public ActionResult List(string SearchKey = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
            return View(Teachers);
        }

        //GET : /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);

        }
        //GET : /Teacher/New
        public ActionResult New()
        {
            return View();
        }
        //POST : /Teacher/Create
        [HttpPost]
        public ActionResult Create(string teacherfname, string teacherlname,  string employeenumber ,DateTime hiredate )
        {
            //Identify that this method is running
            //Identify the inputs provided from the form

            Debug.WriteLine("I have accesse");
            Debug.WriteLine(teacherfname);
            

            Teacher NewTeacher = new Teacher();
            NewTeacher.teacherfname = teacherfname;
            NewTeacher.teacherlname = teacherlname;
            
            NewTeacher.employeenumber = employeenumber;
            NewTeacher.hiredate = hiredate;
            
            

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }


        //GET : /Teacher/DeleteSelected/{id}
        public ActionResult DeleteSelected (int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }






        //POST : /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }


        //GET : /Teacher/Ajax_Method
        public ActionResult Ajax_Method()
        {
            return View();

        }



    }
}