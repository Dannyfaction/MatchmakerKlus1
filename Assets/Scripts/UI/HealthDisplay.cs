using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

    [SerializeField] private Player playerScript;
    [SerializeField] private Image healthImage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        healthImage.fillAmount = playerScript.Health/100;
	}
}
