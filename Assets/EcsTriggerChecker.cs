using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voody.UniLeo;

public class EcsTriggerChecker : MonoBehaviour
{
    [SerializeField] private string targetTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag(targetTag))
            return;

        WorldHandler.GetWorld().SendMessage(new DebugMessageRequest()
        {
            Message = "Player entered"
        });
        WorldHandler.GetWorld().SendMessage(new GameObjectActiveEvent());

        var entity = other.GetComponent<EntityReference>().Entity;
    }
}