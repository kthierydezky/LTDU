using UnityEngine;
using System.Collections;

public class King : Units
{
    void Update()
    {
        if (inRangeUnits.Count != 0)
        {
            if (!(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") || animator.GetCurrentAnimatorStateInfo(0).IsName("StandReady")))
            {
                animator.SetTrigger("Attack");
            }
        }
    }

    override public void UnitDetectionEnter(Collider other)
    {
        if (other.tag == "Creep")
        {
            Units temp = other.gameObject.GetComponent<Units>();
            if (temp != null)
            {
                inRangeUnits.Add(temp);
            }
        }
    }


    override public void UnitDetectionExit(Collider other)
    {
        if (other.tag == "Creep")
        {
            Units temp = other.GetComponent<Units>();
            if (inRangeUnits.Contains(temp))
            {
                inRangeUnits.Remove(temp);
            }
        }
    }

    override public void Attack()
    {
        if (inRangeUnits.Count != 0)
        {
            inRangeUnits[0].TakeDamage(Random.Range((int)attack.x, (int)attack.y), dt);
        }
    }
}
