using Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Random = UnityEngine.Random;

namespace Systems
{
    public class SpawnGemsSystem: ComponentSystem
    {
        public NativeHashMap<float2, GemTypeComponent> AllGemsList;
        
        protected override void OnUpdate()
        {
            var gemCount = GameHandler.Instance.columnCount * GameHandler.Instance.rowCount;
            
            AllGemsList = new NativeHashMap<float2, GemTypeComponent>(gemCount, Allocator.Temp);
            
            Entities.ForEach((Entity entity, ref GemComponent gem, ref EmptyComponent empty, ref GridPositionComponent positionComponent) =>
            {
                var gemType = new GemTypeComponent() {Value = Random.Range(0, GameHandler.GemPrefabs.Length)};
                var prefabEntity = EntityManager.Instantiate(GameHandler.GemPrefabs[gemType.Value]);

                EntityManager.AddComponentData(prefabEntity, positionComponent);
                EntityManager.AddComponentData(prefabEntity, gemType);
                EntityManager.AddComponentData(prefabEntity, gem);

                AllGemsList[positionComponent.Value] = gemType;
            });
            
            EntityManager.DestroyEntity(Entities.WithAll(typeof(EmptyComponent)).ToEntityQuery());
        }
    }
}