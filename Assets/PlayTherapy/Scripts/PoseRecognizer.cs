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

    private bool target, lastTarget;
    private int countInt = 0;

    //debug outputs
    //public GameObject poseAssign;
    public GameObject poseBool;
    public GameObject count;

    [SerializeField]
    private Handedness trackedHandedness1 = Handedness.Left;
    [SerializeField]
    private TrackedHandJoint parentSegment1;
    [SerializeField]
    private TrackedHandJoint childSegment1;
    [SerializeField]
    private int targetMin1;
    [SerializeField]
    private int targetMax1;

    [SerializeField]
    private Handedness trackedHandedness2 = Handedness.Left;
    [SerializeField]
    private TrackedHandJoint parentSegment2;
    [SerializeField]
    private TrackedHandJoint childSegment2;
    [SerializeField]
    private int targetMin2;
    [SerializeField]
    private int targetMax2;

    public GameObject Y1txt;
    public GameObject Y2txt;
    public GameObject Crit1;
    public GameObject Crit2;


    // Start is called before the first frame update
    void Start()
    {
        //access script that is calculating the angles
        angleFinder = HandTracker.GetComponent<AngleFinder>();

    }

    // Update is called once per frame
    void Update()
    {
        
        bool crit1 = checkRequirement(trackedHandedness1, parentSegment1, childSegment1, targetMax1, targetMin1);
        Crit1.GetComponent<Text>().text = crit1.ToString();
        bool crit2 = checkRequirement(trackedHandedness2, parentSegment2, childSegment2, targetMax2, targetMin2);
        Crit2.GetComponent<Text>().text = crit2.ToString();

        //DEBUG
        int Y1 = debugAngle(trackedHandedness1, parentSegment1, childSegment1);
        Y1txt.GetComponent<Text>().text = Y1.ToString();
        int Y2 = debugAngle(trackedHandedness2, parentSegment2, childSegment2);
        Y2txt.GetComponent<Text>().text = Y2.ToString();

        if (crit1==true && crit2==true)
        {
            poseBool.GetComponent<Text>().text = true.ToString();

            if (lastTarget == false)
            {
                Debug.Log(countInt);
                countInt++;
                count.GetComponent<Text>().text = countInt.ToString();
            }
            lastTarget = true;
         
        }
        else
        {
            poseBool.GetComponent<Text>().text = false.ToString();
            lastTarget = false;
            return;
        }
    }

    private int debugAngle(Handedness trackedHandedness, TrackedHandJoint parentSegment, TrackedHandJoint childSegment)
    {       
        // fetch desired angles
        Vector3 angle = angleFinder.GetAngle(trackedHandedness, parentSegment, childSegment);
        int Y = Mathf.RoundToInt(angle.y);
        return Y;
    }

    private bool checkRequirement(Handedness trackedHandedness, TrackedHandJoint parentSegment, TrackedHandJoint childSegment, int targetMax, int targetMin)
    {
        // fetch desired angles
        Vector3 angle = angleFinder.GetAngle(trackedHandedness, parentSegment, childSegment);

        // check if angle meets target
        if ((angle.y > targetMin) && (angle.y < targetMax))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
