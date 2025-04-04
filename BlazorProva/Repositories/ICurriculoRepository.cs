using BlazorProva.Models;

namespace BlazorProva.Repositories
{
    public interface ICurriculoRepository
    {

        Task AddCurriculo(Curriculo curriculo);
        Task<Curriculo?> GetCurriculoID(int id);

        /*
         * 🔧 Como adicionar mais métodos:
         * - Task<IEnumerable<Produto>> GetTodos();
         * - Task UpdateProduto(Produto produto);
         * - Task DeleteProduto(int id);
         */
    }
}
