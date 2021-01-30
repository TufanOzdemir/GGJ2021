using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody _rigidbody;
    PlayerStats _playerStats;
    public bool _isAlarm;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerStats = GetComponent<PlayerStats>();
        _isAlarm = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAlarm)
        {
            //Kullanıcı takip etme kodları buraya konmalı
        }
    }
}
