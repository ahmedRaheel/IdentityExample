using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Web.Models;
using Bookstore.Web.Services;

namespace Bookstore.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _context;

        public BookController(IBookService context)
        {
            _context = context;
        }

        // GET: Book
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetBooks());
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(long id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookDTO = await _context.GetBookById(id);                
            if (bookDTO == null)
            {
                return NotFound();
            }

            return View(bookDTO);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,PublishYear,Price")] BookDTO bookDTO)
        {
            if (ModelState.IsValid)
            {                
                await _context.AddBook(bookDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(bookDTO);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookDTO = await _context.GetBookById(id);
            if (bookDTO == null)
            {
                return NotFound();
            }
            return View(bookDTO);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title,Description,PublishYear,Price")] BookDTO bookDTO)
        {
            if (id != bookDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateBook(bookDTO);
                }
                catch (Exception)
                {
                    if (!BookDTOExists(bookDTO.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookDTO);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookDTO = await _context.GetBookById(id);
            if (bookDTO == null)
            {
                return NotFound();
            }

            return View(bookDTO);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var bookDTO = await _context.GetBookById(id);
            
            await _context.DeleteBooks(bookDTO.Id); ;
            return RedirectToAction(nameof(Index));
        }

        private bool BookDTOExists(long id)
        {
            return _context.GetBookById(id) == null ? true : false;
        }
    }
}
