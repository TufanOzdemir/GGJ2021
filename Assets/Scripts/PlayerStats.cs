using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int Health = 0;
    public int Attack = 0;
    public int MoveSpeed = 0;
    public int AttackSpeed = 0;

    private int _currentHealth = -1000;
    private int _currentStatPoint = 0;

    public int CurrentStatPoint { get { return _currentStatPoint; } set { _currentStatPoint = value; } }
    public int CurrentHealth { 
        get 
        {
            if (_currentHealth == -1000) HealthRefill();
            return _currentHealth;
        } 
        set { _currentHealth = (value + _currentHealth) < (Health * 5) ? (value + _currentHealth) : (Health * 5); } }

    public void HealthRefill() => CurrentHealth = Health * 5;
    public void UpgradeHealth() => Health++;
    public void UpgradeAttack() => Attack++;
    public void UpgradeAttackSpeed() => AttackSpeed++;
    public void UpgradeMoveSpeed() => MoveSpeed++;
}