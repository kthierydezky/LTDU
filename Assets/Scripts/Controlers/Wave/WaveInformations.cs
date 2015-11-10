using UnityEngine;
using System.Collections;

[System.Serializable]
public class WaveInformations{
    [SerializeField]
    public Transform creepToSpawn;
    public int nbCreep;

    private int _actualNbSpawnedCreep { get; set; }

    public int actualNbSpawnedCreep
    {
        get { return _actualNbSpawnedCreep; }
        set { _actualNbSpawnedCreep = value; }
    }
}
