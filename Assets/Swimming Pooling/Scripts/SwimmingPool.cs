/// <summary>
/// Made by Loki Alexander Button Hornsby
/// Licensed under the BSD 3-Clause "New" or "Revised" License
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Loki.Object.Pooling {
    public class SwimmingPool : MonoBehaviour {
        // Maximum allowed items
        public int Cap;

        // Stored Items
        GameObject[] objects;

        void Start(){
            // Array of our objects
            objects = new GameObject[Cap];

            // List through each object
            for (int i = 0; i < Cap; i++){
                objects[i] = new GameObject("Ob");
            }
        }
    }
}