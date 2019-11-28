using Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    public class PositionSystem: ComponentSystem
    {
        protected override void OnUpdate()
        {
            var offset = new float3(0, -1, 0);
            Entities.ForEach((ref GridPositionComponent gridPositionComponent, ref Translation translation) =>
                {
                    translation.Value = new float3(gridPositionComponent.Value.x * 1.2f, gridPositionComponent.Value.y * 1.2f, 0) + offset;
                });
        }
    }
}