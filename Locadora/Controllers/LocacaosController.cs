using Locadora.Data;
using Locadora.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class LocacaosController : Controller
{
    private readonly LocadoraContext _context;

    public LocacaosController(LocadoraContext context)
    {
        _context = context;
    }

    // GET: Locacaos
    public async Task<IActionResult> Index()
    {
        var locadoraContext = _context.Locacoes.Include(l => l.Cliente).Include(l => l.Filme);
        return View(await locadoraContext.ToListAsync());
    }

    // GET: Locacaos/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var locacao = await _context.Locacoes
            .Include(l => l.Cliente)
            .Include(l => l.Filme)
            .FirstOrDefaultAsync(m => m.LocacaoId == id);
        if (locacao == null)
        {
            return NotFound();
        }

        return View(locacao);
    }

    // GET: Locacaos/Create
    public IActionResult Create()
    {
        ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome");
        ViewData["FilmeId"] = new SelectList(_context.Filmes, "FilmeId", "Titulo");
        return View();
    }

    // POST: Locacaos/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("LocacaoId,ClienteId,FilmeId,DataLocacao,DataDevolucao")] Locacao locacao)
    {
        if (ModelState.IsValid)
        {
            // Obtém o valor do filme selecionado
            var filme = await _context.Filmes.FindAsync(locacao.FilmeId);
            if (filme != null)
            {
                locacao.Filme = filme;
            }

            _context.Add(locacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome", locacao.ClienteId);
        ViewData["FilmeId"] = new SelectList(_context.Filmes, "FilmeId", "Titulo", locacao.FilmeId);
        return View(locacao);
    }

    // Método para retornar o preço do filme via AJAX
    [HttpGet]
    public async Task<IActionResult> GetFilmePreco(int filmeId)
    {
        var filme = await _context.Filmes.FindAsync(filmeId);
        if (filme == null)
        {
            return NotFound();
        }

        return Json(new { preco = filme.Preco });
    }

    // GET: Locacaos/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var locacao = await _context.Locacoes.FindAsync(id);
        if (locacao == null)
        {
            return NotFound();
        }

        ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome", locacao.ClienteId);
        ViewData["FilmeId"] = new SelectList(_context.Filmes, "FilmeId", "Titulo", locacao.FilmeId);
        return View(locacao);
    }

    // POST: Locacaos/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("LocacaoId,ClienteId,FilmeId,DataLocacao,DataDevolucao")] Locacao locacao)
    {
        if (id != locacao.LocacaoId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                // Obtém o valor atualizado do filme ao editar
                var filme = await _context.Filmes.FindAsync(locacao.FilmeId);
                if (filme != null)
                {
                    locacao.Filme = filme;
                }

                _context.Update(locacao);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocacaoExists(locacao.LocacaoId))
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

        ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome", locacao.ClienteId);
        ViewData["FilmeId"] = new SelectList(_context.Filmes, "FilmeId", "Titulo", locacao.FilmeId);
        return View(locacao);
    }

    // Método para verificar se a locação existe
    private bool LocacaoExists(int id)
    {
        return _context.Locacoes.Any(e => e.LocacaoId == id);
    }

    // GET: Locacaos/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var locacao = await _context.Locacoes
            .Include(l => l.Cliente)  // Inclui Cliente
            .Include(l => l.Filme)    // Inclui Filme
            .FirstOrDefaultAsync(m => m.LocacaoId == id);

        if (locacao == null)
        {
            return NotFound();
        }

        return View(locacao);
    }

    // POST: Locacaos/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var locacao = await _context.Locacoes.FindAsync(id);
        _context.Locacoes.Remove(locacao);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}