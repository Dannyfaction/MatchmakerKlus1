using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    [SerializeField] private Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x,target.transform.position.y+5f,transform.position.z);
	}
}
