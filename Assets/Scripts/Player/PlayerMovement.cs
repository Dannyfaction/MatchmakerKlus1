using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 mousePosition;
    private float moveSpeed = 1.5f;
    private Rigidbody rigidbody;
    private bool isJumping;
    private float health = 100;
    private float hitDelay;
    private float fallingSpeed;
    public float FallingSpeed
    {
        get { return fallingSpeed; }
    }

    //Change the Mouse Range by changing the field of view on "Player Camera"

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        fallingSpeed = Mathf.Abs(rigidbody.velocity.y);
        if (hitDelay > 0)
        {
            hitDelay -= Time.deltaTime;
        }
        RotatePlayer();
        mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        mousePosition.z = 1f;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 newPos = new Vector3(mousePosition.x, transform.position.y, mousePosition.z);
        transform.position = Vector3.Lerp(transform.position, newPos, moveSpeed * Time.deltaTime);
        //transform.position = newPos;
    }

    void RotatePlayer()
    {
        rigidbody.AddTorque(-transform.forward * 35f);
    }

    public void GettingHit()
    {
        if (hitDelay <= 0)
        {
            if (rigidbody.velocity.y <= -10)
            {
                hitDelay = 1f;
                health -= 10;
                Debug.Log("auw");
                if (health <= 0)
                {
                    Application.LoadLevel("End");
                }
            }
        }
    }
}
