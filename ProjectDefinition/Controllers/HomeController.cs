using ProjectDefinition.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace ProjectDefinition.Controllers
{
    public class HomeController : Controller
    {
        string filePathProject = ConfigurationManager.AppSettings["projectPath"];
        string filePathService = ConfigurationManager.AppSettings["servicePath"];
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("AllService");
        }

        public ActionResult AddProject()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            

            List<Project> projectlist = new List<Project>();
            if (System.IO.File.Exists(filePathProject))
            {
                projectlist = ProjectHelper.getxmldata<Project>(filePathProject);
            }
                

            projectlist.Add(project);

            ProjectHelper.writexmldata<Project>(projectlist, filePathProject);

            return View("Success");
        }

       

        public ActionResult AllProject()
        {

          

            List<Project> project =ProjectHelper.getxmldata<Project>(filePathProject);

            return View(project);
        }

      

        public ActionResult Service()
        {
            return View();
        }

        
        public ActionResult AddService(string ProjectCode)
        {

            Service service = new Service();
            service.ProjectCode = ProjectCode;

            return View(service);
        }

        [HttpPost]
        public ActionResult AddService(Service service)
        {

            
            List<Service> servicelist = getServiceList();


            servicelist.Add(service);

            ProjectHelper.writexmldata<Service>(servicelist, filePathService);


            return View("Success");
        }


        public ActionResult AllService()
        {

            List<Service> servicelist = getServiceList();
            return View(servicelist);

        }

        [HttpPost]
        public ActionResult GetServiceDetail(string ProjectCode,string ServiceName)
        {
            List<Service> servicelist = getServiceList();

            Service service = servicelist.Where(a => a.ServiceName == ServiceName && a.ProjectCode == ProjectCode).ToList()[0];

            return PartialView("ServiceDetail", service);
        }

        

        public ActionResult Search(string Keyword)
        {
            List<Service> servicelist = getServiceList();
            servicelist = servicelist.Where(a => a.ServiceName.ToLower().Contains(Keyword)).ToList();

            return View("AllService",servicelist);

        }
        private  List<Service> getServiceList()
        {
            
            List<Service> servicelist = new List<Service>();


            if (System.IO.File.Exists(filePathService))
            {
                servicelist = ProjectHelper.getxmldata<Service>(filePathService);
            }

            return servicelist;
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName,string Password)
        {
            if(UserName=="Payment" && Password=="007")
            {
                return RedirectToAction("AllService");
            }
        else
            {
                ViewData["LoginError"] = "Kullanıcı Bilgileri Hatalı";
            }
            return View();
        }
    }
}