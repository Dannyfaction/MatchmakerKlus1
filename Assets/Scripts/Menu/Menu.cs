using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    private int currentLevel = 1;
    private float cooldown = 0;
    [SerializeField] private GameObject levelImage;
    private float newXValue ;
    private float imageMoveSpeed = 3000f;
    [SerializeField] private GameObject leftArrow;
    [SerializeField] private GameObject rightArrow;

    void Start () {
        newXValue = levelImage.transform.localPosition.x;
	}
	
	void Update () {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        if (levelImage.transform.localPosition.x > newXValue)
        {
            levelImage.transform.Translate(Vector3.left * Time.deltaTime * imageMoveSpeed);
        }
        if (levelImage.transform.localPosition.x < newXValue)
        {
            levelImage.transform.Translate(Vector3.right * Time.deltaTime * imageMoveSpeed);
        }
	}

    public void ChangeLevelImageUp()
    {
        if (cooldown <= 0 && currentLevel < 4)
        {
            cooldown = 0.9f;
            newXValue -= 1000;
            currentLevel++;
            if (currentLevel == 4)
            {
                rightArrow.SetActive(false);
            }
        }
    }
    public void ChangeLevelImageDown()
    {
        if (cooldown <= 0 && currentLevel > 1)
        {
            cooldown = 0.9f;
            newXValue += 1000;
            currentLevel--;
            if (currentLevel == 1)
            {
                leftArrow.SetActive(false);
            }
        }
    }

    public void PlayLevel()
    {
        switch (currentLevel)
        {
            default:
                Application.LoadLevel("Main");
                break;
        }
    }
}