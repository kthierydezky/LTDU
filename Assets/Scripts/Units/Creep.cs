using UnityEngine;
using System.Collections;

public class Creep : MonoBehaviour {

    public Transform roadTarget;
    NavMeshAgent agent;



    public float attackRange = 1.0f;


    private int actualRoadPoint = 0;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        if(roadTarget != null)
        {
            agent.SetDestination(roadTarget.GetChild(actualRoadPoint).transform.position);
            
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
}
