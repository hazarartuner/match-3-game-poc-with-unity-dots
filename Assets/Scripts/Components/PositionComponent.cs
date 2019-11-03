using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct GridPositionComponent: IComponentData
    {
        public int2 Value;
    }
}