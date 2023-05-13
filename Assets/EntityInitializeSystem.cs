using Leopotam.Ecs;

sealed class EntityInitializeSystem : IEcsRunSystem
{
    private readonly EcsFilter<InitializeEntityRequest> _initializeEntityFilter = null;

    public void Run()
    {
        foreach (var i in _initializeEntityFilter)
        {
            ref var entity = ref _initializeEntityFilter.GetEntity(i);
            ref var request = ref _initializeEntityFilter.Get1(i);
            
            request.EntityReference.Entity = entity;
        }
    }
}