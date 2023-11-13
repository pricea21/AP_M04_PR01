using System;
using TMPro;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class StandardHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int startingHealth = 100;
    [SerializeField] private int healerHealth = 10;

    public int currentHealth;
    public int currentHealerHealth;
    public Text healthUpdate;

    public event Action<float> OnHPPctChanged = delegate { };
    public event Action<float> OnHPPctHealerChanged = delegate { };
    public event Action OnDied = delegate { };

    private void Start()
    {
        currentHealth = startingHealth;
        currentHealerHealth = healerHealth;
        //healthUpdate.text = "Current Health: " + currentHealerHealth;
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
        //if (currentHealerHealth <= 100)
        //throw new ArgumentOutOfRangeException("Invalid Damage amount specified: " + currentHealerHealth);

        currentHealerHealth += 10;

        OnHPPctHealerChanged(HealCurrentHpPct);
    }

    void Update()
    {
        healthUpdate.text = "Current Health: " + currentHealerHealth;
    }

    private void Die()
    {
        OnDied();
        GameObject.Destroy(this.gameObject);
    }
}
