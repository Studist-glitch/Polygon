using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    private Dictionary<string, ParticleSystem> particles;

    private void Start()
    {
        particles = new();

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            ParticleSystem particle = child.GetComponent<ParticleSystem>();

            particles.Add(child.name, particle);
        }
    }

    public async Task<ParticleSystem> TryActive(string particleName, Vector3 position)
    {
        if (particles.TryGetValue(particleName, out ParticleSystem particle) && !particle.isPlaying)
        {
            particle.Clear();
            particle.transform.position = position;
            particle.Play();
            
            return particle;
        }

        return null;
    }
}