using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeApp.Data;
using EmployeeApp.Data.Models;
using EmployeeApp.Middleware;

namespace EmployeeApp.Controllers
{
    public class AddressesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IRepositoryWrapper _repoWrapper;

        public AddressesController(ApplicationDbContext context, IRepositoryWrapper repoWrapper)
        {
            _context = context;
            _repoWrapper = repoWrapper;
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            var data = _repoWrapper.Address.FindAll().Include(a => a.Employee);
            return View(await data.ToListAsync());
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _repoWrapper.Address.FindByCondition(m => m.Id == id).FirstOrDefaultAsync();
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Address address)
        {
            if (ModelState.IsValid)
            {
                _repoWrapper.Address.Create(address);
                _repoWrapper.Save();
                return RedirectToAction(nameof(Index), "Employees");
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", address.EmployeeId);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _repoWrapper.Address.FindByCondition(m => m.Id == id).FirstOrDefaultAsync();
            if (address == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", address.EmployeeId);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Street,City,State,Country,Zipcode,EmployeeId")] Address address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repoWrapper.Address.Update(address);
                    _repoWrapper.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", address.EmployeeId);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var address = await _repoWrapper.Address.FindByCondition(m => m.Id == id).FirstOrDefaultAsync();
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _repoWrapper.Address.FindByCondition(m => m.Id == id).Include(a => a.Employee).FirstOrDefaultAsync();
            _repoWrapper.Address.Delete(address);
            _repoWrapper.Save();
            return RedirectToAction(nameof(Index), "Employees");
        }

        private bool AddressExists(int id)
        {
            return _repoWrapper.Address.FindByCondition(e => e.Id == id).Any();
        }
    }
}
