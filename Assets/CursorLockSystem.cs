using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

sealed class CursorLockSystem : IEcsInitSystem
{
    public void Init()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
