using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.IO.Pipes;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace AspnetCoreStudy.Controllers
{
    public class UploadController : Controller
    {


        private readonly IHostingEnvironment _environment;

        public  UploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

     

        [HttpPost, Route("api/upload")]
        public async Task<IActionResult> ImageUpload(IFormFile file) {

            var path = Path.Combine(_environment.WebRootPath, @"images\upload");


            var fileFullName = file.FileName.Split('.');
            var fileName = $"{Guid.NewGuid()}.{fileFullName[1]}";

          //  Console.WriteLine(fileFullName);
          //  Console.WriteLine(fileName);

         //   HttpContext.Session.SetString("fileName", fileName);
            //HttpContext.Session.SetString("filePath", "/images/upload/" + fileName);


            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create)) 
            {
                await file.CopyToAsync(fileStream);
            }
          
           

            return Ok(new { file = "/images/upload/" + fileName, success = true });

         
        }





        // GET: UploadController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UploadController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UploadController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UploadController/Create
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

        // GET: UploadController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UploadController/Edit/5
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

        // GET: UploadController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UploadController/Delete/5
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
