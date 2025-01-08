using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] playlist;
    private int currentTrackIndex = 0;

    void Start()
    {
        // �lk �ark�y� �al
        audioSource.clip = playlist[currentTrackIndex];
        audioSource.Play();
    }

    void Update()
    {
        // "M" tu�una bas�ld���nda bir sonraki �ark�ya ge�
        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayNextTrack();
        }
    }

    void PlayNextTrack()
    {
        // Bir sonraki �ark�ya ge� ve �al
        currentTrackIndex = (currentTrackIndex + 1) % playlist.Length;
        audioSource.clip = playlist[currentTrackIndex];
        audioSource.Play();
    }
}
