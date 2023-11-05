using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial struct MouseMovementSystem : ISystem
{
    public void OnUpdate(ref SystemState state )
    {
        foreach (var(transform, properties) in SystemAPI.Query<RefRW<LocalTransform>, RefRW<MoveWithMouse>>())
        {
            var pos = Input.mousePosition;
            pos.z -= Camera.main.transform.position.z;
            transform.ValueRW.Position = Camera.main.ScreenToWorldPoint(pos);
        }
    }
}
