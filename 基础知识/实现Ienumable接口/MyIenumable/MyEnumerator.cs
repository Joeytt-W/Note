using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyIenumable
{
    public class MyEnumerator<T> : IEnumerator where T:class 
    {
        private readonly T[] _t;
        int index = -1;

        public MyEnumerator(T[] t)
        {
            _t = new T[t.Length];
            for (int i = 0; i < t.Length; i++)
            {
                _t[i] = t[i];
            }
        }

        public object Current 
        {
            get
            {
                try
                {
                    return _t[index];
                }catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool MoveNext()
        {
            index++;
            return index < _t.Length;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
