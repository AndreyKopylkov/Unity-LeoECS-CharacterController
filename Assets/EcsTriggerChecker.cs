using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class EcsTriggerChecker : MonoBehaviour
{
    [SerializeField] private string targetTag = "Player";

    private EcsComponentRef<JumpComponent> _jumpComponent;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag(targetTag))
            return;

        WorldHandler.GetWorld().SendMessage(new DebugMessageRequest()
        {
            Message = "Player entered"
        });
        WorldHandler.GetWorld().SendMessage(new GameObjectActiveEvent());
        
        var playerEntity = gameObject.GetComponent<EntityReference>().Entity;
        _jumpComponent = playerEntity.Ref<JumpComponent>();
        _jumpComponent.Unref().Force = 4;

        var canJump = !playerEntity.Has<BlockJumpDuration>();
    }
}