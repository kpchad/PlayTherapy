using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;
using UnityEngine.UI;

public class PoseRecognizer : MonoBehaviour
{

    public GameObject HandTracker;
    private AngleFinder angleFinder;
    public GameObject cookie;
    public int targetMin;
    public int targetMax;
    private bool pose, pos, target, lastTarget;
    private int countInt = 0;

    //debug outputs
    //public GameObject poseAssign;
    public GameObject poseBool;
    public GameObject posBool;
    public GameObject count;

    [SerializeField]
    private Handedness trackedHandedness = Handedness.Left;
    IMixedRealityHand hand;

    // Start is called before the first frame update
    void Start()
    {
        //access script that is calculating the angles
        angleFinder = HandTracker.GetComponent<AngleFinder>();

        //define mixed reality hand to get properties from
        hand = GetController(trackedHandedness) as IMixedRealityHand;

    }

    // Update is called once per frame
    void Update()
    {
        
        if((angleFinder.YrotInt > targetMin) && (angleFinder.YrotInt < targetMax))
        {
            pose = true;
            poseBool.GetComponent<Text>().text = true.ToString();
        }
        else
        {
            pose = false;
            poseBool.GetComponent<Text>().text = false.ToString();
        }

        if (true == true)//(Collision == true)
        {
            pos = true;
            posBool.GetComponent<Text>().text = true.ToString();
        }
        else
        {
            pos = false;
            posBool.GetComponent<Text>().text = false.ToString();
        }

        if ((pose == true) && (pos == true))
        {
            lastTarget = target;
            target = true;
        }
        else
        {
            lastTarget = target;
            target = false;
        }

        if ((lastTarget == false) && (target == true))
        {
            countInt++;
            count.GetComponent<Text>().text = countInt.ToString();
        }

    }

    private static IMixedRealityController GetController(Handedness handedness)
    {
        foreach (IMixedRealityController c in CoreServices.InputSystem.DetectedControllers)
        {
            if (c.ControllerHandedness.IsMatch(handedness))
            {
                return c;
            }
        }
        return null;
    }
}
