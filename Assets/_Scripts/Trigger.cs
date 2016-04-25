using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject.Find("DistanceCounter").GetComponent<DistanceTracker>()._startCounter = true;
        }
    }
}
