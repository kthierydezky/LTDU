using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Units : MonoBehaviour {

    protected List<Units> inRangeUnits =new List<Units>();

    virtual public void UnitDetectionEnter(Collider other)
    {

    }


    virtual public void UnitDetectionExit(Collider other) {

    }
    
}
