using System.Collections.Generic;
using UnityEngine;

public class LevelPoint : MonoBehaviour
{
    public List<EnemyUnit> EnemyUnits;

    private void RemoveUnit(EnemyUnit unit)
    {
        unit.OnDeath -= RemoveUnit;
        EnemyUnits.Remove(unit);

        if (EnemyUnits.Count <= 0)
        {
            LevelProgress.Instance.NextPoint();
        }
    }

    public void Activate()
    {
        foreach (var unit in EnemyUnits)
        {
            unit.enabled = true;
            unit.OnDeath += RemoveUnit;
        }
    }
}
