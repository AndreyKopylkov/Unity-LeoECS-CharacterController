using Leopotam.Ecs;
using UnityEngine;

sealed class PlayerInputSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag, DirectionComponent> _directionFilter = null;

    private float _horizontalInput;
    private float _verticalInput;
    
    public void Run()
    {
        SetDirection();
        
        foreach (var i in _directionFilter)
        {
            ref var directionComponent = ref _directionFilter.Get2(i);
            ref var direction = ref directionComponent.Direction;


            direction.x = _horizontalInput;
            direction.z = _verticalInput;
        }
    }

    private void SetDirection()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }
}