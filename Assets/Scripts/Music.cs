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
        // Ýlk þarkýyý çal
        audioSource.clip = playlist[currentTrackIndex];
        audioSource.Play();
    }

    void Update()
    {
        // "M" tuþuna basýldýðýnda bir sonraki þarkýya geç
        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayNextTrack();
        }
    }

    void PlayNextTrack()
    {
        // Bir sonraki þarkýya geç ve çal
        currentTrackIndex = (currentTrackIndex + 1) % playlist.Length;
        audioSource.clip = playlist[currentTrackIndex];
        audioSource.Play();
    }
}
