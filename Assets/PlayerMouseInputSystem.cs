using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

sealed class PlayerMouseInputSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag, MouseLookDirectionComponent> _mouseInputFilter = null;

    private float _horizontalInput;
    private float _verticalInput;
    
    public void Run()
    {
        GetAxis();
        ClampAxis();

        foreach (var i in _mouseInputFilter)
        {
            ref var lookComponent = ref _mouseInputFilter.Get2(i);

            lookComponent.Direction.x = _horizontalInput;
            lookComponent.Direction.y = _verticalInput;
        }
    }

    private void GetAxis()
    {
        _horizontalInput += Input.GetAxis("Mouse X");
        _verticalInput -= Input.GetAxis("Mouse Y");
    }

    private void ClampAxis()
    {
        _verticalInput = Mathf.Clamp(_verticalInput, -85, 75);
    }
}
