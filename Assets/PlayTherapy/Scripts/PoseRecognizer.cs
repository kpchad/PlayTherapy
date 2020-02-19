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

    [SerializeField]
    private TrackedHandJoint parentSegment;
    [SerializeField]
    private TrackedHandJoint childSegment;

    // Start is called before the first frame update
    void Start()
    {
        //access script that is calculating the angles
        angleFinder = HandTracker.GetComponent<AngleFinder>();

    }

    // Update is called once per frame
    void Update()
    {
        // fetch desired angles
        Vector3 angle = angleFinder.GetAngle(trackedHandedness, parentSegment, childSegment);

        // check if angle meets target
        if((angle.y > targetMin) && (angle.y < targetMax))
        {
            pose = true;
            poseBool.GetComponent<Text>().text = true.ToString();

            //update last pose
            lastTarget = target;
            target = true;
        }
        else
        {
            pose = false;
            poseBool.GetComponent<Text>().text = false.ToString();

            //update last pose
            lastTarget = target;
            target = false;
        }

        if ((lastTarget == false) && (target == true))
        {
            countInt++;
            count.GetComponent<Text>().text = countInt.ToString();
        }

    }

}
