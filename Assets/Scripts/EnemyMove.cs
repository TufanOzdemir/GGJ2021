using Assets.Scripts;
using Assets.Scripts.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    Rigidbody _rigidbody;
    PlayerStats _playerStats;
    UIScript _uiService;
    public bool _isAlarm;
    NavMeshAgent _navMeshAgent;
    Animator _animator;
    GameObject _player;

    private float time = 0;
    private float timeLimit = 3;

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerStats = GetComponent<PlayerStats>();
        _uiService = Container.Instance.PopupService;
        _isAlarm = false;
        _player = GameObject.FindWithTag("Player");
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _player.GetComponent<PlayerHealth>().OnDead += PlayerOnDead;
    }

    public void PlayerOnDead()
    {
        _isAlarm = false;
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerNearby();
        AnimationPlay();
    }

    void PlayerNearby()
    {
        var vektor = Vector3.Distance(_player.transform.position, transform.position);
        if (vektor < 5f)
        {
            if (vektor > 1f)
            {
                _navMeshAgent.destination = _player.transform.position;
                _isAlarm = true;
                time = 0;
            }
            else
            {
                Attack();
            }
        }
        else
        {
            time += Time.deltaTime;
            if (time > timeLimit)
            {
                _isAlarm = false;
                time = 0;
            }
        }
    }

    private void Attack()
    {
        transform.LookAt(_player.transform);
        var attackState = _animator.GetCurrentAnimatorStateInfo(0).IsName("Attack");
        if (!attackState) _animator.SetTrigger("Attack");
    }

    void AnimationPlay()
    {
        _animator.SetFloat("Blend", _navMeshAgent.speed);
    }
}
