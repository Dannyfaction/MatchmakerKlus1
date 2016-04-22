using UnityEngine;
using System.Collections;

public class TransparentTest : MonoBehaviour {

    private Renderer renderer;
    [SerializeField] private Transform target;
    private float distance;
    private float transparentValue;
    [SerializeField] private float yOffset;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        distance = target.position.y - (transform.position.y+yOffset);
        transparentValue = (distance / 5)-1f;
        //Debug.Log(distance);
        Debug.Log(transparentValue);
        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, transparentValue);
    }
}