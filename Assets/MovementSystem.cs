using Leopotam.Ecs;
using UnityEngine;

sealed class MovementSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<ModelComponent, MovableComponent, DirectionComponent> _movableFilter = null;

    public void Run()
    {
        foreach (var i in _movableFilter)
        {
            ref var modelComponent = ref _movableFilter.Get1(i);
            ref var movableComponent = ref _movableFilter.Get2(i);
            ref var directionComponent = ref _movableFilter.Get3(i);

            ref var direction = ref directionComponent.Direction;
            ref var transform = ref modelComponent.ModelTransform;

            ref var characterController = ref movableComponent.CharacterController;
            ref var moveSpeed = ref movableComponent.MoveSpeed;

            var rawDirection = (transform.right * direction.x) + (transform.forward * direction.z);

            //TODO: вынести в отдельную систему GravitySystem или PhysicSystem
            ref var velocity = ref movableComponent.Velocity;
            velocity.y += movableComponent.Gravity * Time.deltaTime;
            
            characterController.Move(rawDirection * moveSpeed * Time.deltaTime
                                     + velocity * Time.deltaTime);
        }
    }
}