using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (_levelPointId == points.Count - 1)
        {
            StartCoroutine(Finish());
        }
    }

    private IEnumerator Finish()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
