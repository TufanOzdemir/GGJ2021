using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsenePlayer : MonoBehaviour
{
    bool _isTriggered = false;
    PlayableDirector _director;
    GameObject _player;

    private void Awake()
    {
        _director = GetComponent<PlayableDirector>();
        _director.stopped += DirectorStopped;
        _player = GameObject.FindWithTag("Player");
    }

    private void DirectorStopped(PlayableDirector obj)
    {
        _player.GetComponent<PlayerMove>().enabled = true;
        this.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!_isTriggered)
        {
            _isTriggered = true;
            _director.Play();
            _player.GetComponent<PlayerMove>().enabled = false;
            _player.GetComponent<Animator>().SetFloat("Blend", 0);
        }
    }
}
