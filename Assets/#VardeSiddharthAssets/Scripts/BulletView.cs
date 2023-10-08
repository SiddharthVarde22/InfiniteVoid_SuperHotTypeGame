using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField]
    Rigidbody bulletRigidbody;
    [SerializeField]
    float initialForce = 5;

    public void Enable(Vector3 position, Quaternion rotation)
    {
        transform.SetPositionAndRotation(position, rotation);
        gameObject.SetActive(true);
        bulletRigidbody.AddForce(initialForce * transform.forward, ForceMode.Impulse);
        ServiceLocator.Instance.GetService<SoundService>(TypesOfService.SoundService).PlayGunShotSound(position);
    }

    public void Disable()
    {
        ServiceLocator.Instance.GetService<BulletSpawnerService>(TypesOfService.BulletSpawner).DisableBullet(this);
        bulletRigidbody.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damagableObject;

        if(collision.transform.TryGetComponent<IDamagable>(out damagableObject))
        {
            damagableObject.GetDamage();
        }

        Disable();
    }
}
