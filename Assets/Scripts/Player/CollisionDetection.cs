using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {

    private float hitDelay;
    [SerializeField] private Player playerScript;

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
            if ((transform.name == "Root_M" || transform.name == "Spine1_M (joint)") && collider.transform.name == "Spike")
            {
                Debug.Log("Je bent gespiest G");
                playerScript.GettingImpaled(collider);
            }
            else
            {
                playerScript.GettingHit();
            }
        }
    }
}