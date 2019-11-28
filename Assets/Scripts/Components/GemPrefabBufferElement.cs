using Unity.Entities;

namespace Components
{
    public struct GemPrefabBufferElement: IBufferElementData
    {
        public Entity Prefab;
    }
}