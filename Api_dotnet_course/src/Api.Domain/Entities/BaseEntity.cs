using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    // Classe base abstrata, não instanciável, para todas as entidades do domínio
    // Serve para padronizar propriedades comuns em todas as entidades
    public abstract class BaseEntity
    {
        // Indica para o ORM que esta propriedade é a chave primária da entidade
        [Key]
        public Guid Id { get; set; } // Identificador único universal (GUID)
        
        // Campo privado para armazenar o valor da data de criação
        private DateTime? _createdAt; 
        
        // O sinal de interrogação (?) indica que o campo é nullable
        
        public DateTime? CreatedAt
        {
            get { return _createdAt;}
            
            // Caso o valor seja nulo, seta automaticamente a data/hora atual UTC
            // Garante sempre uma data válida de criação
            set {_createdAt = (value == null ? DateTime.UtcNow : value);}
        }
        
        // Data e hora da última atualização da entidade
        // Nullable (?) para situações onde ainda não houve atualização
        public DateTime? UpdatedAt { get; set; }
    }
}