using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcSix.Models;

namespace mvcSix.Controllers
{
    public class UserController : Controller
    {
        public readonly JwtdbContext _jwtdbContext;
        public UserController(JwtdbContext jwtdbContext)
        {
            _jwtdbContext = jwtdbContext;
        }
        [Authorize]
        public IActionResult Index()
        {
            var res = _jwtdbContext.Users.ToList();
            return View(res);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            var res = _jwtdbContext.Users.Add(user);
            _jwtdbContext.SaveChanges();
            return Redirect("Index");
        }

        //[Route("/edit")]
        public IActionResult Edit(int id)
        {
            var res = _jwtdbContext.Users.Find(id);
            return View(res);
        }

        public async Task<IActionResult> Update(User user) 
        {
            var isUserExist = await _jwtdbContext.Users.FindAsync(user.UserId);
            if (isUserExist != null)
            {

                //_jwtdbContext.ChangeTracker.Clear();
                //_jwtdbContext.Entry(user).State = EntityState.Modified;
                _jwtdbContext.Users.Update(user);
                await _jwtdbContext.SaveChangesAsync();
            }
            return Redirect("Index");
        }
    }
}
