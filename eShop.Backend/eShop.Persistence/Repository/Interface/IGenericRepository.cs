﻿using eShop.Models.DTO;

namespace eShop.Persistence.Repository.Interface;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task<GenericPagedResponse<T>> GetPagedResponse(int page, int limit);
    Task Add(T entity);
    void Delete(T entity);
    void Update(T entity);
}
