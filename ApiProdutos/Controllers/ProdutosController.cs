using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProdutos.Data;
using ApiProdutos.Entities;

namespace ApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ApiContext _context;

        public ProdutosController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Produtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            List<Produto> produtos = await _context.Produtos.ToListAsync();
            foreach (Produto produto in produtos)
            {
                produto.Categoria = await _context.Categorias
                .FirstOrDefaultAsync(c => c.Id == produto.CategoriaId);
            }
            return produtos;
        }

        [HttpGet("/api/[controller]/categoria/{id}")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutosByCategoria(
            [FromRoute] int id)
        {
            List<Produto> produtos = await _context.Produtos.ToListAsync();
             var prodByCategoria = 
                 (from prod  in produtos 
                 where prod.CategoriaId == id 
                 select prod).ToList();

            Categoria categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
            foreach (Produto produto in prodByCategoria)
            {
                produto.Categoria = categoria;
            }
             return prodByCategoria;
           /* return (from prod in produtos
                    where prod.CategoriaId == id
                    select prod).ToList();*/
           
        }

        // GET: api/Produtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // PUT: api/Produtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Produtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            produto.CategoriaId = produto.Categoria.Id;
            produto.Categoria =
                await _context.Categorias
                .FirstOrDefaultAsync(c => c.Id == produto.CategoriaId);

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
        }

        // DELETE: api/Produtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
