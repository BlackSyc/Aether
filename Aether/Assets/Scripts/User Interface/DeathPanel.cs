using Aether.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPanel : MonoBehaviour
{
    private void Start()
    {
        Player.Instance.CombatSystem.Get<IHealth>().OnDied += Show;
        gameObject.SetActive(false);
        GetComponent<CanvasGroup>().alpha = 1;
    }

    private void Show()
    {
        gameObject.SetActive(true);
        InputSystem.SwitchToActionMap(ActionMap.PopUp);
    }

    public void Respawn()
    {
        Player.Instance.Respawn();
        gameObject.SetActive(false);
        InputSystem.SwitchToActionMap(ActionMap.Player);
    }

    private void OnDestroy()
    {
        Player.Instance.CombatSystem.Get<IHealth>().OnDied -= Show;
    }
}
