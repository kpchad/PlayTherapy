using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class localSessionManager : MonoBehaviour
{
    private GameObject SessionConfig;

    public GameObject initiationText;
    public GameObject initiationTabletop;
    public GameObject initiationKnucklebend;
    public GameObject Conveyor;
    public GameObject MusicPlayer;
    public GameObject FinaleParticleEffect;
    public GameObject ScoreText;
    public GameObject ExitButton;

    // Start is called before the first frame update
    void Start()
    {
        SessionConfig = GameObject.Find("SessionConfig");

        // place an appropriate pose to initiate
        if (SessionConfig.GetComponent<SessionConfig>().TableTopState)
        {
            initiationTabletop.SetActive(true);
        }
        else
        {
            initiationKnucklebend.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSession()
    {
        initiationTabletop.SetActive(false);
        initiationKnucklebend.SetActive(false);
        initiationText.SetActive(false);

        //start animator
        Conveyor.GetComponent<Animator>().enabled = true;

        //start music
        MusicPlayer.GetComponent<AudioSource>().Play();
    }

    public void ConcludeSession()
    {
        // play particle effects
        FinaleParticleEffect.GetComponent<ParticleSystem>().Play();

        //enlarge score
        ScoreText.GetComponent<Text>().transform.position = new Vector3(0, 2, 5);
    }


    public void exitTherapy()
    {
        SceneManager.LoadScene(1);//load config scene
    }
}
