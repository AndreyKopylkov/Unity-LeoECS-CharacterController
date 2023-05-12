using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

sealed class PlayerMouseLookSystem : IEcsRunSystem, IEcsInitSystem
{
    private readonly EcsFilter<PlayerTag, ModelComponent, MouseLookDirectionComponent> _mouseLookFilter = null;
    private Quaternion _startTransformRotation;

    public void Init()
    {
        _startTransformRotation = _mouseLookFilter.GetEntity(0).Get<ModelComponent>().ModelTransform.rotation;
    }

    public void Run()
    {
        foreach (var i in _mouseLookFilter)
        {
            ref var model = ref _mouseLookFilter.Get2(i);
            ref var lookComponent = ref _mouseLookFilter.Get3(i);

            var _horizontal = lookComponent.Direction.x;
            var _vertical = lookComponent.Direction.y;

            var rotateHorizontal =
                Quaternion.AngleAxis(_horizontal, Vector3.up * Time.deltaTime * lookComponent.MouseSensitivity);
            var rotateVertical =
                Quaternion.AngleAxis(_vertical, Vector3.right * Time.deltaTime * lookComponent.MouseSensitivity);

            model.ModelTransform.rotation = _startTransformRotation * rotateHorizontal;
            lookComponent.CameraTransform.rotation = model.ModelTransform.rotation * rotateVertical;
        }
    }
}