using Leopotam.Ecs;
using UnityEngine;

sealed class JumpBlockSystem : IEcsRunSystem
{
    private readonly EcsFilter<BlockJumpDuration> _blockFilter = null;
    
    public void Run()
    {
        foreach (var i in _blockFilter)
        {
            ref var entity = ref _blockFilter.GetEntity(i);
            ref var block = ref _blockFilter.Get1(i);
            block.DurationTimer -= Time.deltaTime;

            if (block.DurationTimer <= 0)
            {
                entity.Del<BlockJumpDuration>();
            }
        }
    }
}