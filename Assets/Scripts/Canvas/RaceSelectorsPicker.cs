using UnityEngine;
using System.Collections;

public class RaceSelectorsPicker : MonoBehaviour {

    

    public enum RacesSelection
    {
        Paladin,
        Beast,
        Mech,
        nature,
        Shadow,
        Ghost,
        Element,
        DemiHuman,
        Marine,
        Prohpet,
        Hybrid,
        Artic,
        Goblin,
        Elf,
        Orc,
        Undead
    }

    private RacesSelection actualSelection;

    public GameObject Information;

    public void Start()
    {
        ShowHideRaceInfo(false);
    }

    public void OnClickRaceSelected(int rc)
    {
        //TODO
        actualSelection = (RacesSelection)rc;
        ShowHideRaceInfo(true);
    }

    public void OnClickRaceValidated()
    {
        Messenger.Broadcast("RaceSelected", actualSelection);
    }

    public void ShowHideRaceInfo(bool isShowed)
    {
        Information.SetActive(isShowed);
    }
}
