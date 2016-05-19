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
        audioSources[randomNumber].Play();
        
    }

    protected void PlayScream()
    {
        audioSources = GetComponents<AudioSource>();
        int randomNumer = Random.Range(4,7);
        audioSources[randomNumer].Play();
    }
}
