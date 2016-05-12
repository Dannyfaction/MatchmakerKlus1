using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeedDisplay : MonoBehaviour {

    [SerializeField]
    private Player playerScript;
    [SerializeField] private Text fallingSpeedText;
    private double fallingSpeed;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        fallingSpeed = playerScript.FallingSpeed;
        float floatSpeed = (float)fallingSpeed;
        fallingSpeed = Mathf.Round(floatSpeed * 1f) / 1f;
        fallingSpeedText.text = "Falling Speed: " + fallingSpeed + " Km/h";
	}
}