using Domain.Entities; // Importa as entidades do domínio para serem mapeadas pelo EF Core
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    /// <summary>
    /// Contexto principal de acesso ao banco de dados via Entity Framework Core.
    /// 
    /// Esta classe faz parte da camada de Infrastructure/Data
    /// e é responsável por mapear as entidades e gerenciar as operações
    /// de conexão, leitura e escrita no banco.
    /// 
    /// Em um projeto real, cada DbSet representa uma tabela no banco e,
    /// por convenção, deve-se adicionar um DbSet para cada entidade persistente.
    /// </summary>
    public class MyContext: DbContext
    {
        // <summary>
        /// DbSet que representa a tabela de usuários no banco de dados.
        /// Cada instância de UserEntity será um registro na tabela.
        /// </summary>
        public DbSet<UserEntity> Users { get; set; }
        
        /// <summary>
        /// Construtor do contexto, recebe as configurações de opções do EF Core
        /// por injeção de dependência. Isso permite configurar connection string,
        /// provedores, logging e outros parâmetros de execução em tempo de serviço.
        /// </summary>
        /// <param name="options">
        /// Opções do contexto configuradas durante o startup da aplicação.
        /// </param>
        public MyContext(DbContextOptions<MyContext> options) : base(options){}

        /// <summary>
        /// (Opcional - pode ser sobrescrito conforme necessário)
        /// Método chamado ao construir o modelo de mapeamento do EF Core.
        /// Usado para configurações avançadas de entidades, relacionamentos, restrições,
        /// tipos complexos, seed data e conventions customizadas.
        /// A chamada base garante que a configuração padrão do EF Core também é aplicada.
        /// </summary>
        /// <param name="modelBuilder">Builder para configuração detalhada do modelo.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chama a configuração padrão do EF Core.
            base.OnModelCreating(modelBuilder);
            
            // Aqui podem ser adicionadas configurações específicas, ex:
            // modelBuilder.Entity<UserEntity>().ToTable("Users");
            // modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}