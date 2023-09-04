using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myUtility.Libraries.Interfaces
{
    public interface ISessionLibrary
    {
        void Set<T>(string key, T value);

        T Get<T>(string key);

        void Clear();

    }
}
