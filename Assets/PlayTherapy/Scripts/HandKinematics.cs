
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandKinematics : MonoBehaviour
{
    [SerializeField]
    public Text Log;

    public void Awake()
    {
        Log.text = "test";
    }

    public void Update()
    {
        Log.text = "testing update";
    }




}
