using UnityEngine;
using System.Collections;

public class Smasher : MonoBehaviour {

    private bool forward = true;
    [SerializeField] private bool mirrored;
    [SerializeField] private float targetZValue;
    private float initialZValue;
    private float forwardSpeed = 7.5f;
    private float reverseSpeed = 1f;

	void Start () {
        initialZValue = transform.position.z;
	}
	
	void Update () {
        if (!mirrored)
        {
            if (targetZValue < transform.position.z && forward)
            {
                transform.Translate(-Vector3.forward * Time.deltaTime * forwardSpeed);
                if (targetZValue >= transform.position.z && forward)
                {
                    forward = false;
                }
            }
            if (transform.position.z < initialZValue && !forward)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * reverseSpeed);
                if (initialZValue <= transform.position.z && !forward)
                {
                    forward = true;
                }
            }
        }
        else
        {
            if (targetZValue > transform.position.z && forward)
            {
                transform.Translate(-Vector3.forward * Time.deltaTime * forwardSpeed);
                if (targetZValue <= transform.position.z && forward)
                {
                    forward = false;
                }
            }
            if (transform.position.z > initialZValue && !forward)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * reverseSpeed);
                if (initialZValue >= transform.position.z && !forward)
                {
                    forward = true;
                }
            }
        }
        
	}
}
