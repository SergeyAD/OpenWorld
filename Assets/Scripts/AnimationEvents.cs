using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField]
    public AudioClip stepSound;
    private AudioSource m_AudioSource;

    public void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void WalkStep()
    {
        m_AudioSource.clip = stepSound;
        m_AudioSource.Play();
//        Debug.LogWarning("Step!");
    }

}
