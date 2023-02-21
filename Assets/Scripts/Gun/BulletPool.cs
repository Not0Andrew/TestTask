using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private List<Bullet> _objects = new List<Bullet>();
    [SerializeField] private Bullet bulletPrefab;
    
    
    public void Initialize(int countBullet)
    {
        for (int i = 0; i < countBullet; i++)
        {
            AddObject();
        }
    }

    private void AddObject()
    {
        Bullet temp = Instantiate(bulletPrefab);
        
        _objects.Add(temp);
        temp.gameObject.SetActive(false);
    }

    public Bullet GetObject()
    {
        foreach (var obj in _objects)
        {
            if (obj.gameObject.activeInHierarchy == false)
            {
                return obj;
            }
        }
        
        AddObject();
        return _objects[_objects.Count-1];
    }
}
