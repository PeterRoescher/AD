using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDataStructures.Interfaces
{
    public interface ISimpleLinkedList<T>
    {
        void AddFirst(T data); // voeg een item toe aan het begin van de lijst
        void Clear();
        void Print();
        void Insert(int index, T data); // voeg een item in op een bepaalde index (niet overschrijven!)
        void RemoveFirst(); // verwijder het eerste item
        T GetFirst(); // geeft het eerste item terug

        int GetMaxIndex();
        T GetMax();
    }
}
