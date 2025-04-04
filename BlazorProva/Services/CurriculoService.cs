using BlazorProva.Models;
using BlazorProva.Repositories;

namespace BlazorProva.Services
{
    public class CurriculoService : ICurriculoService
    {
        private readonly ICurriculoRepository _curriculoRepository;

        public CurriculoService(ICurriculoRepository curriculoRepository)
        {
            _curriculoRepository = curriculoRepository ?? throw new ArgumentNullException(nameof(curriculoRepository));
        }

        public async Task AddCurriculo(Curriculo curriculo)
        {
            if (curriculo == null)
                throw new ArgumentNullException(nameof(curriculo));

            if (string.IsNullOrWhiteSpace(curriculo.Nome))
                throw new ArgumentException("O nome é obrigatório.");

            if (string.IsNullOrWhiteSpace(curriculo.Biografia))
                throw new ArgumentException("A biografia é obrigatório.");

            if (string.IsNullOrWhiteSpace(curriculo.Links))
                throw new ArgumentException("O github é obrigatório.");

            if (string.IsNullOrWhiteSpace(curriculo.Habilidades))
                throw new ArgumentException("A habilidade é obrigatório.");

            await _curriculoRepository.AddCurriculo(curriculo);
        }

        public async Task<Curriculo?> GetCurriculoID(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O ID do curriculo deve ser maior que zero.");

            return await _curriculoRepository.GetCurriculoID(id);
        }

        /*
         * 🔧 Como adicionar mais regras de negócio:
         * - Verificação de duplicidade (ex: produto já existe)
         * - Validações mais complexas (ex: nome não pode ter números)
         */
    }
}
