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
    public class PessoaController : Controller
    {
        private readonly AppCardapioDbContext _context;

        public PessoaController (AppCardapioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _context.Pessoa.AsNoTracking().ToListAsync()); ;
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.cidade = await _context.EndCidade.AsNoTracking().ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PessoaModel pessoa)
        {
            _context.Pessoa.Add(pessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index"); ;
        }

        public async Task<ActionResult> Delete(int idPessoa)
        {
            PessoaModel pessoa = await _context.Pessoa.Where(p => p.Id_pessoa == idPessoa).FirstOrDefaultAsync();
            _context.Pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
