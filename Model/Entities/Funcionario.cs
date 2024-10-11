namespace Model.Entities
{
    public class Funcionario : Usuario
    {
        public string Cargo { get; set; }
        public string NumeroRegistro { get; set; }
        public Funcionario() { }
    }
}