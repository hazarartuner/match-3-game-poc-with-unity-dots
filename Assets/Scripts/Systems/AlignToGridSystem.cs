using Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    public class AlignToGridSystem: ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref GridPositionComponent positionComponent, ref Translation translation) =>
                {
                    translation.Value = new float3(positionComponent.Value.x * 1.2f, positionComponent.Value.y * 1.2f, 0);
                });
        }
    }
}