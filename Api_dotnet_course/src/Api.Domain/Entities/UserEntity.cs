namespace Domain.Entities
{
    // Herda propriedades básicas da BaseEntity.
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}