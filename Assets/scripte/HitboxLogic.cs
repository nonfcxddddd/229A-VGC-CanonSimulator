using UnityEngine;

public class HitboxLogic : MonoBehaviour
{
    public float damage = 10f; // �����������

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // ��Ǩ�ͺ��Ҫ��ѵ���������
        {
            HealthSystem enemyHealth = other.GetComponent<HealthSystem>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }
}
