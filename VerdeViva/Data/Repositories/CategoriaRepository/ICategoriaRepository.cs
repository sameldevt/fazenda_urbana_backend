using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Producao;

namespace _.VerdeViva.Data.Repositories.CategoriaRepository;

public interface ICategoriaRepository
{
    Categoria Buscar(int categoriaId);
    void Cadastrar(Categoria categoria);
}
