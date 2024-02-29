using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxeWooshSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip[] _wooshSound;

    void PlayWooshSound()
    {
        _audioSource.clip=_wooshSound[Random.Range(0,_wooshSound.Length)];
        _audioSource.Play();
    }
}
