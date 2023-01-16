using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public int MaxHealth = 100;
    [SerializeField]
    private int health;


    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            onHealthChange?.Invoke((float)health / MaxHealth);
        }
    }

    public UnityEvent onDead;
    public UnityEvent<float> onHealthChange;
    public UnityEvent onHit, onHeal;

    private void Start()
    {
        Health = MaxHealth;
    }

    internal void Hit(int damagePoints)
    {
        Health -= damagePoints;
        if (Health <= 0)
        {
            onDead?.Invoke();
        }
        else
        {
            onHit?.Invoke();
        }
    }

    public void Heal(int HealthBoost)
    {
        Health += HealthBoost;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        onHeal?.Invoke();
    }

}
