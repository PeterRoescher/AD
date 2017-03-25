using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BaseDataStructures.Interfaces
{
    public interface IQueue<T>
    {
        void Enqueue(T data);
        T Dequeue();

        T Peek();
    }
}
