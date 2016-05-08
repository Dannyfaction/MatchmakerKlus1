using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {

    private float hitDelay;

	void Start () {
	
	}
	
	void Update () {
        if (hitDelay > 0)
        {
            hitDelay -= Time.deltaTime;
        }
	}

    void OnCollisionEnter(Collision collider)
    {
        if (collider.transform.tag != "Player" && hitDelay <= 0)
        {
            Debug.Log(transform.name + " has been hit!");
            hitDelay = 1;
        }
    }
}
