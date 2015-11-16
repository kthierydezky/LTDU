using UnityEngine;
using System.Collections;

public class AggroRadius : MonoBehaviour {
    public Units motherUnits;

    private SphereCollider sCollider;

	
	// Update is called once per frame
	void Update () {
	
	}

    public void Init(float s)
    {
        sCollider = gameObject.GetComponent<SphereCollider>();
        sCollider.radius = s;
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
