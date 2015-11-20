using UnityEngine;
using System.Collections;

public class Creep : Units
{

    public Transform roadTarget;

    private int actualRoadPoint = 0;

	// Update is called once per frame
	void Update () {
        if (inRangeUnits.Count != 0)
        {
            if (Vector3.Distance(gameObject.transform.position, inRangeUnits[0].transform.position) >= range)
            {
                if (!agent.enabled)
                {
                    obstacle.enabled = false;
                    agent.enabled = true;

                }
                agent.SetDestination(inRangeUnits[0].transform.position);

                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
                {
                    animator.SetTrigger("Walk");
                    obstacle.enabled = false;
                    agent.enabled = true;
                    agent.Resume();
                    
                }
            }
            else
            {
                if (!(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") || animator.GetCurrentAnimatorStateInfo(0).IsName("StandReady")))
                {
                    animator.SetTrigger("Attack");
                    if (agent.enabled) {
                        agent.Stop();
                    }
                    agent.enabled = false;
                    obstacle.enabled = true;
                }
                
            }
        }
        else
        {
            if (roadTarget != null)
            {
                if (!agent.enabled)
                {
                    obstacle.enabled = false;
                    agent.enabled = true;
                }
                agent.SetDestination(roadTarget.GetChild(actualRoadPoint).transform.position);
                
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
                {
                    obstacle.enabled = false;
                    agent.enabled = true;
                    agent.Resume();
                    animator.SetTrigger("Walk");
                    
                    
                }
            }
            else
            {
                Debug.Log("No destination and no aggro");
            }
        }
	}

    void LateUpdate()
    {
        if (Vector3.Distance(gameObject.transform.position, roadTarget.GetChild(actualRoadPoint).transform.position) < range)
        {
            if (actualRoadPoint < (roadTarget.childCount - 1))
            {
                actualRoadPoint++;
            }
        }
    }

    override public void UnitDetectionEnter(Collider other)
    {
        if(other.tag == "Tower" || other.tag == "Builder" || other.tag == "King")
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
        if (other.tag == "Tower" || other.tag == "Builder" || other.tag == "King")
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
