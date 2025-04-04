using BlazorProva.Models;

namespace BlazorProva.Services
{
    public interface ICurriculoService
    {
        Task AddCurriculo(Curriculo curriculo);
        Task<Curriculo?> GetCurriculoID(int id);

        /*
         * 🔧 Como adicionar mais métodos:
         * - Task<IEnumerable<Produto>> GetTodos();
         * - Task AtualizarProduto(Produto produto);
         * - Task DeletarProduto(int id);
         */
    }
}