using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BodyDismemberment : MonoBehaviour {
    
    void OnCollisionEnter(Collision col) {

        if (col.gameObject.tag != gameObject.tag) {
            if (gameObject.GetComponent<CharacterJoint>())
            {
                GameObject.Destroy(gameObject.GetComponent<CharacterJoint>());
            }
            if (gameObject.GetComponent<Collider>())
            {
                GameObject.Destroy(gameObject.GetComponent<Collider>());
            }
            if (gameObject.GetComponent<Rigidbody>())
            {
                GameObject.Destroy(gameObject.GetComponent<Rigidbody>());
            }

            GameObject.Destroy(gameObject);
        } 
    }
}
