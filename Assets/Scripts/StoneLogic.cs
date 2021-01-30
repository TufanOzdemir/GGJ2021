using Assets.Scripts;
using UnityEngine;

public class StoneLogic : MonoBehaviour
{
    /// <summary>
    /// Yenileyeceği can miktarı
    /// </summary>
    [SerializeField] int _refreshHealth;
    /// <summary>
    /// Vereceği skill puanı sayısı
    /// </summary>
    [SerializeField] int _statCount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            Container.Instance.PlayerHealth.HealFromStone(_refreshHealth);
            Container.Instance.PlayerStats.CurrentStatPoint++;
            Destroy(gameObject);
        }
    }
}