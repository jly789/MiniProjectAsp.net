using AspnetCoreStudy.DataContext;
using AspnetCoreStudy.Models;

using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreStudy.Controllers
{
    public class AccountController : Controller
    {
        // GET: AccountController
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {

            if (ModelState.IsValid) {

                using (var db = new AspnetNoteDbContext())
                {



                    var user = db.Members
                        .FirstOrDefault(u => u.UserId.Equals(model.UserId) && u.UserPassword.Equals(model.UserPassword));

                    if (user != null)
                    {
                        HttpContext.Session.SetInt32("UserNo", user.UserNo);
                        return RedirectToAction("LoginOk", "Home");
                    }
                }

                       

            
                }

            ModelState.AddModelError(string.Empty, "사용자 ID 혹은 비밀번호가 올바르지 않습니다.");

            return View(model);
        }


        
   public ActionResult Logout()
        {

            HttpContext.Session.Remove("UserNo");

            return RedirectToAction("index", "Home");
        }

        [HttpGet]
        public ActionResult Register() { 
        
           return View();

        }
        [HttpPost]
        public ActionResult Register(User model)
        {

      
          
            


            if (ModelState.IsValid) {
               
                using (var db = new AspnetNoteDbContext()) { 
                
                db.Members.Add(model);
                    
                    db.SaveChanges();
                }
            return RedirectToAction("Index","Home");
            }

            return View(model);

        }


        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
