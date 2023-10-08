
using UnityEngine;

public class ParticleSystemBehaviour : MonoBehaviour
{
    private void OnParticleSystemStopped()
    {
        DisableParticle();
    }

    public void EnableParticle(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

    private void DisableParticle()
    {
        gameObject.SetActive(false);
        
    }
}
