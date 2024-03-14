using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BranchRegister.Data;
using BranchRegister.Models;

namespace BranchRegister.Controllers
{
    public class TBranchesController : Controller
    {
        private readonly BranchRegisterContext _context;

        public TBranchesController(BranchRegisterContext context)
        {
            _context = context;
        }

        // GET: TBranches
        public async Task<IActionResult> Index()
        {
            return View(await _context.TBranch.ToListAsync());
        }

        // GET: TBranches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBranch = await _context.TBranch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tBranch == null)
            {
                return NotFound();
            }

            return View(tBranch);
        }

        // GET: TBranches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TBranches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ActiveStatus,LanguageId,RecordStatus,CreatedBy,ModifiedBy,CreatedByName,ModifiedByName,Notation,CreatedDate,ModifiedDate,BranchName,BranchType,BranchTypeName,MonasteryName,MonasteryType,MonasteryTypeName,MonasteryPhoneNo,DepositaryName,DepositaryPhoneNo,MonasteryAreaRai,MonasteryAreaNgan,MonasteryAreaWa,LandRightsDocuments,DateOfFounding,EcclesiasticalTitle,EcclesiasticalType,AbbotTitle,AbbotName,AbbotType,AbbotTemple,Preceptor,PreceptorTemple,DateOfAcceptPosition,AbbotPhoneNo,AbbotEmail,AbbotLineId,AbbotImageUrl,CertifierName,CertifierTemple,DateOfBirth,DateOfOrdination,AbbotSignDate,AddressTextMonatery,HouseNoMonatery,MooMonatery,VillageMonatery,RoadMonatery,SubDistrictMonatery,DistrictMonatery,ProvinceMonatery,CountryMonatery,PostCodeMonatery")] TBranch tBranch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tBranch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tBranch);
        }

        // GET: TBranches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBranch = await _context.TBranch.FindAsync(id);
            if (tBranch == null)
            {
                return NotFound();
            }
            return View(tBranch);
        }

        // POST: TBranches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActiveStatus,LanguageId,RecordStatus,CreatedBy,ModifiedBy,CreatedByName,ModifiedByName,Notation,CreatedDate,ModifiedDate,BranchName,BranchType,BranchTypeName,MonasteryName,MonasteryType,MonasteryTypeName,MonasteryPhoneNo,DepositaryName,DepositaryPhoneNo,MonasteryAreaRai,MonasteryAreaNgan,MonasteryAreaWa,LandRightsDocuments,DateOfFounding,EcclesiasticalTitle,EcclesiasticalType,AbbotTitle,AbbotName,AbbotType,AbbotTemple,Preceptor,PreceptorTemple,DateOfAcceptPosition,AbbotPhoneNo,AbbotEmail,AbbotLineId,AbbotImageUrl,CertifierName,CertifierTemple,DateOfBirth,DateOfOrdination,AbbotSignDate,AddressTextMonatery,HouseNoMonatery,MooMonatery,VillageMonatery,RoadMonatery,SubDistrictMonatery,DistrictMonatery,ProvinceMonatery,CountryMonatery,PostCodeMonatery")] TBranch tBranch)
        {
            if (id != tBranch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tBranch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBranchExists(tBranch.Id))
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
            return View(tBranch);
        }

        // GET: TBranches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBranch = await _context.TBranch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tBranch == null)
            {
                return NotFound();
            }

            return View(tBranch);
        }

        // POST: TBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tBranch = await _context.TBranch.FindAsync(id);
            if (tBranch != null)
            {
                _context.TBranch.Remove(tBranch);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TBranchExists(int id)
        {
            return _context.TBranch.Any(e => e.Id == id);
        }
    }
}
