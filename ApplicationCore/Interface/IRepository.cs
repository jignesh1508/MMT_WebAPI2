using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interface
{
    public interface IRepository<T> where T:class
    {
       
        Task<T> GetById(int id);
        Task<IEnumerable<T>> ListAll(string procedure);
        Task<IEnumerable<T>> ListAllById(int id,string procedure);
    }
}
