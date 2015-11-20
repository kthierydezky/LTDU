using UnityEngine;
using System.Collections;

public class Tower : Units
{
    private Vector3 Emplacement;

    private static float minDistOfEmplacement = 0.2f;

    override public void Start()
    {
        base.Start();
        Emplacement = gameObject.transform.position;
    }
	// Update is called once per frame
	void Update () {
        if (inRangeUnits.Count != 0)
        {
            if (Vector3.Distance(gameObject.transform.position, inRangeUnits[0].transform.position) >= range)
            {
                agent.SetDestination(inRangeUnits[0].transform.position);
                agent.Resume();
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
                {
                    animator.SetTrigger("Walk");
                    
                }
            }
            else
            {
                gameObject.transform.LookAt(inRangeUnits[0].transform.position);
                if (!(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") || animator.GetCurrentAnimatorStateInfo(0).IsName("StandReady")))
                {
                    animator.SetTrigger("Attack");
                }
                agent.Stop();
            }
        }
        else
        {
            //Debug.Log(Vector3.Distance(gameObject.transform.position, Emplacement) + " " + gameObject.transform.position + " " + Emplacement);
            if (Vector3.Distance(gameObject.transform.position, Emplacement) > minDistOfEmplacement)
            {
                agent.SetDestination(Emplacement);
                agent.Resume();
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
                {
                    animator.SetTrigger("Walk");

                }
            }
            else
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
                {
                    animator.SetTrigger("Stand");

                }
            }
        }
	}

    void LateUpdate()
    {
        
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
        if (inRangeUnits.Count != 0) {
            inRangeUnits[0].TakeDamage(Random.Range((int)attack.x, (int)attack.y),dt);
        }
    }


}
