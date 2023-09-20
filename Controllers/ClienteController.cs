using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly Conexcion _context;

        public ClienteController(Conexcion context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
          if (_context.Clientes == null)
          {
              return NotFound();
          }
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> GetClientes(long id)
        {
          if (_context.Clientes == null)
          {
              return NotFound();
          }
            var clientes = await _context.Clientes.FindAsync(id);

            if (clientes == null)
            {
                return NotFound();
            }

            return clientes;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientes(long id, Clientes clientes)
        {
            if (id != clientes.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesExists(id))
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

       
        [HttpPost]
        public async Task<ActionResult<Clientes>> PostClientes(Clientes clientes)
        {
          if (_context.Clientes == null)
          {
              return Problem("Entity set 'Conexcion.Clientes'  is null.");
          }
            _context.Clientes.Add(clientes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientes", new { id = clientes.Id }, clientes);
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientes(long id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly Conexcion _context;

        public ClienteController(Conexcion context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();
            if (clientes == null || clientes.Count == 0)
            {
                return NotFound("No se encontraron clientes.");
            }
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> GetCliente(long id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound($"Cliente con ID {id} no encontrado.");
            }
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(long id, Clientes cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest("ID en la URL no coincide con el ID del cliente.");
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound($"Cliente con ID {id} no encontrado.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Clientes>> PostCliente(Clientes cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtRoute(nameof(GetCliente), new { id = cliente.Id }, cliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(long id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound($"Cliente con ID {id} no encontrado.");
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(long id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}

            }

            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientesExists(long id)
        {
            return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
