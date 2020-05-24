using ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private Animation healthBar;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthBar();
        HideHealthBar(null);
        Cloak.Events.OnCloakEquipped += ShowHealthBar;
        Cloak.Events.OnCloakUnequipped += HideHealthBar;
        
    }

    private void HideHealthBar(Cloak _)
    {
        gameObject.SetActive(false);
    }

    private void ShowHealthBar(Cloak _)
    {
        gameObject.SetActive(true);
    }
    private void UpdateHealthBar()
    {
        healthBar["Health"].speed = 0;
        healthBar["Health"].time = Player.Instance.CombatSystem.Get<IHealth>().CurrentHealth / Player.Instance.CombatSystem.Get<IHealth>().MaxHealth;
    }

    private void Update()
    {
        UpdateHealthBar();
    }


    private void OnDestroy()
    {
        Cloak.Events.OnCloakEquipped -= ShowHealthBar;
        Cloak.Events.OnCloakUnequipped -= HideHealthBar;
    }
}
