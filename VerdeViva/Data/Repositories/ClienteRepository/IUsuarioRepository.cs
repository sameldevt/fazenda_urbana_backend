using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Dashboard.Cliente;

namespace _.VerdeViva.Data.Repositories.ClienteRepository;

public interface IUsuarioRepository
{
    Task<Usuario> BuscarPorEmail(string Email);
    Task<Usuario> Buscar(int usuarioId);

    void Cadastrar(Usuario usuario);
}
