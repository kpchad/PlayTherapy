using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstTrigger : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
        Destroy(ball);
    }
}
