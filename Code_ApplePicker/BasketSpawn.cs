using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct BasketSpawn : ISystem
{

    // Update is called once per frame

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var basketSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
        var ECB = basketSingleton.CreateCommandBuffer(state.WorldUnmanaged);

        foreach (var (transform, properties) in SystemAPI.Query<RefRW<LocalTransform>, RefRW<BasketSpawnProperties>>())
        {
            if (properties.ValueRO.respawn == true)
            {
                for (int index = 0; index < 3; index++)
                {
                    var basket = ECB.Instantiate(properties.ValueRO.Basket);
                    var pos = new float3
                    {
                        y = properties.ValueRO.basketBottomY + (properties.ValueRO.basketSpacingY * index) + properties.ValueRO.numBaskets
                    };

                    ECB.SetComponent(basket, LocalTransform.FromPosition(transform.ValueRO.Position));

                }

            }

            properties.ValueRW.respawn = false;
        }
    }

}
