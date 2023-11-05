using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
//using Random = Unity.Mathematics.Random;

public class BasketSpawnAuthoring : MonoBehaviour
{
    
    public GameObject Basket;
    public int numBaskets = 3;
    public float basketSpacingY = 4f;
    public float basketBottomY = -14f;
    public bool respawn = true;
    

    private class BasketSpawnBaker : Baker<BasketSpawnAuthoring>
    {
        public override void Bake(BasketSpawnAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var propertiesComponent = new BasketSpawnProperties
            {
                Basket = GetEntity(authoring.Basket,TransformUsageFlags.Dynamic),
               // Random = Random.CreateFromIndex((uint)entity.Index),
                numBaskets = authoring.numBaskets,
                basketSpacingY = authoring.basketSpacingY,
                basketBottomY = authoring.basketBottomY,
                respawn = authoring.respawn
            };

            AddComponent(entity, propertiesComponent);

            
            var mouseMoveComponent = new MoveWithMouse() //GOES TO BasketMovement script!
            {
                move = true//GOES TO BasketMovement script!
            };

          AddComponent(entity, mouseMoveComponent);//GOES TO BasketMovement script!
            
        }
    }
}

public struct BasketSpawnProperties : IComponentData
{
    public Entity Basket;
    public int numBaskets;
    public float basketSpacingY;
    public float basketBottomY;
    //public Random Random;
    public bool respawn;

}

public struct MoveWithMouse : IComponentData//GOES TOBasketMovement script!
{
    public bool move;//GOES TO BasketMovement script!

}


