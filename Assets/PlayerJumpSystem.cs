using Leopotam.Ecs;
using UnityEngine;

sealed partial class PlayerJumpSystem : IEcsRunSystem
{
    private readonly
        EcsFilter<PlayerTag, GroundSphereComponent, JumpComponent, JumpEvent>.
        Exclude<BlockJumpDuration> _jumpFilter = null;

    public void Run()
    {
        foreach (var i in _jumpFilter)
        {
            ref var entity = ref _jumpFilter.GetEntity(i);
            ref var groundCheck = ref _jumpFilter.Get2(i);
            ref var jumpComponent = ref _jumpFilter.Get3(i);
            ref var movable = ref entity.Get<MovableComponent>();
            ref var velocity = ref movable.Velocity;
            
            if(!groundCheck.IsGrounded) return; 

            velocity.y = Mathf.Sqrt(jumpComponent.Force * -2f * movable.Gravity);
            entity.Get<BlockJumpDuration>().DurationTimer = jumpComponent.ReloadTimer;
        }
    }
}