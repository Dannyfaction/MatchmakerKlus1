using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    [SerializeField] private Transform target;
    [SerializeField] private float yOffset;

	// Use this for initialization
	void Start () {
        DynamicGI.UpdateEnvironment();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        //transform.position = new Vector3(transform.position.x,target.transform.position.y+yOffset,transform.position.z);
        Vector3 newYPos = new Vector3(transform.position.x, target.transform.position.y + yOffset, transform.position.z);
        transform.position = Vector3.Lerp(transform.position,newYPos,Time.fixedDeltaTime * 100f);
        if (transform.name == "Player Camera")
        {
            Vector3 newXZPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newXZPos, Time.fixedDeltaTime * 0.5f);
        }
    }
}
