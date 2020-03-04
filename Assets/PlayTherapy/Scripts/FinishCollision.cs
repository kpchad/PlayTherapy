using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCollision : MonoBehaviour
{
    public GameObject localSessionManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        localSessionManager.GetComponent<localSessionManager>().ConcludeSession();
    }
}
