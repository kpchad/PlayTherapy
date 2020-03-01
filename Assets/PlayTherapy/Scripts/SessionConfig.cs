using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionConfig : MonoBehaviour
{
    public GameObject TabletopExercise;
    public GameObject KnuckleBendExercise;
    public GameObject LeftHandSetting;
    public GameObject RightHandSetting;
    public GameObject DifficultySelect;
    public GameObject ThemeSelect;

    public bool TableTopState;
    public bool KnuckleBendState;
    public bool LeftHandState;
    public bool RightHandState;
    public int DifficultyInt;
    public int ThemeInt;

    private GameObject localSceneManager;

    private void Start()
    {
        localSceneManager = GameObject.Find("localSceneManager");
    }

    public void LaunchSession()
    {

        TableTopState = TabletopExercise.GetComponent<Interactable>().IsToggled;
        KnuckleBendState = KnuckleBendExercise.GetComponent<Interactable>().IsToggled;
        LeftHandState = LeftHandSetting.GetComponent<Interactable>().IsToggled;
        RightHandState = RightHandSetting.GetComponent<Interactable>().IsToggled;
        DifficultyInt = DifficultySelect.GetComponent<InteractableToggleCollection>().CurrentIndex;
        ThemeInt = ThemeSelect.GetComponent<InteractableToggleCollection>().CurrentIndex;

        localSceneManager.GetComponent<localSceneManager>().startTherapy();
    }


}
