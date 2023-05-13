using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class EcsDeathTrigger : MonoBehaviour
{
    [SerializeField] private string targetTag = "Player";

    private EcsComponentRef<JumpComponent> _jumpComponent;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag(targetTag))
            return;
        
        WorldHandler.GetWorld().SendMessage(new GameObjectActiveEvent());
        
        var playerEntity = other.GetComponent<EntityReference>().Entity;
        playerEntity.Get<PerformDeathEvent>();
    }
}