using Components;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    public class AlignToGridJobSystem: JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            return new AlignToGridJob().Schedule(this, inputDeps);
        }

        struct AlignToGridJob : IJobForEach<GridPositionComponent, Translation>
        {
            public void Execute(ref GridPositionComponent gridPosition, ref Translation translation)
            {
                translation.Value = new float3(gridPosition.Value.x * 1.2f, gridPosition.Value.y * 1.2f, 0);
            }
        }
    }
}