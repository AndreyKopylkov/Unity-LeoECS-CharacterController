using System;
using Leopotam.Ecs;
using UnityEngine;

[Serializable]
public struct MovableComponent
{
    public CharacterController CharacterController;
    public float MoveSpeed;
    //TODO: вынести в отдельный компонет GravityComponent или PhysicComponent
    public float Gravity;
    
    [HideInInspector] public Vector3 Velocity;
}