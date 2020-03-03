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

    public int score = 0;
    public GameObject Scoreboard;

    public bool trackLeftHand = false;
    public bool trackRightHand = false;
    public enum difficulty { easy, medium, hard };
    public difficulty Difficulty = difficulty.easy;

    public enum pose { Tabletop, Knucklebend, Neutral };

    public bool inLeftTableTopZone;
    public bool inLeftKnucklebendZone;
    public bool inLeftNeutralZone;
    public bool inRightTableTopZone;
    public bool inRightKnucklebendZone;
    public bool inRightNeutralZone;

    public GameObject Y1txt;
    public GameObject Y2txt;
    public GameObject Crit1;
    public GameObject Crit2;

    public GameObject ParticleEffect;
    public GameObject LeftHandPrefab; //used to change hand material dynamically
    public GameObject RightHandPrefab; //used to change hand material dynamically

    public GameObject localSessionManager;


    // Start is called before the first frame update
    void Start()
    {
        //access script that is calculating the angles
        angleFinder = HandTracker.GetComponent<AngleFinder>();

    }

    // Update is called once per frame
    void Update()
    {
        // if hand touching target collider, check for pose
        if (inLeftTableTopZone && trackLeftHand)
        {
            Debug.Log("check for left tabletop pose!");
           bool poseBool = checkPose(Handedness.Left, pose.Tabletop);

           if (poseBool)
           {
                //trigger partical effect
                ParticleEffect.GetComponent<ParticleSystem>().Play();
                LeftHandPrefab.GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color", Color.green) ;

                if (score == 0)
                {
                    localSessionManager.GetComponent<localSessionManager>().StartSession();
                }
                //increase score
                score++;
                Scoreboard.GetComponent<Text>().text = score.ToString();
            }
        } else if (inLeftKnucklebendZone && trackLeftHand) {
            Debug.Log("check for left knucklebend pose!");
            bool poseBool = checkPose(Handedness.Left, pose.Knucklebend);

            if (poseBool)
            {
                //trigger partical effect
                ParticleEffect.GetComponent<ParticleSystem>().Play();
                LeftHandPrefab.GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color", Color.green);

                if (score == 0)
                {
                    localSessionManager.GetComponent<localSessionManager>().StartSession();
                }
                //increase score
                score++;
                Scoreboard.GetComponent<Text>().text = score.ToString();
            }
        } else if (inLeftNeutralZone && trackLeftHand) {
            Debug.Log("check for left neutral pose!");
            bool poseBool = checkPose(Handedness.Left, pose.Neutral);

            if (poseBool)
            {
                //trigger partical effect
                ParticleEffect.GetComponent<ParticleSystem>().Play();
                LeftHandPrefab.GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color", Color.green);

                //increase score
                score++;
                Scoreboard.GetComponent<Text>().text = score.ToString();
            }
        } else
        {
            LeftHandPrefab.GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color", Color.gray);

        }

        if (inRightTableTopZone && trackRightHand)
        {
            Debug.Log("check for right tabletop pose!");
            bool poseBool = checkPose(Handedness.Right, pose.Tabletop);

            if (poseBool)
            {
                //trigger partical effect
                ParticleEffect.GetComponent<ParticleSystem>().Play();
                RightHandPrefab.GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color", Color.green);

                if (score == 0)
                {
                    localSessionManager.GetComponent<localSessionManager>().StartSession();
                }
                //increase score
                score++;
                Scoreboard.GetComponent<Text>().text = score.ToString();
            }
        } else if (inRightKnucklebendZone && trackRightHand) {
            Debug.Log("check for right knucklebend pose!");
            bool poseBool = checkPose(Handedness.Right, pose.Knucklebend);

            if (poseBool)
            {
                //trigger partical effect
                ParticleEffect.GetComponent<ParticleSystem>().Play();
                RightHandPrefab.GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color", Color.green);

                if (score == 0)
                {
                    localSessionManager.GetComponent<localSessionManager>().StartSession();
                }
                //increase score
                score++;
                Scoreboard.GetComponent<Text>().text = score.ToString();
            }
        } else if (inRightNeutralZone && trackRightHand) {
            Debug.Log("check for right neutral pose!");
            bool poseBool = checkPose(Handedness.Right, pose.Neutral);

            if (poseBool)
            {
                //trigger partical effect
                ParticleEffect.GetComponent<ParticleSystem>().Play();
                RightHandPrefab.GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color", Color.green);

                //increase score
                score++;
                Scoreboard.GetComponent<Text>().text = score.ToString();
            }
        } else
        {
            RightHandPrefab.GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color", Color.gray);

        }

        //DEBUG
        int Y1 = debugAngle(Handedness.Right, TrackedHandJoint.Palm, TrackedHandJoint.MiddleKnuckle);
        Y1txt.GetComponent<Text>().text = Y1.ToString();
        int Y2 = debugAngle(Handedness.Right, TrackedHandJoint.MiddleKnuckle, TrackedHandJoint.MiddleDistalJoint);
        Y2txt.GetComponent<Text>().text = Y2.ToString();
    }

    private bool checkPose(Handedness hand, pose pose)
    {
        bool crit1 = false;
        bool crit2 = false;

        if (pose == pose.Tabletop)
        {
            crit1 = checkRequirement(hand, TrackedHandJoint.Palm, TrackedHandJoint.MiddleKnuckle, 180, 30);
            //Crit1.GetComponent<Text>().text = crit1.ToString();
            crit2 = checkRequirement(hand, TrackedHandJoint.MiddleKnuckle, TrackedHandJoint.MiddleDistalJoint, 10, 0);
            //Crit2.GetComponent<Text>().text = crit2.ToString();
        }

        if (pose == pose.Knucklebend)
        {
            crit1 = checkRequirement(hand, TrackedHandJoint.Palm, TrackedHandJoint.MiddleKnuckle, 20, 0); //change
            //Crit1.GetComponent<Text>().text = crit1.ToString();
            crit2 = checkRequirement(hand, TrackedHandJoint.MiddleKnuckle, TrackedHandJoint.MiddleDistalJoint, 200, 100); //change
            //Crit2.GetComponent<Text>().text = crit2.ToString();
        }

        if (pose == pose.Neutral)
        {
            crit1 = checkRequirement(hand, TrackedHandJoint.Palm, TrackedHandJoint.MiddleKnuckle, 20, 0);
            //Crit1.GetComponent<Text>().text = crit1.ToString();
            crit2 = checkRequirement(hand, TrackedHandJoint.MiddleKnuckle, TrackedHandJoint.MiddleDistalJoint, 10, 0);
            //Crit2.GetComponent<Text>().text = crit2.ToString();
        }

        if (crit1 == true && crit2 == true)
        {
            //poseBool.GetComponent<Text>().text = true.ToString();
            return true;
        }
        else
        {
            return false;
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
