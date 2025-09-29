using Domain.Entities; // Importa a entidade UserEntity para configurar seu mapeamento
using Microsoft.EntityFrameworkCore; // Namespace principal do EF Core
using Microsoft.EntityFrameworkCore.Metadata.Builders; // Para acessar EntityTypeBuilder para configuração

namespace Data.Mapping
{
    // Classe responsável por configurar como a entidade UserEntity será refletida no banco de dados
    // Implementa a interface padrão de configuração do EF Core para garantir padrão e desacoplamento
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        // Método chamado pelo EF Core para aplicar as configurações na entidade UserEntity
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            // Define o nome da tabela no banco que armazenará os dados de UserEntity
            builder.ToTable("User");
            
            // Configura a propriedade Id como chave primária da tabela
            builder.HasKey(u => u.Id);
            
            // Cria um índice no campo Email com a restrição de ser único, evitando duplicidade
            builder.HasIndex(u => u.Email)
                .IsUnique();
            
            // Configura a propriedade Name como obrigatória e define limite máximo de 60 caracteres
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(60);

            // Configura o campo Email com tamanho máximo de 100 caracteres (pode ser nulo)
            builder.Property(u => u.Email)
                .HasMaxLength(100);
        }
    }
}