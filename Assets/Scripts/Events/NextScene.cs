using UnityEngine;
using System.Collections;

public class NextScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter()
    {
        switch (Application.loadedLevel)
        {
            case 1:
                Application.LoadLevel(2);
                break;
            case 2:
                Application.LoadLevel(3);
                break;
            case 3:
                Application.LoadLevel(0);
                break;
        }
    }
}
