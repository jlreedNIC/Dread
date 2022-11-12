using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }

        // instantiate notification manager if it's not already to avoid errors
        NotificationManager.Instance.instantiateNotifications();
    }
}
