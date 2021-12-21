using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyIenumable
{
    public class MyList<T> : IEnumerable where T:class
    {
        private readonly T[] _t;
        public MyList(T[] t)
        {
            _t = new T[t.Length];
            for (int i = 0; i < t.Length; i++)
            {
                _t[i] = t[i];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator<T>(_t);
        }
    }
}
