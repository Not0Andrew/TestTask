using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void Begin()
    {
        LevelProgress.Instance.NextPoint();
    }
}
