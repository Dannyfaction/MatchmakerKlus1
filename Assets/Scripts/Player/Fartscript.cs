using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fartscript : MonoBehaviour {

    private float counter;
    private bool isJumping;
    private float cooldown = 5f;
    private Rigidbody rigidbody;
    [SerializeField] private Image fartImage;
    private AudioSource[] fartSounds;

	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        fartSounds = GetComponents<AudioSource>();
	}
	
	void Update () {
        fartImage.fillAmount = (cooldown / 5);
        if (counter > 0)
        {
            counter -= Time.deltaTime;
        }
        if (cooldown <= 5)
        {
            cooldown += Time.deltaTime;
        }
        if (Input.GetKeyDown("space") && cooldown >= 5)
        {
            isJumping = true;
            RandomSound();
            counter = 0.5f;
            cooldown = 0f;
        }
        if (counter <= 0)
        {
            isJumping = false;
        }
        if (isJumping)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(Vector3.up * Time.deltaTime * 50000f);
        }
    }

    void RandomSound()
    {
        int randomNumber = Random.Range(0,4);
        fartSounds[randomNumber].Play();
    }
}
