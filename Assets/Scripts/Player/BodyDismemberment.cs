using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BodyDismemberment : MonoBehaviour {

    public delegate void DismembermentEvent(int bodyPartIndex);
    public static event DismembermentEvent OnDismembermentEvent;

    [SerializeField]
    private Rigidbody rootRb;
    [SerializeField]
    private int bodyPartIndex;
    

    void Start()
    {
        CollisionDetection.OnDeadEvent += RemoveFromObject;
        CollisionDetection.OnDeadEvent += CloneObject;
    }

    void OnCollisionEnter(Collision col) {
        if (col.transform.tag != transform.tag && rootRb.velocity.y < -5) {
                OnDismembermentEvent(bodyPartIndex);
                RemoveFromObject();
        }
    }

    void RemoveFromObject()
    {
        if (gameObject.GetComponent<CharacterJoint>()) {
            GameObject.Destroy(gameObject.GetComponent<CharacterJoint>());
        }
        if (gameObject.GetComponent<Collider>())
        {
            GameObject.Destroy(gameObject.GetComponent<Collider>());
        }
        if (gameObject.GetComponent<Rigidbody>())
        {
            GameObject.Destroy(gameObject.GetComponent<Rigidbody>());
        }
        if (gameObject.GetComponentInChildren<MeshRenderer>()) {
            Destroy(gameObject);
            CloneObject();              
        }
    }

    void CloneObject()
    {
        GameObject clonedObject = Instantiate(Resources.Load(gameObject.GetComponentInChildren<MeshRenderer>().name), gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        clonedObject.AddComponent<Rigidbody>();
        clonedObject.AddComponent<CapsuleCollider>();
        clonedObject.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
    }

    void OnDestroy()
    {
        CollisionDetection.OnDeadEvent -= RemoveFromObject;
        CollisionDetection.OnDeadEvent -= CloneObject;
    }
}
