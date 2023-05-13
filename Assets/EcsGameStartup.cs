using System;
using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class EcsGameStartup : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        _systems.ConvertScene();
        
        AddInjections();
        AddSystems();
        AddOneFrames();
        
        
        _systems.Init();
    }

    private void Update()
    {
        _systems.Run();
    }

    private void OnDestroy()
    {
        if(_systems == null)
            return;
        
        _systems.Destroy();
        _systems = null;
        _world.Destroy();
        _world = null;
    }

    private void AddInjections()
    {
        
    }

    private void AddSystems()
    {
        _systems.
            Add(new DebugSystem()).
            Add(new JumpBlockSystem()).
            Add(new CursorLockSystem()).
            Add(new PlayerInputSystem()).
            Add(new PlayerJumpSendEventSystem()).
            Add(new PlayerGroundCheckSystem()).
            Add(new PlayerMouseInputSystem()).
            Add(new MovementSystem()).
            Add(new PlayerMouseLookSystem()).
            Add(new PlayerJumpSystem())
            ;
    }

    private void AddOneFrames()
    {
        _systems.
            OneFrame<JumpEvent>().
            OneFrame<InitializeEntityRequest>()
            ;
    }
}
