using System;
using UnityEngine;

[Serializable]
public struct MouseLookDirectionComponent
{
    public Transform CameraTransform;
    public float MouseSensitivity;
    [HideInInspector] public Vector2 Direction;
}