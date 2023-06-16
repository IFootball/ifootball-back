namespace IFootball.Domain.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public BaseEntity()
        {
            // Retirar - Banco ja faz auto, só por fim de testes
            Id = Guid.NewGuid();
        }
    }
}
