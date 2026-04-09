using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Update(T entity);
        void Add(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
    }
}
