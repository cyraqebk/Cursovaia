using UnityEngine;

namespace Core.Entitys
{
    public class EntitysAtack : MonoBehaviour
    {
        [SerializeField] private float _startTimeBtwAttack;
        [SerializeField] private Transform _attackPos;
        [SerializeField] private LayerMask _maskEnemy;
        [SerializeField] private float _attackRange;
        [SerializeField] private int _damage;
        [SerializeField] private Animator _anim;

        private float _timeBtwAttack;

        private void Update()
        {
            if (_timeBtwAttack <= 0)
            {
                if (Input.GetMouseButton(0))
                {
                    _anim.SetTrigger("attack");
                    Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPos.position, _attackRange, _maskEnemy);
                    foreach (Collider2D elem in enemies)
                    {
                        elem.GetComponent<Entity>().TakeDamage(_damage);
                    }
                    _timeBtwAttack = _startTimeBtwAttack;
                }
            }
            else
            {
                _timeBtwAttack -= Time.deltaTime;
            }
        }

        private void OnDrawGizmosSelected() 
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_attackPos.position, _attackRange);    
        }
    }
}
