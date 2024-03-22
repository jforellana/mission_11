using Amazon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Amazon.Models.ViewModels;
using System.Reflection.Emit;

namespace Amazon.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository _repo;
        public HomeController( IBookstoreRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pNum)
        { 
            int pSize = 10;
            var booksData = new ProjectList
            {
                Books = _repo.Books
                .OrderBy(x => x.Title)
                .Skip((pNum - 1) * pSize)
                .Take(pSize),
                PaginationInfo = new PaginationInfo
                {
                    curPage = pNum,
                    iPerPage = pSize,
                    tItems = _repo.Books.Count()
                }
            };
            return View(booksData);
        }
    }
}
