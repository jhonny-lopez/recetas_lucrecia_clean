using RecetasLucrecia.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasLucrecia.Application.Contracts.Persistance
{
    public interface IRepository<T> where T : IEntity
    {
        /// <summary>
        /// Obtiene todos los objetos desde la base de datos del tipo T
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Obtiene un objeto desde el repositorio a través de su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(object id);

        /// <summary>
        /// Agrega un objeto T al repositorio
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Agrega un objeto T al repositorio de forma asincrónica
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Remueve/Elimina un objeto T del repositorio
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);
    }
}
