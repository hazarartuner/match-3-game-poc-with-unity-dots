using Components;
using Unity.Entities;
using Unity.Mathematics;

namespace Systems
{
    public class BoardConversationSystem: GameObjectConversionSystem
    {
        protected override void OnUpdate()
        {
            var boards = GetEntityQuery(typeof(BoardAuthoring)).ToComponentArray<BoardAuthoring>();
            

            foreach (var board in boards)
            {
                for (var i = 0; i < board.ColumnCount; i++)
                {
                    for (var j = 0; j < board.RowCount; j++)
                    {
                        var gemEntity = CreateAdditionalEntity(board);
                        
                        DstEntityManager.AddComponentData(gemEntity, new GridPositionComponent()
                        {
                            Value = new float2(i, j)
                        });
                        DstEntityManager.AddComponentData(gemEntity, new GemPrefabBufferRefComponent()
                        {
                            PrefabsRef = GetPrimaryEntity(board.GemPrefabs)
                        });
                        DstEntityManager.AddComponent(gemEntity, typeof(EmptyComponent));
                        DstEntityManager.AddComponent(gemEntity, typeof(GemType));
                    }
                }   
            }
        }
    }
}