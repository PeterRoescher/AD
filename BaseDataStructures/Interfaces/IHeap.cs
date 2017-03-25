using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDataStructures.Interfaces
{
    interface IHeap<T>
    {
        bool Add(T data);

        T Remove();

    }
}
