using Model.Entities;

namespace Model.Dtos
{
    public interface IObjetoDominio { }

    public interface IDto { }

    public interface IDtoFactory<T> where T : IObjetoDominio
    {
        IDto Criar(TipoDto tipoDto, T objetoDominio);
    }
}