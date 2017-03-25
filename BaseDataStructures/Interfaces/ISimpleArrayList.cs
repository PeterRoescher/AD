using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDataStructures.Interfaces
{
    public interface ISimpleArrayList<T>
    {
        void Add(T data); // toevoegen aan het einde van de lijst, mits de lijst niet vol is
        T Get(int index); // haal de waarde op van een bepaalde index
        void Set(int index, T data); // wijzig een item op een bepaalde index
        void Print(); // print de inhoud van de list
        void Clear(); // maak de list leeg
        int CountOccurences(T data); // tel hoe vaak het gegeven getal voorkomt

        int GetMaxIndex();
        T GetMax();
    }
}
