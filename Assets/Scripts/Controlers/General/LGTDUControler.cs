using UnityEngine;
using System.Collections;

public class LGTDUControler : MonoBehaviour {

    public enum LGTDUStates{
        GameModesPicker,
        RacesPicker,
        BuildingTime,
        WaveTime,
        MiddleFightTime
    }


    /* Prefabs */
    public Transform GameModePickerPrefab;

    /* Variable de fonctionnement */
    private LGTDUStates actualLGTDUState = LGTDUStates.GameModesPicker;

    /*Refs */
    private GameObject canvasRef;
    private RTSCamera rtsCamRef;
    private GameModesPicker gmpRef;

    // Use this for initialization
    void Start () {
        InitEventMessenger();
        Init();
        ChangeToState(LGTDUStates.GameModesPicker);
    }

    public void Init() {
        canvasRef = GameObject.Find("/UI/LGTDUCanvas");
        rtsCamRef = GameObject.Find("RTSCamera").GetComponent<RTSCamera>();
    }
    
    private void InitEventMessenger()
    {
        Messenger.AddListener<GameModesPicker.GameModes, GameOptions>("GameModeSelected", OnGameModeSelected);
    }

    private void DestroyEventMessenger()
    {
        Messenger.RemoveListener<GameModesPicker.GameModes, GameOptions>("GameModeSelected", OnGameModeSelected);
    }

    public void ChangeToState(LGTDUStates state)
    {
        switch (state)
        {
            case LGTDUStates.GameModesPicker:
                actualLGTDUState = state;
                gmpRef = ((Transform)Instantiate(GameModePickerPrefab)).gameObject.GetComponent<GameModesPicker>();
                gmpRef.gameObject.transform.SetParent(canvasRef.transform,false);
                rtsCamRef.SetCamLock(true);
            break;
        }
    }

    public void OnGameModeSelected(GameModesPicker.GameModes gm, GameOptions go)
    {
        Destroy(gmpRef.gameObject);
        ChangeToState(LGTDUStates.RacesPicker);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
