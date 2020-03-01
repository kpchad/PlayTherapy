using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnterExit : MonoBehaviour
{
    public GameObject PoseRegonzier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.tag == "LTabletop")
        {
            PoseRegonzier.GetComponent<PoseRecognizer>().inLeftTableTopZone = true;
        }

        if (collision.gameObject.tag == "LKnucklebend")
        {
            PoseRegonzier.GetComponent<PoseRecognizer>().inLeftKnucklebendZone = true;
        }

        if (collision.gameObject.tag == "LNeutral")
        {
            PoseRegonzier.GetComponent<PoseRecognizer>().inLeftNeutralZone = true;
        }

        if (collision.gameObject.tag == "RTabletop")
        {
            PoseRegonzier.GetComponent<PoseRecognizer>().inRightTableTopZone = true;
        }

        if (collision.gameObject.tag == "RKnucklebend")
        {
            PoseRegonzier.GetComponent<PoseRecognizer>().inRightKnucklebendZone = true;
        }

        if (collision.gameObject.tag == "RNeutral")
        {
            PoseRegonzier.GetComponent<PoseRecognizer>().inRightNeutralZone = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
}
