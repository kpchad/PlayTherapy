using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;
using UnityEngine.UI;

public class AngleFinder : MonoBehaviour
{
    string myLog;
    Queue myLogQueue = new Queue();

    [SerializeField]
    private GameObject Xrottxt, Yrottxt, Zrottxt;
    private float Xrot, Yrot, Zrot;
    public int XrotInt, YrotInt, ZrotInt;

    [SerializeField]
    private Handedness trackedHandedness = Handedness.Left;

    [SerializeField]
    private TrackedHandJoint parentSegment;
    [SerializeField]
    private TrackedHandJoint childSegment;

    void LateUpdate()
    {
        IMixedRealityHand hand = GetController(trackedHandedness) as IMixedRealityHand;
        if (hand == null || !hand.TryGetJoint(parentSegment, out MixedRealityPose pose))
        {
            return;
        }

        hand.TryGetJoint(childSegment, out MixedRealityPose childPose);

        Quaternion relativeQuaternion = Quaternion.Inverse(childPose.Rotation) * pose.Rotation;

        Xrot = relativeQuaternion.eulerAngles.x;
        Yrot = relativeQuaternion.eulerAngles.y;
        Zrot = relativeQuaternion.eulerAngles.z;

        XrotInt = Mathf.RoundToInt(Xrot);
        YrotInt = Mathf.RoundToInt(Yrot);
        ZrotInt = Mathf.RoundToInt(Zrot);
    }

    void OnGUI()
    {
        Xrottxt.GetComponent<Text>().text = XrotInt.ToString();
        Yrottxt.GetComponent<Text>().text = YrotInt.ToString(); 
        Zrottxt.GetComponent<Text>().text = ZrotInt.ToString();

    }

    private static IMixedRealityController GetController(Handedness handedness)
    {
        foreach (IMixedRealityController c in CoreServices.InputSystem.DetectedControllers)
        {
            if (c.ControllerHandedness.IsMatch(handedness))
            {
                return c;
            }
        }
        return null;
    }
}