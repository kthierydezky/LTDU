using UnityEngine;
using System.Collections;

public class CommonPicker : MonoBehaviour {

    public enum GameModes
    {
        AllPick,
        SingleDraft,
        AllRandom,
        HostPick
    }

    public GameOptions go;

    public void OnClickGameMode(int gm)
    {
        Messenger.Broadcast("GameModeSelected", (GameModes)gm , go);
    }
}
