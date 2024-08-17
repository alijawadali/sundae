using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [Header("Set In Inspector")]
    public AudioClip runningClip;

    private PlayerMovement _playerMovment;
    private Player _player;

    private AudioSource _source;

    private void Start()
    {
        _playerMovment = GetComponent<PlayerMovement>();
        _player = GetComponent<Player>();

        _source = GetComponent<AudioSource>();

        _source.clip = runningClip;
    }

    private void Update()
    {
        if (_playerMovment.isRunning && !_source.isPlaying)
            _source.Play();

        if (!_playerMovment.isRunning && _source.isPlaying)
            _source.Stop();

    }
}
