using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class BasketAuthoring : MonoBehaviour
{
    private class BasketBaker : Baker<BasketAuthoring>
    {
        public override void Bake(BasketAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent<BasketTag>(entity);
        }
    }
}

public struct BasketTag : IComponentData { }
