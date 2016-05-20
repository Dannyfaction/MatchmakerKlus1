using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {

    private AudioSource[] audioSources;

	// Use this for initialization
	void Awake () {
        audioSources = GetComponents<AudioSource>();
        CollisionDetection.OnDeadEvent += PlayScream;
    }

    protected void PlayFart()
    {
        int randomNumber = Random.Range(0, 4);
        audioSources[randomNumber].Play();
        
    }

    protected void PlayScream()
    {
        audioSources = GameObject.Find("Minion_unity").transform.Find("Hip").GetComponents<AudioSource>();
        int randomNumer = Random.Range(4,7);
        audioSources[randomNumer].Play();
    }

    void OnDestroy()
    {
        CollisionDetection.OnDeadEvent -= PlayScream;
    }
}
