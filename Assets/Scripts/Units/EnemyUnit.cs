using UnityEngine;
using UnityEngine.Events;

public class EnemyUnit : MonoBehaviour
{
    [SerializeField] private int _Hp;

    public UnityAction<EnemyUnit> OnDeath;

    private void Start()
    {
        this.enabled = false;
    }

    public void GetDamage(int damage)
    {
        _Hp -= damage;

        if (_Hp <= 0)
        {
            Death();
        }
    }
    
    private void Death()
    {
        OnDeath.Invoke(this);
        Destroy(gameObject);
    }
}
