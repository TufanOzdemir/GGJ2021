using Assets.Scripts;
using Assets.Scripts.DTO;
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

    GameObject _player;




    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerStats = GetComponent<PlayerStats>();
        _uiService = Container.Instance.PopupService;
        _isAlarm = false;
        _player = GameObject.FindWithTag("Player");
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (_isAlarm)
        {
            _uiService.ShowPopup(new MainPopupDTO() { Description = "Deneme postudur.", Title = "Deniyoruz", Type = PopupType.OkCancel, OkButtonClickAction = SahneDegis });
        }
        PlayerNearby();
    }

    void SahneDegis()
    {
    }

    void PlayerNearby()
    {
        if (Vector3.Distance(_player.transform.position,transform.position)<5f)
        {
            _navMeshAgent.destination = _player.transform.position;
            //_rigidbody.MovePosition(_navMeshAgent.destination);
            
            
        }
    }



}
