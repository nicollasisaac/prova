using BlazorProva.Models;
using BlazorProva.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProva.Controllers
{
    [ApiController]
    [Route("api/curriculo")] // Define a rota base para este controller: /api/produto
    public class CurriculoController : ControllerBase
    {
        private readonly ICurriculoService _curriculoService;

        // Injeção de dependência da camada de serviço
        public CurriculoController(ICurriculoService curriculoService)
        {
            _curriculoService = curriculoService;
        }

        /// <summary>
        /// Adiciona um novo produto via POST.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddCurriculo([FromBody] Curriculo curriculo)
        {
            try
            {
                await _curriculoService.AddCurriculo(curriculo); // Chama a lógica de negócio
                return CreatedAtAction(nameof(GetCurriculoPorID), new { id = curriculo.Id }, curriculo);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Retorna erro de validação
            }
        }

        /// <summary>
        /// Obtém um produto pelo ID via GET.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurriculoPorID(int id)
        {
            try
            {
                var curriculo = await _curriculoService.GetCurriculoID(id);
                if (curriculo == null)
                    return NotFound();
                return Ok(curriculo);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*
         * 🔧 Como adicionar novos endpoints:
         * - Para buscar todos os produtos: [HttpGet] GetTodosProdutos()
         * - Para atualizar: [HttpPut("{id}")] AtualizarProduto(int id, Produto produto)
         * - Para deletar: [HttpDelete("{id}")] DeletarProduto(int id)
         */
    }
}
