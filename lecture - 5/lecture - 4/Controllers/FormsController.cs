using Microsoft.AspNetCore.Mvc;
using lecture___4.Models;
using lecture___4.DbModels;
using Newtonsoft.Json;

namespace lecture___4.Controllers
{

    //Microsoft.EntityFrameworkCore
    //Microsoft.EntityFrameworkCore.SqlServer
    //Microsoft.EntityFrameworkCore.Tools

    //tools > nuget package manager > package manager console

    //Scaffold-DbContext "Server=DESKTOP-ULH4M26;Database=WebUsers;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DbModels
    public class FormsController : Controller
    {
        public IActionResult Index()
        {
            WebUser myUser = LoadUserFromDatabase();
            return View(myUser);
        }

        [Route("/ModelBinding/Update")]
        public IActionResult UpdateFromOldSchoolForm()
        {
            WebUser webUser = LoadUserFromDatabase();

            webUser.FirstName = Request.Form["txtFirstName"];
            webUser.LastName = Request.Form["txtLastName"];

            if (myContext.TblUsers.Find(webUser.UserId) == null)
            {
                myContext.TblUsers.Add(webUser);
            }

            myContext.SaveChanges();

            return Content("User updated!");
        }

        WebUsersContext myContext = new WebUsersContext();

        private WebUser LoadUserFromDatabase()
        {
            var vrUser = myContext.TblUsers.OrderByDescending(u => u.UserId).Take(1);
            if (vrUser.Count() == 0)
                return new WebUser();

            WebUser ggUser = vrUser.FirstOrDefault() as WebUser;

            return new WebUser(vrUser.FirstOrDefault());
        }

        [Route("/ModelBinding/Add")]
        [HttpPost]
        public IActionResult AddToDb()
        {
            WebUser webUser = new WebUser();

            webUser.FirstName = Request.Form["FirstName"];
            webUser.LastName = Request.Form["LastName"];



            myContext.TblUsers.Add(webUser);


            myContext.SaveChanges();

            return Content("User added!");
        }

        [Route("/ModelBinding/Add2")]
        [HttpPost]
        public IActionResult AddToDb2(WebUser myUser)
        {
            if (ModelState.IsValid == false)
            {
                //TempData is session based 
                //get key(s) and error message(s) from the ModelState
                //var serializableModelState = new SerializableError(ModelState);

                ////convert to a string
                //var modelStateJson = JsonConvert.SerializeObject(serializableModelState);

                //myUser.srSerializedModelState = modelStateJson;
                //TempData.Put("savedUser", myUser);
                
                //return RedirectToAction("Index", "Home");

                //return RedirectToAction("IndexWithModel", "Home", myUser);
                return View("/Views/Home/Index.cshtml",myUser);
            }

            myUser.setDBVAlues();
            myContext.TblUsers.Add(myUser);


            myContext.SaveChanges();

            return Content("User added!");
        }
    }
}
