using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct AppleInstantiate : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var appleSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
        var ECB = appleSingleton.CreateCommandBuffer(state.WorldUnmanaged);

        foreach (var (transform, properties) in SystemAPI.Query<RefRW<LocalTransform>, RefRW<AppleCreateProperties>>())
        {
            if (properties.ValueRO.Timer <= 0)
            {
                var apple = ECB.Instantiate(properties.ValueRO.entityApplePrefab);
                ECB.SetComponent(apple, LocalTransform.FromPosition(transform.ValueRO.Position));

                properties.ValueRW.Timer = properties.ValueRO.Delay;

            }
            else
            {
                properties.ValueRW.Timer = properties.ValueRO.Timer - SystemAPI.Time.DeltaTime;
            }

        }
    }
}
