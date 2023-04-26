using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class MutantScript : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip footSteps;

    void Start()
    {
        FootStepsAudio();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FootStepsAudio(/*AudioClip fotsteps*/)
    {
        audioSource.clip = footSteps;
        audioSource.Play();
        //Debug.Log("hellooo?????");
    }
}
