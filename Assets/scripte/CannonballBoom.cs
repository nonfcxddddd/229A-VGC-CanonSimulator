using UnityEngine;

public class CannonballBoom : MonoBehaviour
{
    public GameObject explosionEffect; // Particle Effect Prefab
    public float destroyDelay = 0.1f; // ˹�ǧ���ҷ�����١�׹��ѧ�ҡ��

    void OnCollisionEnter(Collision collision)
    {
        // ���ҧ�Ϳ࿡�����Դ�����˹觪�
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // ������١�׹
        Destroy(gameObject, destroyDelay);
    }
}