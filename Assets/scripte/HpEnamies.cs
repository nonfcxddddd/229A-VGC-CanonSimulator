using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f; // ค่าเลือดสูงสุด
    private float currentHealth; // ค่าเลือดปัจจุบัน

    public GameObject deathEffectPrefab; // เอฟเฟกต์เมื่อเลือดหมด

    void Start()
    {
        currentHealth = maxHealth; // ตั้งค่าเลือดเริ่มต้น
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " ได้รับดาเมจ: " + damage + " | เลือดที่เหลือ: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " ตายแล้ว!");

        // แสดงเอฟเฟกต์ตอนตาย
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }

        // ทำลายตัวเอง
        Destroy(gameObject);
    }
}