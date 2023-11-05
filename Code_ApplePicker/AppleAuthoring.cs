using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class AppleAuthoring : MonoBehaviour
{
    private class AppleBaker : Baker<AppleAuthoring>
    {
        public override void Bake(AppleAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent<AppleTag>(entity);
        }
    }
}

public struct AppleTag : IComponentData { }
