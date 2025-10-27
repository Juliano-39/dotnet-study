using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    /// <summary>
    /// Interface genérica para o padrão Repository.
    /// Define operações CRUD assíncronas básicas para qualquer entidade herdando de BaseEntity.
    /// Essencial para desacoplar lógica de domínio do mecanismo de persistência de dados.
    /// </summary>
    /// <typeparam name="T">
    /// Entidade do domínio, deve herdar de BaseEntity para garantir presença do Id e auditoria.
    /// </typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Insere uma nova entidade do tipo T de forma assíncrona.
        /// </summary>
        /// <param name="item">Entidade a ser inserida no repositório.</param>
        /// <returns>A entidade inserida com identidade (ex: Id preenchido).</returns>
        Task<T> InsertAsync(T item);

        /// <summary>
        /// Atualiza uma entidade do tipo T existente de forma assíncrona.
        /// </summary>
        /// <param name="item">Entidade modificada a ser atualizada no repositório.</param>
        /// <returns>Entidade pós-atualização.</returns>
        Task<T> UpdateAsync(T item);

        /// <summary>
        /// Remove uma entidade do tipo T identificada pelo Id de forma assíncrona.
        /// </summary>
        /// <param name="id">Identificador único (GUID) da entidade a ser removida.</param>
        /// <returns>True se a exclusão foi bem sucedida, false se não encontrou.</returns>
        Task<bool> DeleteAsync(Guid id);

        /// <summary>
        /// Seleciona uma única entidade do tipo T a partir do Id (GUID), de forma assíncrona.
        /// </summary>
        /// <param name="id">Identificador único a ser consultado.</param>
        /// <returns>A entidade localizada ou null, se não encontrada.</returns>
        Task<T> SelectAsync(Guid id);

        /// <summary>
        /// Seleciona todas as entidades do tipo T, de forma assíncrona.
        /// </summary>
        /// <returns>Coleção de entidades do tipo T presentes no repositório.</returns>
        Task<IEnumerable<T>> SelectAsync();
        
        /// <summary>
        /// Verifica se existe uma entidade com o identificador informado.
        /// </summary>
        /// <param name="id">Identificador único (GUID) da entidade a ser consultada.</param>
        /// <returns>True se existir uma entidade com o Id fornecido, false caso contrário.</returns>
        Task<bool>  ExistAsync(Guid id);
    }
}
