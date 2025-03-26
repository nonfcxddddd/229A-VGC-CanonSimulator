using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f; // ������ʹ�٧�ش
    private float currentHealth; // ������ʹ�Ѩ�غѹ

    public GameObject deathEffectPrefab; // �Ϳ࿡����������ʹ���

    void Start()
    {
        currentHealth = maxHealth; // ��駤�����ʹ�������
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " ���Ѻ�����: " + damage + " | ���ʹ��������: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " �������!");

        // �ʴ��Ϳ࿡��͹���
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }

        // ����µ���ͧ
        Destroy(gameObject);
    }
}