using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldApi.Models
{
    public interface IDataContext<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Save(T t);
        T Delete(int id);
    }
}
