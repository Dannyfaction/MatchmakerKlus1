using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    private Vector3 mousePosition;
    private float moveSpeed = 1.5f;
    private Rigidbody rigidbody;
    private bool isJumping;
    private float counter;

    //Change the Mouse Range by changing the field of view on "Player Camera"

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        counter -= Time.deltaTime;
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
        //rigidbody.AddTorque(-transform.forward * 35f);
    }
}
