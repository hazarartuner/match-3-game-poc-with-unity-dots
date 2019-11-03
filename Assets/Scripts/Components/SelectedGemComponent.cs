using Unity.Entities;

namespace Components
{
    public struct SelectedGemComponent: IComponentData
    {
        public Entity Value;
    }
}