using Unity.Entities;
using Unity.Transforms;

public partial struct AppleFall : ISystem
{ 

    // Update is called once per frame
    void OnUpdate(ref SystemState state)
    {
        foreach (var (transform, _) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<AppleTag>>())
        {
            var pos = transform.ValueRO.Position;
            var speed = 5f;

            pos.y -= speed * SystemAPI.Time.DeltaTime;
            transform.ValueRW.Position = pos;
        }
    }   
}
