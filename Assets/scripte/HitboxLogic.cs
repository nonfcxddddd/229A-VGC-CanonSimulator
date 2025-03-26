using UnityEngine;

public class HitboxLogic : MonoBehaviour
{
    public float damage = 10f; // ดาเมจที่ทำได้

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // ตรวจสอบว่าชนศัตรูหรือไม่
        {
            HealthSystem enemyHealth = other.GetComponent<HealthSystem>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }
}
