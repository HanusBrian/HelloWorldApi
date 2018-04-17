using System;
using System.Collections.Generic;
using HelloWorldApi.Models;

namespace HelloWorldApi.Repositories
{
    public interface IDataRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Save(T t);
        T Delete(int id);
    }
}
