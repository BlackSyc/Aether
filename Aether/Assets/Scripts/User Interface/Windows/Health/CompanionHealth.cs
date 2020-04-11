using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionHealth : MonoBehaviour
{
    [SerializeField]
    private Animation healthBar;

    private Health companionHealth;

    void Start()
    {
        Hide();
    }

    private void Show(Companion companion)
    {
        gameObject.SetActive(true);
        companionHealth = companion.GetComponent<Health>();

        Companion.Events.OnCompanionAdded -= Show;
        Companion.Events.OnCompanionRemoved += Hide;
    }

    private void Hide()
    {
        Companion.Events.OnCompanionRemoved -= Hide;
        Companion.Events.OnCompanionAdded += Show;
        companionHealth = null;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (companionHealth)
            UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar["Health"].speed = 0;
        healthBar["Health"].time = companionHealth.CurrentHealth / companionHealth.MaxHealth;
    }
}
