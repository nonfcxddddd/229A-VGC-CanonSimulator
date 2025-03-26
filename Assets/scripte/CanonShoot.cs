using UnityEngine;

public class CanonShoot : MonoBehaviour
{
    public Transform cannonBarrel;
    public GameObject cannonBallPrefab;
    public GameObject explosionEffectPrefab;
    public ParticleSystem shootEffect;
    public float shootForce = 20f;
    public float destroyTime = 5f;
    public float cooldownTime = 1f;
    public AudioClip shootClip;
    public AudioClip explosionClip;
    public AudioSource audioSource;
    public float cannonBallMass = 1f; 

    private float nextShootTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + cooldownTime;
        }
    }

    void Shoot()
    {
        if (shootEffect != null)
        {
            Instantiate(shootEffect, cannonBarrel.position, Quaternion.identity);
        }

        if (audioSource != null && shootClip != null)
        {
            audioSource.PlayOneShot(shootClip);
        }

        GameObject cannonBall = Instantiate(cannonBallPrefab, cannonBarrel.position, cannonBarrel.rotation);
        Rigidbody rb = cannonBall.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.mass = cannonBallMass;
            float force = cannonBallMass * shootForce; // F=ma
            rb.AddForce(cannonBarrel.forward * force, ForceMode.Impulse);
        }

        CannonBallLogic ballLogic = cannonBall.AddComponent<CannonBallLogic>();
        ballLogic.explosionEffectPrefab = explosionEffectPrefab;
        ballLogic.explosionClip = explosionClip;

        Destroy(cannonBall, destroyTime);
    }
}

public class CannonBallLogic : MonoBehaviour
{
    public GameObject explosionEffectPrefab;
    public string cannonTag = "Cannon";
    public AudioClip explosionClip;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(cannonTag))
        {
            return;
        }

        if (explosionEffectPrefab != null)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }

        if (explosionClip != null)
        {
            AudioSource.PlayClipAtPoint(explosionClip, transform.position);
        }

        Destroy(gameObject);
    }
}