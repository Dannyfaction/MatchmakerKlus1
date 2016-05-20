using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour {

    public delegate void DeadEvent();
    public static event DeadEvent OnDeadEvent;

    public delegate void ImpaleEvent(Collision collider);
    public static event ImpaleEvent OnImpaleEvent;

    private float hitDelay;
    private static bool slowmotionDelay;
    [SerializeField] private Player playerScript;

    private static bool isDead;

	void Start () {
        isDead = false;
	}
	
	void Update () {
        if (hitDelay > 0)
        {
            hitDelay -= Time.deltaTime;
        }
        if (slowmotionDelay)
        {
            Time.timeScale = 0.1f;
            Time.fixedDeltaTime = 0.001f;
            Invoke("ResetTime",0.15f);
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.transform.tag != "Player" && hitDelay <= 0 && !isDead)
        {
            if ((transform.name == "Hip" || transform.name == "Spine2(joint)") && collider.transform.name == "Spike")
            {
                //When you get impaled
                OnImpaleEvent(collider);
                Invoke("RestartLevel", 2f);
                isDead = true;
            }
            else if((transform.name == "Hip" || transform.name == "Spine2(joint)" || transform.name == "Head_base(joint)") && collider.transform.name != "Spike" && !playerScript.IsImpaled && collider.transform.tag != "Walls")
            {
                //When your torso hits something
                OnDeadEvent();
                Invoke("RestartLevel",2f);
                slowmotionDelay = true;
                isDead = true;
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
        SceneManager.LoadScene(Application.loadedLevel);
        //Application.LoadLevel("Menu");
    }

    void ResetTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        slowmotionDelay = false;
    }
}