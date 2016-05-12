using UnityEngine;
using System.Collections;

public class ParticlePlayer : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem bloodExplosion;
    [SerializeField]
    private ParticleSystem bloodBursts;

    // Use this for initialization
    void Start()
    {
        CollisionDetection.OnDeadEvent += BloodExplosion;
        CollisionDetection.OnImpaleEvent += BloodBursts;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BloodExplosion()
    {
        bloodExplosion.Play();
    }

    void BloodBursts(Collision collision)
    {
        bloodBursts.Play();
    }

    void OnDestroy()
    {
        CollisionDetection.OnDeadEvent -= BloodExplosion;
        CollisionDetection.OnImpaleEvent -= BloodBursts;
    }
}
