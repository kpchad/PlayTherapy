using Microsoft.MixedReality.Toolkit.Utilities;
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
    public GameObject RUSHPlayer;
    public GameObject TSwiftPlayer;


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
            } else if (SessionConfig.GetComponent<SessionConfig>().TableTopState && !SessionConfig.GetComponent<SessionConfig>().KnuckleBendState)
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
            } else if (SessionConfig.GetComponent<SessionConfig>().KnuckleBendState && !SessionConfig.GetComponent<SessionConfig>().TableTopState)
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
                Debug.Log("tracking left hand");
            }
            if (SessionConfig.GetComponent<SessionConfig>().RightHandState)
            {
                //track right hand poses
                PoseRecognizer.GetComponent<PoseRecognizer>().trackRightHand = true;
                Debug.Log("tracking right hand");
            }

            if (SessionConfig.GetComponent<SessionConfig>().DifficultyInt == 0)
            {
                Debug.Log("easy difficulty");
                PoseRecognizer.GetComponent<PoseRecognizer>().Difficulty = global::PoseRecognizer.difficulty.easy;
            } else if (SessionConfig.GetComponent<SessionConfig>().DifficultyInt == 1)
            {
                Debug.Log("medium difficulty");
                PoseRecognizer.GetComponent<PoseRecognizer>().Difficulty = global::PoseRecognizer.difficulty.medium;
            } else if (SessionConfig.GetComponent<SessionConfig>().DifficultyInt == 2)
            {
                Debug.Log("hard difficulty");
                PoseRecognizer.GetComponent<PoseRecognizer>().Difficulty = global::PoseRecognizer.difficulty.hard;
            } else
            {
                Debug.Log("unrecognized difficulty setting");
                Debug.Log(SessionConfig.GetComponent<SessionConfig>().DifficultyInt);
            }

            if (SessionConfig.GetComponent<SessionConfig>().ThemeInt == 0)
            {
                Debug.Log("RUSH Theme");
                Sphere.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.magenta);
                RUSHPlayer.SetActive(true);
            } else if (SessionConfig.GetComponent<SessionConfig>().ThemeInt == 1)
            {
                Debug.Log("Tswift Theme");
                Sphere.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.cyan);
                TSwiftPlayer.SetActive(true);
            } else
            {
                Debug.Log("unrecognized theme setting");
                Debug.Log(SessionConfig.GetComponent<SessionConfig>().ThemeInt);
            }
        }
    }
}
