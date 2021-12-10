using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strazProject.Classes
{
    public class FireStationEnumerator : IEnumerator<FireTruck>
    {
        private FireStation _base;
        private int _index;

        public FireStationEnumerator(FireStation _base)
        {
            this._base = _base;
            this._index = -1;
        }

        public FireTruck Current => _base.GetFireTruck(_index);

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            return ++_index < _base.Count();
        }

        public void Reset()
        {
            this._index = -1;
        }
    }
}
