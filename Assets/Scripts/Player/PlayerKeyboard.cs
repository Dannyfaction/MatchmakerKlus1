using UnityEngine;
using System.Collections;

public class PlayerKeyboard : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("up"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 2f);
        }
        if (Input.GetKey("down"))
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * 2f);
        }
        if (Input.GetKey("left"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 2f);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 2f);
        }
    }
}
