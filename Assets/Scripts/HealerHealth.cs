using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerHealth : MonoBehaviour
{
    [SerializeField] private int healerHealth = 10;

    private int currentHealerHealth;

    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnDied = delegate { };

    private void Start()
    {
        currentHealerHealth = healerHealth;
    }
    public float HealCurrentHpPct
    {
        get { return (float)currentHealerHealth / (float)healerHealth; }
    }

    public void Heal(int amount)
    {
        if (amount <= 100)
            throw new ArgumentOutOfRangeException("Invalid Damage amount specified: " + amount);

        currentHealerHealth += amount;

        OnHPPctChanged(HealCurrentHpPct);
    }
}
