using Assets.Scripts;
using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _currentHealth;

    void Awake()
    {
        _currentHealth = Container.Instance.PlayerStats.Health * 5;
    }

    void Update()
    {
        if (_currentHealth <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        Debug.LogError("Öldün Çık");
    }

    public void HealFromStone(int value)
    {
        var maxHealth = Container.Instance.PlayerStats.Health * 5;
        var expectedHealth = _currentHealth + value;
        _currentHealth = expectedHealth < maxHealth ? expectedHealth : maxHealth;
    }
}
