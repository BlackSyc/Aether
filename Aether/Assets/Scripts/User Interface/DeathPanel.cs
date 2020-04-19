using Aether.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPanel : MonoBehaviour
{
    private void Start()
    {
        Player.Instance.Health.OnDied += Show;
        gameObject.SetActive(false);
        GetComponent<CanvasGroup>().alpha = 1;
    }

    private void Show()
    {
        gameObject.SetActive(true);
        GameInputSystem.SwitchToActionMap(ActionMap.PopUp);
    }

    public void Respawn()
    {
        Player.Instance.Respawn();
        gameObject.SetActive(false);
        GameInputSystem.SwitchToActionMap(ActionMap.Player);
        AetherEvents.UIEvents.ToolTips.UnhideAll();
        AetherEvents.UIEvents.Crosshair.UnhideCrosshair();
    }

    private void OnDestroy()
    {
        Player.Instance.Health.OnDied -= Show;
    }
}
