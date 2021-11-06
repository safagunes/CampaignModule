using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Domain.Repositories
{
    public interface IRepository<T>
    {
        void Create(T model);
        T Get(string code);
    }
}
