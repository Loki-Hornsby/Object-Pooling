/// <summary>
/// Made by Loki Alexander Button Hornsby
/// Licensed under the BSD 3-Clause "New" or "Revised" License
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// An item which belongs in an object pool. (A Rubber Ducky)
/// </summary>

namespace Loki.Object.Pooling {
    public class RubberDucky {
        // Spawned Game Object
        public GameObject item;

        // Is this item in use?
        private bool _inUse;

        // Redefine how our [inUse] variable is accessed
        public bool inUse {
            get {
                // Return our variable
                return this._inUse;
            } set {
                // Set our variable
                this._inUse = value;

                // Set our items activate state to the value of our variable
                item.SetActive(value);
            }
        }

        /// <summary>
        /// Add and remove components from our object
        /// </summary>
        public void PassComponents(params Component[] components){
            // Loop through every component passed into this method
            foreach (Component component in components){
                // Desired Component
                System.Type desiredComponent = component.GetType();

                // Work out how many of this component is desired
                var desiredComponentAmount = components.Where(x => x == component).Count();

                // Define existing components
                var existingComponents = item.GetComponents(desiredComponent);

                // Define amount of existing components 
                int existingComponentsAmount = existingComponents.Count();

                // If our desired component already exists
                if (existingComponentsAmount > 0){
                    // If our desired are less than those that exist
                    if (desiredComponentAmount < existingComponentsAmount){
                        // Get the first existing and destroy it
                        UnityEngine.Object.Destroy(existingComponents.FirstOrDefault());
                    }
                } else {
                    // Add our component to our game object
                    item.AddComponent(desiredComponent);
                }
            }
        }

        /// <summary>
        /// Constructor for our class
        /// </summary>
        public RubberDucky(){
            // Spawn an object
            item = new GameObject("Pooled Object");

            // Define the object as unused
            inUse = false;
        }
    }
}
