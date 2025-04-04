namespace BlazorProva.Models
{
    // Representa o objeto Produto (reflete a tabela no banco)
    public class Curriculo
    {
        public int Id { get; set; } // Chave primária
        public string Nome { get; set; } // Nome do produto
        public string? Biografia { get; set; } // Preço do produto (aceita nulo)
        public string? Habilidades { get; set; } // Quantidade em estoque (aceita nulo)
        public string? Links { get; set; }

    }

    /*
     * 🔧 Como adicionar mais campos:
     * - Adicione novas propriedades, ex: public string? Categoria { get; set; }
     * - Atualize o banco na classe ProdutoRepository -> CriarTabelaSeNaoExistir()
     */
}
