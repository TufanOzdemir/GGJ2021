using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int Health = 20;
    public int Attack = 0;
    public int MoveSpeed = 0;
    public int AttackSpeed = 0;
    
    private int _currentStatPoint = 0;

    public int CurrentStatPoint { get { return _currentStatPoint; } set { _currentStatPoint = value; } }
    
    public void UpgradeHealth() => Health++;
    public void UpgradeAttack() => Attack++;
    public void UpgradeAttackSpeed() => AttackSpeed++;
    public void UpgradeMoveSpeed() => MoveSpeed++;
}