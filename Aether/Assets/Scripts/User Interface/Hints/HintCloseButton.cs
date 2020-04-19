using Aether.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintCloseButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameInputSystem.OnActionMapSwitched += ActionMapSwapped;
        gameObject.SetActive(false);
    }

    private void ActionMapSwapped(ActionMap newActionMap)
    {
        if(newActionMap.Equals(ActionMap.UserInterface))
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        GameInputSystem.OnActionMapSwitched -= ActionMapSwapped;
    }
}
