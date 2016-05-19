using UnityEngine;
using System.Collections;

public class CheckpointCollision : MonoBehaviour {

    public delegate void CheckPointEvent(float checkpoint);
    public static event CheckPointEvent OnCheckPointEvent;

    [SerializeField] private float currentCheckpoint;

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
            OnCheckPointEvent(currentCheckpoint);
        }
    }


}
