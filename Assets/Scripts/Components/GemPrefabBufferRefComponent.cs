using Unity.Entities;

namespace Components
{
    public struct GemPrefabBufferRefComponent: IComponentData
    {
        public Entity PrefabsRef;
    }
}