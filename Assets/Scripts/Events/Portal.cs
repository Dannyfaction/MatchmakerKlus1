using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.name == "Root_M" || collider.transform.name == "Spine1_M (joint)")
        {
            Application.LoadLevel("Main");
        }
    }
}
