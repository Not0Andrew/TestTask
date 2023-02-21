using System.Collections.Generic;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    public static LevelProgress Instance;

    [SerializeField] private PlayerPerson person;
    
    [SerializeField] private List<LevelPoint> points;
    private int _levelPointId = -1;
    
    private void Awake()
    {
        Instance = this;
    }

    public void NextPoint()
    {
        _levelPointId++;
        
        if (_levelPointId < points.Count)
        {
            person.Move(points[_levelPointId].transform.position);
            points[_levelPointId].Activate();
        }
    }
}
