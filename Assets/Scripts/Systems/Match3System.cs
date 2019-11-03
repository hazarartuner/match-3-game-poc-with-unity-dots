using Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Systems
{
    public class Match3System: ComponentSystem
    {
        private NativeHashMap<float2, Entity> _matchedMap;
        
        protected override void OnUpdate()
        {
            
            Entities.ForEach((Entity entity, ref SelectedGemComponent selectedGemComponent,
                ref GridPositionComponent positionComponent, ref GemTypeComponent gemTypeComponent) =>
            {
                var positionComponentData = GetComponentDataFromEntity<GridPositionComponent>(true);
                var gemTypeComponentData = GetComponentDataFromEntity<GemTypeComponent>(true);

                if (positionComponentData.Exists(selectedGemComponent.Value) && gemTypeComponentData.Exists(selectedGemComponent.Value))
                {
                    var selectedGemPosition = positionComponentData[selectedGemComponent.Value].Value;
                    var selectedGemType = gemTypeComponentData[selectedGemComponent.Value].Value;

                    if (selectedGemType != gemTypeComponent.Value)
                    {
                        return;
                    }

                    var isHorizontalRelativeToSelectedGem =
                        math.abs(positionComponent.Value.y - selectedGemPosition.y) < 1;


                    if (isHorizontalRelativeToSelectedGem && (positionComponent.Value.x < selectedGemPosition.x || positionComponent.Value.x > selectedGemPosition.x))
                    {
//                        _matchedMap[new float2(positionComponent.Value.x, positionComponent.Value.y)] = entity;
                    }
                }
            });
        }
    }
}