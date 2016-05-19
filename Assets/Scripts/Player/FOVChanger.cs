using UnityEngine;
using System.Collections;

public class FOVChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Hip")
        {
            Camera.main.fieldOfView = 150;
        }
    }
}
