using UnityEngine;
using System.Collections;

public class Creep : Units
{

    public Transform roadTarget;
    NavMeshAgent agent;



    public float attackRange = 7.0f;


    private int actualRoadPoint = 0;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        if(inRangeUnits.Count != 0)
        {
            if(Vector3.Distance(gameObject.transform.position, inRangeUnits[0].transform.position) >= attackRange)
            {
                agent.SetDestination(inRangeUnits[0].transform.position);
            }else{
                agent.Stop();
            }
        }
        else
        {
            if (roadTarget != null)
            {
                agent.SetDestination(roadTarget.GetChild(actualRoadPoint).transform.position);

            }
        }
	}

    void LateUpdate()
    {
        if (Vector3.Distance(gameObject.transform.position, roadTarget.GetChild(actualRoadPoint).transform.position) < attackRange)
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
}
