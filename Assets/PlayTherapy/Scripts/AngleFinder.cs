using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;
using UnityEngine.UI;

public class AngleFinder : MonoBehaviour
{

    private float Xrot, Yrot, Zrot;
    private int XrotInt, YrotInt, ZrotInt;

   public Vector3 GetAngle(Handedness trackedHandedness, TrackedHandJoint parentSegment, TrackedHandJoint childSegment)
    {
        IMixedRealityHand hand = GetController(trackedHandedness) as IMixedRealityHand;
        if (hand == null || !hand.TryGetJoint(parentSegment, out MixedRealityPose pose) || !hand.TryGetJoint(childSegment, out MixedRealityPose childPose))
        {
            Debug.Log("one or both of the segments are not valid/visible");
            return Vector3.zero; //return vector of zeros
        }
        
        Quaternion relativeQuaternion = Quaternion.Inverse(childPose.Rotation) * pose.Rotation;

        Xrot = relativeQuaternion.eulerAngles.x;
        Yrot = relativeQuaternion.eulerAngles.y;
        Zrot = relativeQuaternion.eulerAngles.z;

        XrotInt = Mathf.RoundToInt(Xrot);
        YrotInt = Mathf.RoundToInt(Yrot);
        ZrotInt = Mathf.RoundToInt(Zrot);

        Vector3 angle = new Vector3 (XrotInt, YrotInt, ZrotInt);

        return angle; 
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