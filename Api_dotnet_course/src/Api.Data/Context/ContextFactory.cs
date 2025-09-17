using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    // Fábrica de contexto de banco de dados (MyContext).
     
    // Implementa 'IDesignTimeDbContextFactory<MyContext>', que é uma interface do EF Core
    // para criação de instâncias do DbContext em operações de migration, scaffolding
    // e linha de comando (CLI), sem depender de DI no startup do app.
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        // Método chamado automaticamente pelo EF Core em tempo de design.
        // Prepara as opções e configurações necessárias para criar o contexto,
        // como a string de conexão e o provedor do banco de dados.
         
        // Parâmetros:
        //   args - argumentos de linha de comando (normalmente não utilizados aqui).
         
        // Retorna uma nova instância de MyContext, pronta para ser usada em migrations
        // ou outras operações fora do runtime principal da aplicação.
        public MyContext CreateDbContext(string[] args)
        {
            // String de conexão completa com os parâmetros de acesso ao banco MySQL.
            // Atenção: evite deixar usuários/senhas hardcoded em produção
            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=root";
            
            // Cria um builder de opções específico para o tipo MyContext.
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            
            // Configura o builder para usar o provedor MySQL com a string de conexão fornecida.
            optionsBuilder.UseMySql(connectionString);
            
            // Retorna o contexto configurado para uso imediato em migrations ou CLI.
            return new MyContext(optionsBuilder.Options);
        }
    }
}