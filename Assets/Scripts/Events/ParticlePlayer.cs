using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticlePlayer : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem bloodExplosion;
    [SerializeField]
    private ParticleSystem bloodBursts;
    [SerializeField]
    private ParticleSystem speedLines;
    [SerializeField]
    private ParticleSystem dustParticle;
    [SerializeField]
    private List<ParticleSystem> bodyParticles;

    void Start()
    {
        CollisionDetection.OnDeadEvent += BloodExplosion;
        CollisionDetection.OnDeadEvent += Dust;
        CollisionDetection.OnImpaleEvent += BloodBursts;
        Player.OnSpeedLinesEvent += ToggleSpeedLines;
        BodyDismemberment.OnDismembermentEvent += BodyParticles;
    }

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

    void BodyParticles(int bodyPartIndex) {
        bodyParticles[bodyPartIndex].Play();
    }

    void OnDestroy()
    {
        CollisionDetection.OnDeadEvent -= BloodExplosion;
        CollisionDetection.OnDeadEvent -= Dust;
        CollisionDetection.OnImpaleEvent -= BloodBursts;
        Player.OnSpeedLinesEvent -= ToggleSpeedLines;
        BodyDismemberment.OnDismembermentEvent -= BodyParticles;
    }

    void ToggleSpeedLines()
    {
        if (speedLines.isPlaying)
        {
            speedLines.Stop();
        }
        else
        {
            speedLines.Play();
        }
    }

    void Dust()
    {
        dustParticle.Play();
    }
}
