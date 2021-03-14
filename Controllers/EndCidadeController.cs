using AppCardapio.Data;
using AppCardapio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCardapio.Controllers
{
    public class EndCidadeController : Controller
    {
        private readonly AppCardapioDbContext _context;
        public EndCidadeController(AppCardapioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<EndCidadeModel>listaCidades = new List<EndCidadeModel>();
            listaCidades = await _context.EndCidade.AsNoTracking().ToListAsync();
            return View(listaCidades);
        }

        [HttpPost]
        public async Task<ActionResult> Create(EndCidadeModel novaCidade)
        {
            _context.EndCidade.Add(novaCidade);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Update(int idCidade)
        {
            return View(await _context.EndCidade.Where(c => c.Id_cidade == idCidade).FirstOrDefaultAsync());
        }

        [HttpPatch]
        public async Task<ActionResult> Update(EndCidadeModel alteraCidade)
        {
            _context.Entry(alteraCidade).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            return View();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int idCidade)
        {
            EndCidadeModel cidade = await _context.EndCidade.Where(c => c.Id_cidade == idCidade).FirstOrDefaultAsync();
            _context.EndCidade.Remove(cidade);
            return RedirectToAction("Index");
        }
    }
}
