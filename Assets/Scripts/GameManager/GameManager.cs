using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleMono<GameManager>
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
