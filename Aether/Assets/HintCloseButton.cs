using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintCloseButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ActionMapManager.Events.OnActionMapSwapped += ActionMapSwapped;
        gameObject.SetActive(false);
    }

    private void ActionMapSwapped(string newActionMapName)
    {
        if(newActionMapName.Equals("User Interface"))
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
        ActionMapManager.Events.OnActionMapSwapped -= ActionMapSwapped;
    }
}
