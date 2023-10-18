    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BANGIAY.Data;
using BANGIAY.Models;

namespace BANGIAY.Controllers
{
    public class ItemInfoesController : Controller
    {
        private readonly BANGIAYContext _context;

        public ItemInfoesController(BANGIAYContext context)
        {
            _context = context;
        }

        // GET: ItemInfoes
        public async Task<IActionResult> Index()
        {
              return _context.ItemInfo != null ? 
                          View(await _context.ItemInfo.ToListAsync()) :
                          Problem("Entity set 'BANGIAYContext.ItemInfo'  is null.");
        }

        // GET: ItemInfoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ItemInfo == null)
            {
                return NotFound();
            }

            var itemInfo = await _context.ItemInfo
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (itemInfo == null)
            {
                return NotFound();
            }

            return View(itemInfo);
        }

        // GET: ItemInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemName,Size,Color,StockQuantity,Price,MoreInfo")] ItemInfo itemInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemInfo);
        }

        // GET: ItemInfoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ItemInfo == null)
            {
                return NotFound();
            }

            var itemInfo = await _context.ItemInfo.FindAsync(id);
            if (itemInfo == null)
            {
                return NotFound();
            }
            return View(itemInfo);
        }

        // POST: ItemInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ItemId,ItemName,Size,Color,StockQuantity,Price,MoreInfo")] ItemInfo itemInfo)
        {
            if (id != itemInfo.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemInfoExists(itemInfo.ItemId))
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
            return View(itemInfo);
        }

        // GET: ItemInfoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ItemInfo == null)
            {
                return NotFound();
            }

            var itemInfo = await _context.ItemInfo
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (itemInfo == null)
            {
                return NotFound();
            }

            return View(itemInfo);
        }

        // POST: ItemInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ItemInfo == null)
            {
                return Problem("Entity set 'BANGIAYContext.ItemInfo'  is null.");
            }
            var itemInfo = await _context.ItemInfo.FindAsync(id);
            if (itemInfo != null)
            {
                _context.ItemInfo.Remove(itemInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemInfoExists(string id)
        {
          return (_context.ItemInfo?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
        public IActionResult UserPage()
        {
            var model = _context.ItemInfo.ToList();
            return View(model);
        }
    }
}
