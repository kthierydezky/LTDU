using UnityEngine;
using System.Collections;
[System.Serializable]
public class HitPoint{
    private float actualHitPoint = 0.0f;
    [SerializeField]
    public float maxHitPoint;

    public void Init()
    {
        actualHitPoint = maxHitPoint;
    }

    public bool RemoveHitPoint(float hpToRemove)
    {
        actualHitPoint -= hpToRemove;
        if(actualHitPoint > 0.0f)
        {
            return true;
        }

        return false;
    }

}
