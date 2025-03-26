using UnityEngine;

public class CannonballBoom : MonoBehaviour
{
    public GameObject explosionEffect; // Particle Effect Prefab
    public float destroyDelay = 0.1f; // หน่วงเวลาทำลายลูกปืนหลังจากชน

    void OnCollisionEnter(Collision collision)
    {
        // สร้างเอฟเฟกต์ระเบิดที่ตำแหน่งชน
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // ทำลายลูกปืน
        Destroy(gameObject, destroyDelay);
    }
}