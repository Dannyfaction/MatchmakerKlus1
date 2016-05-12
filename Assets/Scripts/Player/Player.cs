using UnityEngine;
using System.Collections;

public class Player : SoundPlayer
{
    private Vector3 mousePosition;
    private float moveSpeed = 1.5f;
    private static Rigidbody rigidbody;
    private bool isJumping;
    private float health = 100;
    private bool isImpaled;
    public bool IsImpaled
    {
        get { return isImpaled; }
    }
    private float impaleCounter;
    private GameObject spike;
    private Vector3 impalePosition;
    public float Health
    {
        get { return health; }
    }
    private float hitDelay;
    private double fallingSpeed;
    public double FallingSpeed
    {
        get { return fallingSpeed; }
    }

    //Change the Mouse Range by changing the field of view on "Player Camera"

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        CollisionDetection.OnImpaleEvent += GettingImpaled;
        CollisionDetection.OnDeadEvent += GettingHit;
    }

    void Update()
    {
        if (impaleCounter > 0)
        {
            impaleCounter -= Time.deltaTime;
        }
        if (hitDelay > 0)
        {
            hitDelay -= Time.deltaTime;
        }
        fallingSpeed = rigidbody.velocity.magnitude * 3.6;
        RotatePlayer();
        mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        mousePosition.z = 1f;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 newPos = new Vector3(mousePosition.x, transform.position.y, mousePosition.z);
        if (!isImpaled)
        {
            transform.position = Vector3.Lerp(transform.position, newPos, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = impalePosition;
            if (impaleCounter > 0)
            {
                transform.Translate(Vector3.down * Time.deltaTime * 0.1f, Space.World);
                impalePosition = transform.position;
            }
        }
    }

    void RotatePlayer()
    {
        //rigidbody.velocity = Vector3.zero;
        //rigidbody.AddTorque(-transform.forward * 70f);
    }

    public void GettingHit()
    {
        /*
        if (hitDelay <= 0)
        {
            if (rigidbody.velocity.y <= -10)
            {
                //Time.timeScale = 0.1f;
                hitDelay = 1f;
                slowmotionDelay = 0.1f;
                health -= 10;
                if (health <= 0)
                {
                    Application.LoadLevel("End");
                }
            }
        }
        */
    }

    public void GettingImpaled(Collision collision)
    {
        if (!isImpaled)
        {
            impalePosition = transform.position;
            impaleCounter = 3f;
            PlayScream();
        }
        isImpaled = true;
        spike = collision.gameObject;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |  RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        Rigidbody rootRigidBody = transform.root.GetComponent<Rigidbody>();
        rootRigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        Rigidbody[] rigidBodies = GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < rigidBodies.Length; i++)
        {
            rigidBodies[i].constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }

    }

    void OnDestroy()
    {
        CollisionDetection.OnImpaleEvent -= GettingImpaled;
        CollisionDetection.OnDeadEvent -= GettingHit;
    }
}
