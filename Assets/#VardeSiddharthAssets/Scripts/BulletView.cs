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
    }

    public void Disable()
    {
        ServiceLocator.Instance.GetService<BulletSpawnerService>(TypesOfService.BulletSpawner).DisableBullet(this);
        bulletRigidbody.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //check for damagables
        Disable();
    }
}
