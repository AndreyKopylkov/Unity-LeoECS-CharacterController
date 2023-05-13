using Leopotam.Ecs;
using UnityEngine;

sealed class DeathSystem : IEcsRunSystem
{
    private readonly EcsFilter<CharacterComponent, PerformDeathEvent> _deathFilter;

    public void Run()
    {
        foreach (var i in _deathFilter)
        {
            ref var entity = ref _deathFilter.GetEntity(i);
            ref var characterComponent = ref _deathFilter.Get1(i);
            
            Object.Destroy(characterComponent.CharacterGO);
            entity.Destroy();
        }
    }
}