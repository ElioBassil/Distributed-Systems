using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Login.Controllers
{
    [Authorize(Roles ="admin")]
    public class AssignController : Controller
    {
        public UserManager<IdentityUser> UserManager { get; set; }
        public RoleManager<IdentityRole> RoleManager { get; set; }

        public AssignController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }
        // GET: AssignController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AssignController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AssignController/Create
        public ActionResult Create()
        {
            ViewData["IdentityUser"] = new SelectList(UserManager.Users.ToList(), "Id", "Email");
            ViewData["IdentityRole"] = new SelectList(RoleManager.Roles.ToList(), "Id", "Name");
            return View();
        }

        // POST: AssignController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(IFormCollection collection)
        {
            try
            {
                var UserId = collection["User"];
                var RoleId = collection["Role"];
                IdentityUser selectedUser = await UserManager.FindByIdAsync(UserId);
                IdentityRole selectedRole = await RoleManager.FindByIdAsync(RoleId);

                await UserManager.AddToRoleAsync(selectedUser, selectedRole.Name);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssignController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AssignController/Edit/5
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

        // GET: AssignController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AssignController/Delete/5
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
