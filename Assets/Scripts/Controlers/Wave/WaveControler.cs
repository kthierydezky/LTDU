using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveControler : MonoBehaviour {
    public Transform creepSpawn;
    public Transform creepRoad;
    public List<WaveInformations> waveInfo = new List<WaveInformations>();
    public float timeBetweenEachSpawn;

    private Vector2 gapRandomizer = new Vector2(11,6);

    private int actualWave = 0;
     

	// Use this for initialization
	void Start() {
        StartWave();
	}

    public void StartWave()
    {
        StartCoroutine(SpawnAndWait());
        
    }


    public IEnumerator SpawnAndWait()
    {

        Vector3 randomizedPosition = new Vector3(creepSpawn.transform.position.x + Random.Range(-gapRandomizer.x/2f, gapRandomizer.x / 2f), creepSpawn.transform.position.y, creepSpawn.transform.position.z + Random.Range(-gapRandomizer.y / 2f, gapRandomizer.y / 2f));
        Transform test = (Transform)Instantiate(waveInfo[actualWave].creepToSpawn, randomizedPosition, creepSpawn.transform.rotation);
        test.GetComponent<Creep>().roadTarget = creepRoad;
        waveInfo[actualWave].actualNbSpawnedCreep++;
        yield return new WaitForSeconds(timeBetweenEachSpawn);
        
        if(waveInfo[actualWave].actualNbSpawnedCreep < waveInfo[actualWave].nbCreep)
        {
            StartCoroutine(SpawnAndWait());
        }
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            Time.timeScale += 1;
        }

        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            Time.timeScale -= 1;
        }
    }
}
