using Model.Entities;

namespace Model.Dtos
{
    public record CategoriaDto
    (
        string Nome,
        string Descricao,
        DateTime DataCriacao
    )
    {
        public static CategoriaDto FromCategoria(Categoria categoria)
        {
            return new CategoriaDto
            (
                Nome: categoria.Nome,
                Descricao: categoria.Descricao,
                DataCriacao: categoria.DataCriacao
            );
        }
    }
}
