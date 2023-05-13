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

        var entity = other.GetComponent<EntityReference>().Entity;
    }
}