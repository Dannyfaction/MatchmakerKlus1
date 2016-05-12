using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour {

    public delegate void DeadEvent();
    public static event DeadEvent OnDeadEvent;

    public delegate void ImpaleEvent(Collision collider);
    public static event ImpaleEvent OnImpaleEvent;

    private float hitDelay;
    private float slowmotionDelay;
    [SerializeField] private Player playerScript;

	void Start () {

	}
	
	void Update () {
        if (hitDelay > 0)
        {
            hitDelay -= Time.deltaTime;
        }
        if (slowmotionDelay > 0)
        {
            slowmotionDelay -= Time.deltaTime;
            Time.timeScale = 0.1f;
            Time.fixedDeltaTime = 0.001f;
        }
        /*
        else
        {
            //Time.timeScale = 1f;
            //Time.fixedDeltaTime = 0.02f;
        }
        */
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.transform.tag != "Player" && hitDelay <= 0)
        {
            if ((transform.name == "Root_M" || transform.name == "Spine1_M (joint)") && collider.transform.name == "Spike")
            {
                //When you get impaled
                OnImpaleEvent(collider);
                Debug.Log("Je bent gespiest G");
                Invoke("RestartLevel", 2f);
            }
            else if((transform.name == "Root_M" || transform.name == "Spine1_M (joint)") && collider.transform.name != "Spike" && !playerScript.IsImpaled && collider.transform.tag != "Walls")
            {
                //When your torso hits something
                OnDeadEvent();
                Debug.Log("Je bent dood G");
                Invoke("RestartLevel",0.25f);
                slowmotionDelay = 0.1f;
                //playerScript.GettingHit();
            }
            else
            {
                //When your limbs hit something
            }
        }
    }

    void RestartLevel()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene("Menu");
        //Application.LoadLevel("Menu");
    }
}