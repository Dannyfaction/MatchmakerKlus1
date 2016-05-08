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
	void Update () {
        transform.position = new Vector3(transform.position.x,target.transform.position.y+yOffset,transform.position.z);
	}
}
