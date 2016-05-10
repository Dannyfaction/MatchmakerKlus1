using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {

    private AudioSource[] audioSources;

	// Use this for initialization
	void Awake () {
        audioSources = GetComponents<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    protected void PlayFart()
    {
        int randomNumber = Random.Range(0, 4);
        Debug.Log(randomNumber);
        audioSources[randomNumber].Play();
    }

    protected void PlayScream()
    {
        int randomNumer = Random.Range(4,7);
        Debug.Log(randomNumer);
        audioSources[randomNumer].Play();
    }
}
