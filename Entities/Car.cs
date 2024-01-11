namespace WebApplicationLar.Entities
{
    public class Car : BaseEntity
    {
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public bool Sinistro { get; set; }
        public int Ano { get; set; }
    }
}
