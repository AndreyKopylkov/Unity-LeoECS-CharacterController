using Leopotam.Ecs;
using UnityEngine;

sealed class GameObjectActiveSystem : IEcsRunSystem
{
    private readonly GameObject _gameObject = null;
    private readonly EcsFilter<GameObjectActiveEvent> _goActiveFilter = null;

    public void Run()
    {
        foreach (var i in _goActiveFilter)
        {
            ref var entity = ref _goActiveFilter.GetEntity(i);
            
            if(_gameObject.activeSelf)
                _gameObject.SetActive(false);
            else
                _gameObject.SetActive(true);
            
            entity.Del<GameObjectActiveEvent>();
        }
    }
}