using UnityEngine;
using System.Collections;

public class OneShotParticle : MonoBehaviour
{
    private ParticleSystem m_particle;

    void Awake()
    {
        m_particle = GetComponentInChildren<ParticleSystem>();
        m_particle.loop = false;
    }

    void Start()
    {
        if (!m_particle.isPlaying) m_particle.Play(true);
    }

    void Update()
    {
        if (m_particle != null)
        {
            if (!m_particle.isPlaying)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
