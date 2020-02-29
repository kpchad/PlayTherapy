using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    private static bool SceneManagerExists;
    // Use this for initialization
    void Start()
    {
        if (!SceneManagerExists) 
        {
            SceneManagerExists = true;
            DontDestroyOnLoad(this.gameObject); 
        }
        else
        {
            Destroy(this);
        }
    }

}
