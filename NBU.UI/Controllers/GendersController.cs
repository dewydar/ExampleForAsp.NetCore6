#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using NBU.BLL._Gender;
using NBU.DAL.Context;
using NBU.DAL.Entities;
using NBU.DAL.ViewModel;

namespace NBU.UI.Controllers
{
    public class GendersController : Controller
    {
        private readonly GenderBLL _Bll;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<GendersController> _localizer;
        public GendersController(IGenderBLL genderBLL, IMapper mapper, IStringLocalizer<GendersController> localizer)
        {
            _Bll= genderBLL as GenderBLL;
            _mapper= mapper;
            _localizer= localizer;
        }
        // GET: Genders
        public async Task<IActionResult> Index()
        {
            return View(await _Bll.GetList());
        }

        // GET: Genders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = await _Bll.GetOne(m => m.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            var ViewModel = _mapper.Map<Gender, GenderVM>(entity);
           
            return View(ViewModel);
        }

        // GET: Genders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GenderVM ViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<GenderVM, Gender>(ViewModel);
                await _Bll.Add(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
        }

        // GET: Genders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _Bll.GetOne(m => m.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            var ViewModel = _mapper.Map<Gender, GenderVM>(entity);
            return View(ViewModel);
        }

        // POST: Genders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GenderVM ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var entity = _mapper.Map<GenderVM, Gender>(ViewModel);
                    entity.UpdateOn = DateTime.Now;
                    await _Bll.Update(entity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
        }

        // GET: Genders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _Bll.GetOne(m => m.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            var ViewModel = _mapper.Map<Gender, GenderVM>(entity);

            return View(ViewModel);
        }

        // POST: Genders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _Bll.GetOne(m => m.Id == id);
            await _Bll.Delete(entity);
            return RedirectToAction(nameof(Index));
        }

        //private bool GenderExists(int id)
        //{
        //    return _context.Gender.Any(e => e.Id == id);
        //}
    }
}
