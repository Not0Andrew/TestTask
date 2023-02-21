using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private int damage;

    [SerializeField] private Transform bulletStartPoint;
    
    [SerializeField] private BulletPool pool;

    private void Start()
    {
        pool.Initialize(20);
    }

    public void Fire(Vector3 forward)
    {
        Bullet temp = pool.GetObject();

        temp.gameObject.transform.position = bulletStartPoint.position;
        
        temp.SetFireSettings(forward, damage);
        
        temp.gameObject.SetActive(true);
    }
}
