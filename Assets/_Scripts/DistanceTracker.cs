using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DistanceTracker : MonoBehaviour {

    [SerializeField]
    private GameObject spawnPos;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private BoxCollider counterTrigger;
    private bool startCounter = false;
    [SerializeField]
    private Text counterText;
    private string eenheid;

    private Vector3 lastPosition;
    float distanceTraveled = 0;

    public bool _startCounter {
        get { return startCounter; }
        set { startCounter = value; }
    }

	// Use this for initialization
	void Start () {
        counterText = gameObject.GetComponent<Text>();
        player.transform.position = spawnPos.transform.position;
        lastPosition = counterTrigger.transform.position;
        eenheid = " meters";
        counterText.text = "0" + eenheid;
	}
	
	// Update is called once per frame
	void Update () {
        StartTracker();
        checkTraveledDistance();
	}

    void StartTracker() {
        if (startCounter) {
            counterText.text = distanceTraveled.ToString("N0") + eenheid;
        }
    }

    void checkTraveledDistance() {
        distanceTraveled = lastPosition.y - player.transform.position.y;
        lastPosition = counterTrigger.transform.position;
        if (distanceTraveled > 1000)
        {
            eenheid = " kilometers";
        }
        else {
            eenheid = " meters";
        }
    }

}
