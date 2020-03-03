using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SessionManager : MonoBehaviour
{
    private GameObject sessionConfig;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitTherapy()
    {
        SceneManager.LoadScene(1);//load config scene
        Destroy(sessionConfig);
    }
}
