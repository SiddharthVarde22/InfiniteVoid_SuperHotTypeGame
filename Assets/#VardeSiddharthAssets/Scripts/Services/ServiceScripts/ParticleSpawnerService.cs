using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawnerService : MonoBehaviour, IGameService
{
    GenericObjectPool<ParticleSystemBehaviour> pooledParticles = new GenericObjectPool<ParticleSystemBehaviour>();

    [SerializeField]
    ParticleSystemBehaviour particleSystemPrefab;

    public void RegisterService(TypesOfService typesOfService, IGameService gameService)
    {
        ServiceLocator.Instance.RegesterService<ParticleSpawnerService>(typesOfService, (ParticleSpawnerService)gameService);
    }

    private void OnEnable()
    {
        RegisterService(TypesOfService.ParticleSpawner, this);
    }

    public void GetParticles(Vector3 position)
    {
        ParticleSystemBehaviour particleSystemBehaviour = null;
        particleSystemBehaviour = pooledParticles.GetObjectFromPool();

        if(particleSystemBehaviour == null)
        {
            particleSystemBehaviour = Instantiate<ParticleSystemBehaviour>(particleSystemPrefab);
        }

        particleSystemBehaviour.EnableParticle(position);
    }

    public void ReturnParticleSystem(ParticleSystemBehaviour particleSystem)
    {
        pooledParticles.ReturnObjectInPool(particleSystem);
    }
}
