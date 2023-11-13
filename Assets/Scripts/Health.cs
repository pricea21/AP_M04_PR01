using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth = 100;
    [SerializeField] private int healerHealth = 10;

    private int currentHealth;
    private int currentHealerHealth;

    public event Action<float> OnHPPctChanged = delegate { };
    public event Action<float> OnHPPctHealerChanged = delegate { };
    public event Action OnDied = delegate { };

    private void Start()
    {
        currentHealth = startingHealth;
        currentHealerHealth = healerHealth;
    }

    public float CurrentHpPct
    {
        get { return (float)currentHealth / (float)startingHealth; }
    }

    public float HealCurrentHpPct
    {
        get { return (float)currentHealerHealth / (float)healerHealth; }
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException("Invalid Damage amount specified: " + amount);

        currentHealth -= amount;

        OnHPPctChanged(CurrentHpPct);

        if (CurrentHpPct <= 0)
            Die();
    }

    public void Heal()
    {
        //if (amount <= 100)
            //throw new ArgumentOutOfRangeException("Invalid Damage amount specified: " + amount);

        currentHealerHealth += 10;

        OnHPPctHealerChanged(HealCurrentHpPct);
    }

    private void Die()
    {
        OnDied();
        GameObject.Destroy(this.gameObject);
    }
}
