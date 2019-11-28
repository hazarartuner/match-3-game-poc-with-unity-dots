using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct GridPositionComponent: IComponentData
    {
        public float2 Value;
    }
}