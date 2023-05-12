
using System;
using UnityEngine;

[Serializable]
public struct GroundSphereComponent
{
    public Transform GroundCheckSphere;
    public float GroundDistance;
    public LayerMask GroundMask;
    [HideInInspector] public bool IsGrounded;
}