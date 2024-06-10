using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleAtletas.Context;
using ControleAtletas.Models;

namespace ControleAtletas.Controllers
{
    public class AtletaController : Controller
    {
        private readonly AppDbContext _context;

        public AtletaController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string filtro, string filtroValor)
        {
            if (_context == null || _context.Atleta == null)
            {
                return Problem("Entity set 'AppDbContext.Atleta' is null.");
            }

            IQueryable<Atleta> atletasQuery = _context.Atleta;


            if (Request.Query.ContainsKey("filtro") && string.IsNullOrEmpty(filtroValor))
            {
                ViewBag.AlertMessage = "Por gentileza, informe um valor para o filtro.";
            }
            else
            {
                switch (filtro)
                {
                    case "NumeroCamisa":
     
                        if (!int.TryParse(filtroValor, out int numeroCamisa))
                        {
                            ViewBag.AlertMessage = "Para filtrar por número de camisa, informe apenas números.";
                            return View(new List<Atleta>());
                        }

                        atletasQuery = atletasQuery.Where(a => a.NumeroCamisa.ToString() == filtroValor);
                        break;

                    case "Apelido":
                        if (filtroValor.Any(char.IsDigit))
                        {
                            ViewBag.AlertMessage = "Para filtrar por apelido, informe apenas letras.";
                            return View(new List<Atleta>());
                        }
                        atletasQuery = atletasQuery.Where(a => a.Apelido.Contains(filtroValor));
                        break;

                    case "IMC":
                        if (filtroValor.Any(char.IsDigit))
                        {
                            ViewBag.AlertMessage = "Para filtrar por Classificação, informe apenas letras.";
                            return View(new List<Atleta>());
                        }
                        atletasQuery = atletasQuery.Where(a => a.Classificacao.Contains(filtroValor));
                        break;
                    default:
                        break;
                }
            }

            var atletas = await atletasQuery.ToListAsync();

            foreach (var atleta in atletas)
            {
                atleta.DataNascimento = atleta.DataNascimento.Date;
            }

            return View(atletas);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Atleta == null)
            {
                return NotFound();
            }

            var atleta = await _context.Atleta
                .FirstOrDefaultAsync(m => m.AtletaID == id);
            if (atleta == null)
            {
                return NotFound();
            }

            return View(atleta);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AtletaID,NomeCompleto,Apelido,DataNascimento,Altura,Peso,Posicao,NumeroCamisa")] Atleta atleta)
            {
            double imc = atleta.CalcularIMC();
            atleta.IMC = imc;
            atleta.ClassificarIMC(atleta.Classificacao);
            atleta.IMC = double.Parse(imc.ToString("0.0"));
            if (ModelState.IsValid)
            {
                _context.Add(atleta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atleta);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Atleta == null)
            {
                return NotFound();
            }

            var atleta = await _context.Atleta.FindAsync(id);
            if (atleta == null)
            {
                return NotFound();
            }
            return View(atleta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AtletaID,NomeCompleto,Apelido,DataNascimento,Altura,Peso,Posicao,NumeroCamisa")] Atleta atleta)
        {
            if (id != atleta.AtletaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    double imc = atleta.CalcularIMC();
                    atleta.IMC = imc;
                    atleta.ClassificarIMC(atleta.Classificacao);
                    atleta.IMC = double.Parse(imc.ToString("0.0"));
                    _context.Update(atleta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtletaExists(atleta.AtletaID))
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
            return View(atleta);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Atleta == null)
            {
                return NotFound();
            }

            var atleta = await _context.Atleta
                .FirstOrDefaultAsync(m => m.AtletaID == id);
            if (atleta == null)
            {
                return NotFound();
            }

            return View(atleta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Atleta == null)
            {
                return Problem("Entity set 'AppDbContext.Atleta'  is null.");
            }
            var atleta = await _context.Atleta.FindAsync(id);
            if (atleta != null)
            {
                _context.Atleta.Remove(atleta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtletaExists(int id)
        {
          return (_context.Atleta?.Any(e => e.AtletaID == id)).GetValueOrDefault();
        }
    }
}
