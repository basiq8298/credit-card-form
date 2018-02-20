using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;
using WebApplication8.ViewModel;
namespace WebApplication8.Controllers
{
    public class joinController : Controller
    {
        private readonly UserDBContext _context;

        public joinController(UserDBContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
            
        }

        public IActionResult join(int ? id)
        {
            List<UserjoinCard> joinData = (from u in _context.User
                                           join c in _context.Cards
                                           on u.UserId equals c.UserId
                                           where u.UserId == id
                                           select new { u, c }).Select(r => new UserjoinCard
                                           { user = r.u ,
                                             cards =r.c} ).ToList();

            
            return View(joinData);
        }
    }

}