using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance;
    public UserProfile UserProfile;

    void Start()
    {
        Instance = this;
        UserProfile = GetComponent<UserProfile>();
    }
}
