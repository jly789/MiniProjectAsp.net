using AspnetCoreStudy.DataContext;
using AspnetCoreStudy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace AspnetCoreStudy.Controllers
{
    public class NoteController : Controller
    {



        public IActionResult Index(int pg = 1)
        {



            using (var db = new AspnetNoteDbContext())
            {

                //SELECT 쿼리
                // List<Note> selectList = db.Notes.ToList().Where().OrderBy();

                //특정 데이터 1개 가져오기
                // var user = db.Users.FirstOrDefault(u => u.UserId == 1);
                // -> SELECT TOP 1 * FROM Users WHERE UserId = 1;

                //WHERE 절 사용
                // SELECT * FROM Users WHERE UserName = "임길동";
                //방법1 var list = db.Users.Where(u=> u.UserName == "임길동");
                //방법2 var list = db.Users.Where(u=> u.UserName.equlas("임길동"));

                //OrderBy 절 사용
                // var list = db.Users.OrderBy(u=> u.UserName).ToList(); 오름차순
                // var list = db.Users.OrderByDescending(u=> u.UserName).ToList(); 내림차순


                //조인문 사용

                // var list = db.Users.Include(u=>u.Position).ToList();

                // foreach ( var user in list){
                // console.WriteLine($"{user.UserId},{user.UserName}, {user.Position.PositionName}");
                //



                var list = db.Notes.ToList();

                const int pageSize = 3;
                if (pg < 1)
                    pg = 1;

                int recsCount = list.Count();

                var pager = new Pager(recsCount, pg, pageSize);

                int recSkip = (pg - 1) * pageSize;

                var data = list.Skip(recSkip).Take(pager.PageSize).ToList();

                this.ViewBag.Pager = pager;

                Console.WriteLine("테스트2");

                Console.BackgroundColor = ConsoleColor.Green;
                return View(data);
            }



        }



        public IActionResult Add()
        {
            if (HttpContext.Session.GetInt32("UserNo") == null)
            {

                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Add(Note model)
        {

            if (ModelState.IsValid)
            {



                model.UserNo = int.Parse(HttpContext.Session.GetInt32("UserNo").ToString());


                using (var db = new AspnetNoteDbContext())

                {


                    db.Notes.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
            }

            ModelState.AddModelError(string.Empty, "제목 또는 내용이 올바르지 않습니다.");

            return View(model);
        }




        public ActionResult Detail(int NoteNo)
        {

            using (var db = new AspnetNoteDbContext())
            {

                var note = db.Notes.FirstOrDefault(x => x.NoteNo.Equals(NoteNo));
                return View(note);
            }



        }

        public ActionResult Update(int NoteNo)
        {

            using (var db = new AspnetNoteDbContext())
            {

                var note = db.Notes.FirstOrDefault(x => x.NoteNo.Equals(NoteNo));
                return View(note);
            }

        }

        [HttpPost]
        public ActionResult Update(Note note)
        {

            if (ModelState.IsValid)
            {

                using (var db = new AspnetNoteDbContext())
                {

                    // 3. UPDATE 쿼리 
                    // 방법1 var user = new User {UserId =1, UserName ="장길동"};
                    //       db.Entry(user).State = EntityState.Modified;
                    //       db.SaveChange();

                    // 방법2. db.Update(user);
                    //        db.SaveChanges();



                    //   var user = new Note { NoteTitle = note.NoteTitle };
                    //  db.Entry(note).State = EntityState.Modified;

                    db.Update(note);
                    db.SaveChanges();
                    //var note = db.Notes.FirstOrDefault(x => x.NoteNo.Equals(NoteNo));
                    return RedirectToAction("index");
                }

            }
            return View(note);
        }


        [HttpPost]
        public ActionResult Delete(Note note)
        {

            using (var db = new AspnetNoteDbContext())
            {

                //4. Delete 쿼리
                // DELETE FROM USER WHERE UserId = 2;
                // var user = new User {UserId = 2};
                // db.User.Remove(user);
                // db.SaveChanges();

                //방법1
                //var noteId = new Note { NoteNo = note.NoteNo };
                //db.Notes.Remove(noteId);
                //db.SaveChanges();

                //방법2
                db.Notes.Remove(note);
                db.SaveChanges();
            }


            return RedirectToAction("index");
        }



    }
}
