using Assets.Scripts;
using Assets.Scripts.DTO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody _rigidbody;
    PlayerStats _playerStats;
    UIScript _uiService;
    public bool _isAlarm;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerStats = GetComponent<PlayerStats>();
        _uiService = Container.Instance.PopupService;
        _isAlarm = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (_isAlarm)
        {
            _uiService.ShowPopup(new MainPopupDTO() { Description = "Deneme postudur.", Title = "Deniyoruz", Type = PopupType.OkCancel, OkButtonClickAction = SahneDegis });
        }
    }

    void SahneDegis()
    {
    }
}
