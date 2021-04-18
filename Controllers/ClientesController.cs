using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_api_cliente_mongo.Data;
using web_api_cliente_mongo.Entities;
using web_api_cliente_mongo.Models;

namespace web_api_cliente_mongo.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesDb _clienteDb;

        public ClientesController(ClientesDb clienteDb)
        {
            _clienteDb = clienteDb;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _clienteDb.Get());
        }

        [HttpGet("{id}", Name = "GetCliente")]
        public async Task<IActionResult> GetById(string id)
        {
            var cliente = await _clienteDb.GetById(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteDto clienteDto)
        {
            var cliente = new Cliente(clienteDto.Nome, 
                                      clienteDto.Apelido, 
                                      clienteDto.Sexo, 
                                      clienteDto.DataNascimento, 
                                      clienteDto.Telefones, 
                                      clienteDto.Endereco);

            await _clienteDb.Create(cliente);

            return CreatedAtRoute("GetCliente", new
            {
                id = cliente.Id.ToString()
            }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ClienteDto clienteDto)
        {
            var cliente = _clienteDb.GetById(id);

            if (cliente == null)
            {
                return NotFound();
            }

            var clienteAtualizado = new Cliente(clienteDto.Nome, 
                                                clienteDto.Apelido, 
                                                clienteDto.Sexo, 
                                                clienteDto.DataNascimento, 
                                                clienteDto.Telefones, 
                                                clienteDto.Endereco);
            clienteAtualizado.Id = id;

            await _clienteDb.Update(id, clienteAtualizado);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(string id)
        {
            var cliente = await _clienteDb.GetById(id);

            if (cliente == null)
            {
                return NotFound();
            }

            await _clienteDb.DeleteById(cliente.Id);

            return NoContent();
        }
    }
}