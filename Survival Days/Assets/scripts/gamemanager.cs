using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    #region Singleton

    public static gamemanager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

}
