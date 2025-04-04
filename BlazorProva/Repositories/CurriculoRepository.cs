using Dapper;
using System.Data;
using BlazorProva.Models;

namespace BlazorProva.Repositories
{
    public class CurriculoRepository : ICurriculoRepository
    {
        private readonly IDbConnection _dbConnection;

        public CurriculoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            CriarTabelaSeNaoExistir().Wait(); // Cria tabela se não existir
        }

        private async Task CriarTabelaSeNaoExistir()
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS public.CurriculoNic (
                    Id SERIAL PRIMARY KEY,
                    Nome VARCHAR(255) NOT NULL,
                    Biografia VARCHAR(500) NOT NULL,
                    Habilidades VARCHAR(500) NOT NULL,
                    Links VARCHAR(500) NOT NULL
                );";

            await _dbConnection.ExecuteAsync(sql);
        }

        public async Task AddCurriculo(Curriculo curriculo)
        {
            string sql = "INSERT INTO public.CurriculoNic (Nome, Biografia, Habilidades, Links) VALUES (@Nome, @Biografia, @Habilidades, @Links)";
            await _dbConnection.ExecuteAsync(sql, curriculo);
        }

        public async Task<Curriculo?> GetCurriculoID(int id)
        {
            string sql = "SELECT * FROM public.CurriculoNic WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Curriculo>(sql, new { Id = id });
        }

        /*
         * 🔧 Como adicionar mais métodos:
         * - Para buscar todos os produtos: SELECT * FROM public.Produtos
         * - Para atualizar: UPDATE public.Produtos SET Nome = @Nome WHERE Id = @Id
         * - Para deletar: DELETE FROM public.Produtos WHERE Id = @Id
         */
    }
}
