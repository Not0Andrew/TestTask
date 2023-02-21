using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    private int _damage;
    private Vector3 _endPos;
    
    public void SetFireSettings(Vector3 endPos, int damage)
    {
        _endPos = endPos;
        _damage = damage;
    }
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _endPos, Time.deltaTime * speed);
        
        if (transform.position == _endPos)
        {
            Invoke(nameof(DisableBullet),0.3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag($"Enemy"))
        {
            other.gameObject.GetComponent<EnemyUnit>().GetDamage(_damage);
        }

        DisableBullet();
    }

    private void DisableBullet()
    {
        gameObject.SetActive(false);
    }
}
