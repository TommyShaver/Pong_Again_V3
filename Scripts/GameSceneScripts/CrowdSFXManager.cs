using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSFXManager : MonoBehaviour
{
    public AudioClip[] _crowdSFX;
    public AudioSource _crowdSFXPlayer1;
    public AudioSource _crowdSFXPlayer2;
    // Start is called before the first frame update
    void Start()
    {
        _crowdSFXPlayer1 = GetComponent<AudioSource>();
        _crowdSFXPlayer2 = GetComponent<AudioSource>();
        AtmoSFXPlayer();
    }
    private void AtmoSFXPlayer()
    {
        _crowdSFXPlayer1.clip = _crowdSFX[0];
        _crowdSFXPlayer1.Play();
    }

}
