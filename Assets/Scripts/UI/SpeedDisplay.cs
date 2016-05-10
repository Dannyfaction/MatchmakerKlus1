using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeedDisplay : MonoBehaviour {

    [SerializeField]
    private Player playerScript;
    [SerializeField] private Text fallingSpeedText;
    private float fallingSpeed;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        fallingSpeed = playerScript.FallingSpeed;
        fallingSpeed = Mathf.Round(fallingSpeed * 1f) / 1f;
        fallingSpeedText.text = "Falling Speed: " + fallingSpeed;
	}
}