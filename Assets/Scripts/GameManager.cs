using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        LevelProgress.Instance.NextPoint();
    }
}
