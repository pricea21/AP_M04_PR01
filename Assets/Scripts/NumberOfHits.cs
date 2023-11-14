using System;
using System.Collections;
using UnityEngine;

public class NumberOfHitsHealth : MonoBehaviour, IHealth
{
    [SerializeField]
    private int healthInHits = 5;

    [SerializeField]
    private float invulnerabilityTimeAfterEachHit = 5f;

    private int hitsRemaining;
    private bool canTakeDamage = true;
    private bool canHeal = true;

    public event Action<float> OnHPPctChanged = delegate (float f) { };
    public event Action<float> OnHPPctHealerChanged = delegate (float f) { };
    public event Action OnDied = delegate { };

    public float CurrentHpPct
    {
        get { return (float)hitsRemaining / (float)healthInHits; }
    }
    public float HealCurrentHpPct
    {
        get { return (float)hitsRemaining / (float)healthInHits; }
    }

    private void Start()
    {
        hitsRemaining = healthInHits;
    }

    public void TakeDamage(int amount)
    {
        if (canTakeDamage)
        {
            StartCoroutine(InvunlerabilityTimer());

            hitsRemaining--;

            OnHPPctChanged(CurrentHpPct);

            if (hitsRemaining <= 0)
                OnDied();
        }
    }

    public void Heal ()
    {
        if (canHeal)
        {
            //StartCoroutine(InvunlerabilityTimer());

            hitsRemaining++;

            OnHPPctHealerChanged(HealCurrentHpPct);

            if (hitsRemaining <= 0)
                Debug.Log("He is dead girlie");
        }
    }

    private IEnumerator InvunlerabilityTimer()
    {
        canTakeDamage = false;
        canHeal = false;
        yield return new WaitForSeconds(invulnerabilityTimeAfterEachHit);
        canTakeDamage = true;
        canHeal = true;
    }
}
