using UnityEngine;
using System.Collections;

public class ProgressDisplay : MonoBehaviour {
    [SerializeField] private GameObject progressImage;
    private float startXPosition;

    
	void Start () {
        startXPosition = progressImage.transform.position.x;
        CheckpointCollision.OnCheckPointEvent += ChangePosition;
    }
	
	// Update is called once per frame
	void Update () {

    }

    void ChangePosition(float checkpoint)
    {
        progressImage.transform.position = new Vector3(startXPosition + (checkpoint * 19.8f), progressImage.transform.position.y, progressImage.transform.position.z);
    }

    void OnDestroy()
    {
        CheckpointCollision.OnCheckPointEvent -= ChangePosition;
    }
}
