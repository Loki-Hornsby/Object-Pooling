/// <summary>
/// Made by Loki Alexander Button Hornsby
/// Licensed under the BSD 3-Clause "New" or "Revised" License
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Access our pool!
/// </summary>

namespace Loki.Object.Pooling.Demo {
    [RequireComponent(typeof(Loki.Object.Pooling.ObjectPool))]
    public class AccessPool : MonoBehaviour {
        // Our pool of objects
        Loki.Object.Pooling.ObjectPool pool;

        // our previous request
        Queue<GameObject> previous;

        // Object to get components from (Debug - a better solution needs to be found to do this)
        public GameObject Base;

        // Found components
        Component[] components;
        
        /// <summary>
        /// Initialize this demo script
        /// </summary>
        void Start(){
            // Get our pool
            pool = GetComponent<Loki.Object.Pooling.ObjectPool>();

            // Define our queue of requested objects
            previous = new Queue<GameObject>();

            // Get our components from our referenced object
            components = Base.GetComponents<Component>();
        }

        /// <summary>
        /// Update our demo script
        /// </summary>
        void Update(){
            // If the player pressed p
            if (Input.GetKeyDown(KeyCode.P)){
                // Request an object (If we find one it's enabled)
                var request = pool.RequestObject(components);

                // If the request was successfull
                if (request != null){
                    // Move our object to a random position
                    request.transform.position = new Vector3(
                        UnityEngine.Random.Range(-1f, 1f), 
                        UnityEngine.Random.Range(-1f, 1f), 
                        UnityEngine.Random.Range(-1f, 1f)
                    );

                    // Store our object for later use
                    previous.Enqueue(request);
                }
            
            // If the player pressed space bar
            } else if (Input.GetKeyDown(KeyCode.Space)) {
                // Pass back the first item in our queue to the pool
                pool.PassBackObject(previous.Dequeue());
            }
        }
    }
}
