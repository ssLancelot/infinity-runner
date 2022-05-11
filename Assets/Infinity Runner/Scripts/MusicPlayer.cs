using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] GameData gameData;
    AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (_audio.isPlaying) return;
        if (gameData._isRunning)
            _audio.Play();
    }
}
