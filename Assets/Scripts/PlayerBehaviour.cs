using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    private Vector3 mousePosition;
    private float moveSpeed = 1.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        mousePosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z);
        mousePosition.z = 5f;
        //mousePosition.y = transform.position.y;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 newPos = new Vector3(mousePosition.x,transform.position.y,mousePosition.z);
        transform.position = Vector3.Lerp(transform.position,newPos,moveSpeed*Time.deltaTime);
    }
}
