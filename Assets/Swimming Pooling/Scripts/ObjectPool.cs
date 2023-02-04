/// <summary>
/// Made by Loki Alexander Button Hornsby
/// Licensed under the BSD 3-Clause "New" or "Revised" License
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

/// <summary>
/// A pool for our objects.
/// </summary>

namespace Loki.Object.Pooling {
    public class ObjectPool : MonoBehaviour {
        // Maximum allowed items
        public int Cap;

        // Stored Items
        private RubberDucky[] objects;

        /// <summary>
        /// Initialize the pool
        /// </summary>
        void Awake(){
            // Array of our objects
            objects = new RubberDucky[Cap];

            // List through each object
            for (int i = 0; i < Cap; i++){
                // Create an object and assign it to an index
                objects[i] = new RubberDucky();

                // Parent our object to this game object
                objects[i].item.transform.parent = this.transform;
            }
        }

        /// <summary>
        /// Request an object from our array
        /// </summary>
        public GameObject RequestObject(params Component[] components){
            // Find the first object not in use
            RubberDucky result = objects.Where(x => !x.inUse).FirstOrDefault();

            // If our result was found
            if (result != null) {
                // Define the components we want
                result.PassComponents(components);

                // Set item to be active
                result.inUse = true;

                // Return our result's game object
                return result.item;
            } else {
                return null;
            }
        }

        /// <summary>
        /// Pass a game object back and disable it
        /// </summary>
        /// <returns>Wether the operation was successfull</returns>
        public bool PassBackObject(GameObject Obj){
            // Check if the object is in our array
            var valid = objects.Where(x => x.item == Obj).FirstOrDefault();

            // If our item is valid
            if (valid != null){
                // Disable our object
                valid.inUse = false;

                return true;
            } else {
                return false;
            }
        }
    }
}

