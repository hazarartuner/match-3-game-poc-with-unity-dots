using Components;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class SpawnGemsSystem: ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Entity entity, ref GemComponent gem, ref EmptyComponent empty, ref GridPositionComponent positionComponent) =>
            {
                var gemType = Random.Range(0, GameHandler.GemPrefabs.Length);

                var prefabEntity = EntityManager.Instantiate(GameHandler.GemPrefabs[gemType]);
                EntityManager.AddComponentData(prefabEntity, new GemTypeComponent() { Value = gemType});
                EntityManager.AddComponentData(prefabEntity, positionComponent);
                EntityManager.AddComponentData(prefabEntity, gem);
            });
            
            EntityManager.DestroyEntity(Entities.WithAll(typeof(EmptyComponent)).ToEntityQuery());
        }
    }
}