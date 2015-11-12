using UnityEngine;
using System.Collections;

public class AggroRadius : MonoBehaviour {
    public Units motherUnits;
	// Use this for initialization
	void Start () {
        Debug.Log("Start");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (motherUnits != null)
        {
            motherUnits.UnitDetectionEnter(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (motherUnits != null)
        {
            motherUnits.UnitDetectionExit(other);
        }
    }
}
