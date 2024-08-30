using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.VerdeViva.Models.Entities.Producao;

namespace _.VerdeViva.Data.Repositories.NutrienteRepository;

public interface INutrienteRepository
{
    Nutriente Buscar(int PkNutriente);
}
