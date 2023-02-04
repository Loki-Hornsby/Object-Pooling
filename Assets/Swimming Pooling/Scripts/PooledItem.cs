using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pooling {
    public class PooledItem {
        GameObject obj;

        public PooledItem(GameObject _obj){
            obj = _obj;
        }
    }
}