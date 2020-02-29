using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class localSceneManager : MonoBehaviour
{

    private GameObject sessionConfig;

    // Start is called before the first frame update
    void Start()
    {
        sessionConfig = GameObject.Find("SessionConfig");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startSession()
    {
        SceneManager.LoadScene(1);//load session scene
    }

    public void startTherapy()
    {
        SceneManager.LoadScene(2);//load session scene
    }

    public void exitTherapy()
    {
        SceneManager.LoadScene(1);//load config scene
        Destroy(sessionConfig);
        Destroy(this);
    }
}
