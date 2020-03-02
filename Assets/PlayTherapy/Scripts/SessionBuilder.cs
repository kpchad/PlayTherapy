﻿using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionBuilder : MonoBehaviour
{
    private GameObject SessionConfig;
    public GameObject Conveyor;
    public Transform TableTop10;
    public Transform KnuckleBend10;
    public GameObject PoseRecognizer;
    public GameObject Sphere;
    public GameObject MusicPlayer;
    public AudioClip RUSHClip;
    public AudioClip TSwiftClip;


    // read settings from SessionConfig object (carried over from previous scene) and assemble the therapy scene accordingly
    void Start()
    {
        SessionConfig = GameObject.Find("SessionConfig");
        if (SessionConfig == null)
        {
            Debug.Log("no session config asset found!");
        }
        else
        {

            // build session
            if (SessionConfig.GetComponent<SessionConfig>().TableTopState && SessionConfig.GetComponent<SessionConfig>().KnuckleBendState)
            {
                //add tabletop prefab nested under SceneContent with transform position (0,0,0)
                var TableTop1 = Instantiate(TableTop10, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                TableTop1.transform.parent = Conveyor.transform;

                //add knucklebend prefab nested under SceneContent with transform position (0,0,20)
                var KnuckleBend1 = Instantiate(KnuckleBend10, new Vector3(transform.position.x, transform.position.y, transform.position.z + 20), Quaternion.identity);
                KnuckleBend1.transform.parent = Conveyor.transform;

                //add tabletop prefab nested under SceneContent with transform position (0,0,0)
                var TableTop2 = Instantiate(TableTop10, new Vector3(transform.position.x, transform.position.y, transform.position.z + 40), Quaternion.identity);
                TableTop2.transform.parent = Conveyor.transform;

                //add knucklebend prefab nested under SceneContent with transform position (0,0,20)
                var KnuckleBend2 = Instantiate(KnuckleBend10, new Vector3(transform.position.x, transform.position.y, transform.position.z + 60), Quaternion.identity);
                KnuckleBend2.transform.parent = Conveyor.transform;
            };
            if (SessionConfig.GetComponent<SessionConfig>().TableTopState && !SessionConfig.GetComponent<SessionConfig>().KnuckleBendState)
            {
                //add tabletop prefab nested under SceneContent with transform position (0,0,0)
                var TableTop1 = Instantiate(TableTop10, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                TableTop1.transform.parent = Conveyor.transform;

                //add tabletop prefab nested under SceneContent with transform position (0,0,20)
                var TableTop2 = Instantiate(TableTop10, new Vector3(transform.position.x, transform.position.y, transform.position.z + 20), Quaternion.identity);
                TableTop2.transform.parent = Conveyor.transform;

                //add tabletop prefab nested under SceneContent with transform position (0,0,40)
                var TableTop3 = Instantiate(TableTop10, new Vector3(transform.position.x, transform.position.y, transform.position.z + 40), Quaternion.identity);
                TableTop3.transform.parent = Conveyor.transform;

                //add tabletop prefab nested under SceneContent with transform position (0,0,60)
                var TableTop4 = Instantiate(TableTop10, new Vector3(transform.position.x, transform.position.y, transform.position.z + 60), Quaternion.identity);
                TableTop4.transform.parent = Conveyor.transform;
            };
            if (SessionConfig.GetComponent<SessionConfig>().KnuckleBendState && !SessionConfig.GetComponent<SessionConfig>().TableTopState)
            {
                //add knucklebend prefab nested under SceneContent with transform position (0,0,0)
                var KnuckleBend1 = Instantiate(KnuckleBend10, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                KnuckleBend1.transform.parent = Conveyor.transform;

                //add knucklebend prefab nested under SceneContent with transform position (0,0,20)
                var KnuckleBend2 = Instantiate(KnuckleBend10, new Vector3(transform.position.x, transform.position.y, transform.position.z + 20), Quaternion.identity);
                KnuckleBend2.transform.parent = Conveyor.transform;

                //add knucklebend prefab nested under SceneContent with transform position (0,0,40)
                var KnuckleBend3 = Instantiate(KnuckleBend10, new Vector3(transform.position.x, transform.position.y, transform.position.z + 40), Quaternion.identity);
                KnuckleBend3.transform.parent = Conveyor.transform;

                //add knucklebend prefab nested under SceneContent with transform position (0,0,60)
                var KnuckleBend4 = Instantiate(KnuckleBend10, new Vector3(transform.position.x, transform.position.y, transform.position.z + 60), Quaternion.identity);
                KnuckleBend4.transform.parent = Conveyor.transform;
            };

            if (SessionConfig.GetComponent<SessionConfig>().LeftHandState)
            {
                //track left hand poses
                PoseRecognizer.GetComponent<PoseRecognizer>().trackLeftHand = true;
            }
            if (SessionConfig.GetComponent<SessionConfig>().RightHandState)
            {
                //track right hand poses
                PoseRecognizer.GetComponent<PoseRecognizer>().trackRightHand = true;
            }

            if (SessionConfig.GetComponent<SessionConfig>().DifficultyInt == 0)
            {
                PoseRecognizer.GetComponent<PoseRecognizer>().Difficulty = global::PoseRecognizer.difficulty.easy;
            }
            if (SessionConfig.GetComponent<SessionConfig>().DifficultyInt == 1)
            {
                PoseRecognizer.GetComponent<PoseRecognizer>().Difficulty = global::PoseRecognizer.difficulty.medium;
            }
            if (SessionConfig.GetComponent<SessionConfig>().DifficultyInt == 2)
            {
                PoseRecognizer.GetComponent<PoseRecognizer>().Difficulty = global::PoseRecognizer.difficulty.hard;
            }
            else
            {
                Debug.Log("unrecognized difficulty setting");
            }

            if (SessionConfig.GetComponent<SessionConfig>().ThemeInt == 0)
            {
                Sphere.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                MusicPlayer.GetComponent<AudioSource>().clip = RUSHClip;
            }
            if (SessionConfig.GetComponent<SessionConfig>().ThemeInt == 1)
            {
                Sphere.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
                MusicPlayer.GetComponent<AudioSource>().clip = TSwiftClip;
            }
        }
    }
}
