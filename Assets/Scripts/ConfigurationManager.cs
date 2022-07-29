using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationManager : MonoBehaviour
{
    // ENCAPSULATION
    private const int MAX_NAME_LENGTH = 3;
    
    // ENCAPSULATION
    public static ConfigurationManager Instance { get; private set; }

    // ENCAPSULATION
    private string _name;
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (IsValidName(value))
            {
                _name = value;
            }
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // ABSTRACTION
    public bool IsValidName(string name)
    {
        return !string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name) && name.Length <= MAX_NAME_LENGTH;
    }
}
