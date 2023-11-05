using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class AppleTreeAuthoring : MonoBehaviour
{
    public float speed;
    public float leftAndRightEdge;
    public float changeDirectionChance;
    
    private class AppleTreeBaker : Baker<AppleTreeAuthoring>
    {
        public override void Bake(AppleTreeAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var propertiesComponent = new AppleTreeProperties
            {
                Speed = authoring.speed,
                LeftAndRightEdge = authoring.leftAndRightEdge,
                ChangeDirectionChance = authoring.changeDirectionChance,
                Random = Random.CreateFromIndex((uint)entity.Index)
            };

            AddComponent(entity, propertiesComponent);

            /*
            var mouseMoveComponent = new MoveWithMouse() //GOES TO BasketMovement script!
            {
                move = true//GOES TO BasketMovement script!
            };

          AddComponent(entity, mouseMoveComponent);//GOES TO BasketMovement script!
            */
        }
    }
}

public struct AppleTreeProperties : IComponentData
{
    public float Speed;
    public float LeftAndRightEdge;
    public float ChangeDirectionChance;

    public Random Random;
}
/*
public struct MoveWithMouse : IComponentData//GOES TOBasketMovement script!
{
    public bool move;//GOES TO BasketMovement script!

}
*/
