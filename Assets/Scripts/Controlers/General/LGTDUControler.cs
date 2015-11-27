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
    public Transform RaceSelectorsPickerPrefab;
    public Transform BuildPickerPrefab;
    public Transform CommonPickerPrefab;

    /* Variable de fonctionnement */
    private LGTDUStates actualLGTDUState = LGTDUStates.GameModesPicker;

    /*Refs */
    private GameObject canvasRef;
    private RTSCamera rtsCamRef;
    private GameModesPicker gmpRef;
    private RaceSelectorsPicker rspRef;
    private BuildPicker bpRef;
    private CommonPicker cpRef;

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
        Messenger.AddListener<RaceSelectorsPicker.RacesSelection>("RaceSelected", OnRaceSelected);
    }

    private void DestroyEventMessenger()
    {
        Messenger.RemoveListener<GameModesPicker.GameModes, GameOptions>("GameModeSelected", OnGameModeSelected);
        Messenger.RemoveListener<RaceSelectorsPicker.RacesSelection>("RaceSelected", OnRaceSelected);
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
            case LGTDUStates.RacesPicker:
                actualLGTDUState = state;
                rspRef = ((Transform)Instantiate(RaceSelectorsPickerPrefab)).gameObject.GetComponent<RaceSelectorsPicker>();
                rspRef.gameObject.transform.SetParent(canvasRef.transform, false);
                rtsCamRef.SetCamLock(true);
            break;
            case LGTDUStates.BuildingTime:
                actualLGTDUState = state;
                bpRef = ((Transform)Instantiate(BuildPickerPrefab)).gameObject.GetComponent<BuildPicker>();
                bpRef.gameObject.transform.SetParent(canvasRef.transform, false);
                if(cpRef== null)
                {
                    cpRef = ((Transform)Instantiate(CommonPickerPrefab)).gameObject.GetComponent<CommonPicker>();
                    cpRef.gameObject.transform.SetParent(canvasRef.transform, false);
                }
                rtsCamRef.SetCamLock(false);
                break;
        }
    }

    public void OnGameModeSelected(GameModesPicker.GameModes gm, GameOptions go)
    {
        Destroy(gmpRef.gameObject);
        ChangeToState(LGTDUStates.RacesPicker);
    }

    public void OnRaceSelected(RaceSelectorsPicker.RacesSelection rc)
    {
        Destroy(rspRef.gameObject);
        ChangeToState(LGTDUStates.BuildingTime);
    }

}
