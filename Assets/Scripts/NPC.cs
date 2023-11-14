using System;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public AudioClip hitSound;
    internal void TakeDamage(int amount)
    {
        GetComponent<IHealth>().TakeDamage(amount);
    }

   internal void Heal()
    {
        GetComponent<IHealth>().Heal();
    }

    public void Update()
    {
        if (gameObject.tag  == "RegularNPC")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage(10);
                AudioSource ac = GetComponent<AudioSource>();
                ac.PlayOneShot(hitSound);
            }
        }

        if (gameObject.tag == "HealNPC")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Heal();
            }
        }
    }
}
