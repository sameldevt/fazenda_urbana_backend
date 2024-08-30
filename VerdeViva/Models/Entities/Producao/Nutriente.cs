using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _.VerdeViva.Models.Entities.Producao;

public class Nutriente
{
    public int Id {get; set;}
    public decimal Caloria {get; set;}
    public decimal Proteina {get; set;}
    public decimal carboidrato {get; set;}
    public decimal Fibra {get; set;}
    public decimal Gordura {get; set;}

    public Produto? Produto {get; set;}
}
