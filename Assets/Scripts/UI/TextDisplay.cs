using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour {

    [SerializeField] private GameObject impaleText;
    [SerializeField] private GameObject dieText;

	// Use this for initialization
	void Start () {
        CollisionDetection.OnDeadEvent += ShowDieText;
        CollisionDetection.OnImpaleEvent += ShowImpaleText;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ShowImpaleText(Collision collider)
    {
        impaleText = GameObject.Find("Canvas").transform.Find("ImpaleText").gameObject;
        impaleText.SetActive(true);
    }

    void ShowDieText()
    {
        dieText = GameObject.Find("Canvas").transform.Find("DieText").gameObject;
        dieText.SetActive(true);
    }

    void OnDestroy()
    {
        CollisionDetection.OnDeadEvent -= ShowDieText;
        CollisionDetection.OnImpaleEvent -= ShowImpaleText;
    }
}
