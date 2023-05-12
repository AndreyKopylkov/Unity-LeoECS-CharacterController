using System;
using Leopotam.Ecs;
using UnityEngine;

[Serializable]
public struct MovableComponent
{
    public CharacterController CharacterController;
    public float MoveSpeed;
}