using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NuGet.Protocol.Plugins;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDBContext _dbContext;

        public HomeController(ILogger<HomeController> logger, AppDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index(Guid Id)
        {
          // var personal = await _dbContext.Personal.FirstOrDefaultAsync(m =>m.Id == Id);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        //CRUD - create read update delete
        public async Task<IActionResult> CreateSpongeBobFriend()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSpongeBobFriend([Bind("FirstName,LastName,Job,JobPlace,SkinCollor,HomeId")] SpongeBobFriends spongeBobFriends)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Add(spongeBobFriends);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " + "Try again or call system admin");
            }

            return View(spongeBobFriends);
        }

        //Table
        public async Task<IActionResult> TableOfSpongeBobFriend()
        {
            return View(await _dbContext.spongeBobFriends.ToListAsync());
        }


        //Edit or Update


        [HttpPost, ActionName("EditPersonalInformatios")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPostSpongeBobFriend(Guid? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var friendsInformations = await _dbContext.spongeBobFriends.FirstOrDefaultAsync(s => s.Id == Id);


            if (await TryUpdateModelAsync<SpongeBobFriends>(
                friendsInformations, "", s => s.FirstName, s => s.LastName, s => s.Job, s => s.JobPlace, s => s.SkinCollor, s => s.HomeId))
            {
                try
                {
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " + "Try again or call system admin");
                }
            }

            return View(friendsInformations);
        }


        public async Task<IActionResult> EditSpongeBobFriend(Guid Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var person = await _dbContext.spongeBobFriends.FirstOrDefaultAsync(m => m.Id == Id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        //Details
        public async Task<IActionResult> DetailsOfPerseon(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _dbContext.spongeBobFriends.FirstOrDefaultAsync(m => m.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }


        //Delete 
        public async Task<IActionResult> DeleteFriend(Guid id, bool? Savechangeserror = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _dbContext.spongeBobFriends.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            if (Savechangeserror.GetValueOrDefault())
            {
                ViewData["DeleteError"] = "Delete failed, please try again later ... ";
            }

            return View(person);
        }

        //Delete continue
        [HttpPost, ActionName("DeleteFriend")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDeleteFriendSpongeBob(Guid id)
        {
            var friend = await _dbContext.spongeBobFriends.FindAsync(id);

            if (friend == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _dbContext.spongeBobFriends.Remove(friend);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(DeleteFriend), new { id = id, Savechangeserror = true });
            }

            //return View(person);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}