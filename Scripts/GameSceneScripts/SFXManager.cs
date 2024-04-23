using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager _iSFXManager { get; private set; }
    [Header("Audio Clips")]
    public AudioClip _paddelSFX;
    public AudioClip _wallSFX;
    public AudioClip _pauseSFX;
    public AudioClip _unpauseSFX;
    public AudioClip _gotPowerUp;
    public AudioClip _usedPowerUp;
    public AudioClip _backToMainMenu;
    public AudioClip _hoverOverUI;
    public AudioClip _goalHorn;
    public AudioClip _startOfShow;

    private float RandomNumber = 0;

    [Header("Audio Scoures")]
    public AudioSource _SFXSoruce1; // This audio player job sfx for ball hits.
    public AudioSource _SFXSource2; // This audio player job sfx for wall hits and goal horn.
    public AudioSource _SFXSource3; // This audio player job is power up and pause menu.
    private void Awake()
    {
        if (_iSFXManager != null && _iSFXManager != this)
        {
            Destroy(this);
        }
        else
        {
            _iSFXManager = this;
        }
    }

    private void Start()
    {
        _SFXSource3.pitch = 1;
        _SFXSoruce1.clip = _startOfShow;
        _SFXSoruce1.Play();
    }

    public void PaddleWasHit()
    {
        _SFXSoruce1.clip = _paddelSFX;
        _SFXSoruce1.Play();
    }

    public void WallWasHit()
    {
        _SFXSource2.clip = _wallSFX;
        _SFXSource2.Play();
    }


    //Audio Player 3 ----------------------------------------------------------
    public void PauseSFX(bool isPaused)
    {
        _SFXSource3.volume = 1f;
        _SFXSource3.panStereo = 0;
        _SFXSource3.pitch = 1;
        if (!isPaused)
        {
            _SFXSource3.clip = _pauseSFX;
            _SFXSource3.Play();

        }
        else
        {
            _SFXSource3.clip = _unpauseSFX;
            _SFXSource3.Play();
        }
    }
    public void PauseBackToMainMenu()
    {
        _SFXSource3.volume = 1f;
        _SFXSource3.panStereo = 0;
        _SFXSource3.pitch = -1f;
        _SFXSource3.clip = _backToMainMenu;
        _SFXSource3.Play();
    }
    public void HoverOverUI()
    {
        _SFXSource3.volume = 1f;
        _SFXSource3.panStereo = 0;
        _SFXSource3.pitch = 1;
        _SFXSource3.clip = _hoverOverUI;
        _SFXSource3.Play();
    }
    public void PowerUpSFX(int state)
    {
        _SFXSource3.pitch = 1;
        switch (state)
        {
            case 1:
                _SFXSource3.clip = _gotPowerUp;
                _SFXSource3.volume = .5f;
                _SFXSource3.panStereo = -1;
                _SFXSource3.Play();
                break;
            case 2:
                _SFXSource3.clip = _gotPowerUp;
                _SFXSource3.volume = .5f;
                _SFXSource3.panStereo = 1;
                _SFXSource3.Play();
                break;
            case 3:
                _SFXSource3.clip = _usedPowerUp;
                _SFXSource3.volume = .5f;
                _SFXSource3.panStereo = -0.5f;
                _SFXSource3.Play();
                break;
            case 4:
                _SFXSource3.clip = _usedPowerUp;
                _SFXSource3.volume = .5f;
                _SFXSource3.panStereo = 0.5f;
                _SFXSource3.Play();
                break;
            default:
                Debug.Log("This int was called null for somereason");
                break;
        }
    }
    public void GoalHorn()
    {
        _SFXSource2.clip = _goalHorn;
        _SFXSource2.Play();
    }
    public void WhistleStart()
    {
        RandomNumber = Random.Range(.9f, 1.2f);
        _SFXSource3.volume = 1;
        _SFXSource3.pitch = RandomNumber;
        _SFXSource3.clip = _pauseSFX;
        _SFXSource3.Play();
    }
}
