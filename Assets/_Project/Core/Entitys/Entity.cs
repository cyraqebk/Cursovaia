using UnityEngine;

namespace Core.Entitys
{
    public class Entity : MonoBehaviour
    {
        public float maxHealth { get; private set; } = 100f;
        public float currentHealth { get; private set; }
        public float damage { get; private set; } = 10f;

        public void UpdateData(float? CurrentHealth = null, float? MaxHealth = null, float? Damage = null)
        {
            if (CurrentHealth.HasValue) currentHealth = CurrentHealth.Value;
            if (MaxHealth.HasValue) maxHealth = MaxHealth.Value;
            if (Damage.HasValue) damage = Damage.Value;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Death();
            }
        }

        public void Death()
        {

        }
    }
}
