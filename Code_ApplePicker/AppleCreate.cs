using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class AppleCreate : MonoBehaviour
{
    //[BurstCompile]
    public GameObject Apple;
    public int instanceCount; 
    public float delay = 1f;

    private class AppleCreateBaker:Baker<AppleCreate>
    {
        public override void Bake(AppleCreate authoring)
        {
          Entity entityApplePrefab = GetEntity(authoring.Apple, TransformUsageFlags.Dynamic);
            // AppleCreateProperties AppleCreateProperties = new(entityApplePrefab, authoring.instanceCount);

            var propertiesComponent = new AppleCreateProperties
            {
                entityApplePrefab = entityApplePrefab,
                instanceCount = authoring.instanceCount, //<-Keep This line! very important
                Delay = authoring.delay,
                Timer = 2f
            };

            AddComponent(GetEntity(TransformUsageFlags.None), propertiesComponent);
        }
    }
} 

public struct AppleCreateProperties:IComponentData
{
    public Entity entityApplePrefab;
    public int instanceCount;
    public bool instantiated;
    public float Delay;
    public float Timer;
    


}
