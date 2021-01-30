using Assets.Scripts;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int _currentHealth;
    public event Action OnDead;
    private PlayerStats playerStats;

    void Awake()
    {
        _currentHealth = GetComponent<PlayerStats>().Health * 5;
    }

    void Start()
    {
        _currentHealth = GetComponent<PlayerStats>().Health * 5;
    }

    void Update()
    {
    }

    private void Dead()
    {
        Container.Instance.PopupService.ShowPopup(
                new Assets.Scripts.DTO.MainPopupDTO()
                {
                    Description = "Düşman seni biçti!",
                    Title = "Öldün",
                    Type = Assets.Scripts.DTO.PopupType.Information,
                    OkButtonClickAction = delegate { SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene()); SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex); }
                });
    }

    public void HealFromStone(int value)
    {
        var maxHealth = Container.Instance.PlayerStats.Health * 5;
        var expectedHealth = _currentHealth + value;
        _currentHealth = expectedHealth < maxHealth ? expectedHealth : maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Weapon"))
        {
            var enemyStats = collision.gameObject.GetComponentInParent<PlayerStats>();
            _currentHealth -= enemyStats.Attack;
            Debug.Log(_currentHealth);
            if(_currentHealth < 0)
            {
                Dead();
                OnDead();
            }
        }
    }
}
