using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameState : MonoBehaviour
{
    public static NameState Instance { get; private set; }
    public string PlayerName { get; set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
