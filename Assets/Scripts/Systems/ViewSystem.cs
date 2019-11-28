using Components;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
    public class ViewSystem: ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Entity entity, ref GemPrefabBufferRefComponent gemPrefabBufferRefComponent, ref EmptyComponent emptyComponent, ref GridPositionComponent gridPositionComponent) =>
            {
                var prefabs = EntityManager.GetBuffer<GemPrefabBufferElement>(gemPrefabBufferRefComponent.PrefabsRef);
                var count = prefabs.Length;
                var random = Random.Range(0, count - 1);
                var viewEntity = EntityManager.Instantiate(prefabs[random].Prefab);

                EntityManager.AddComponentData(viewEntity, gridPositionComponent);
                EntityManager.RemoveComponent(entity, typeof(EmptyComponent));
            });
        }
    }
}