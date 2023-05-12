using Leopotam.Ecs;
using UnityEngine;

//TODO: переделать в независимую от тега игрока систему, для любых сущностей
sealed partial class PlayerGroundCheckSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag, GroundSphereComponent> _groundFilter = null;
    
    public void Run()
    {
        foreach (var i in _groundFilter)
        {
            ref var groundCheck = ref _groundFilter.Get2(i);

            groundCheck.IsGrounded = Physics.CheckSphere(groundCheck.GroundCheckSphere.position,
                groundCheck.GroundDistance, groundCheck.GroundMask);
        }
    }
}