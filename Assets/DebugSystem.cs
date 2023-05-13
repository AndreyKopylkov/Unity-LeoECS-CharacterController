using Leopotam.Ecs;
using UnityEngine;

sealed class DebugSystem : IEcsRunSystem
{
    private readonly EcsFilter<DebugMessageRequest> _debugMessageFilter = null;

    public void Run()
    {
        foreach (var i in _debugMessageFilter)
        {
            ref var entity = ref _debugMessageFilter.GetEntity(i);
            ref var request = ref _debugMessageFilter.Get1(i);
            ref var message = ref request.Message;
            
            Debug.Log(message);
            entity.Del<DebugMessageRequest>();
        }
    }
}