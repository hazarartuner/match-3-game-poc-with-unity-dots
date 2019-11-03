using Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
    public class SetActiveGemSystem: ComponentSystem
    {
        private float3? _clickedPosition;

        private Entity? _selectedEntity;

        protected override void OnUpdate()
        {
            if (Input.GetMouseButtonDown(0)) {
                _clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            } 
            
            if (Input.GetMouseButtonUp(0))
            {
                _clickedPosition = null;
            }

            if (_clickedPosition != null)
            {
                Entities.ForEach((Entity entity, ref GemComponent gemComponent, ref Translation translation) =>
                {
                    EntityManager.RemoveComponent(entity, typeof(SelectedGemComponent)); 
                });
                
                Entities.ForEach((Entity entity, ref GemComponent gemComponent, ref Translation translation) =>
                {
                    float3 lowestPoint = translation.Value + new float3(-0.5f, -0.5f, 0);
                    float3 highestPoint = translation.Value + new float3(0.5f, 0.5f, 0);

                    if (
                        _clickedPosition.Value.x >= lowestPoint.x && _clickedPosition.Value.y >= lowestPoint.y &&
                        _clickedPosition.Value.x <= highestPoint.x && _clickedPosition.Value.y <= highestPoint.y
                    )
                    {
                        _selectedEntity = entity;
                    }
                });

                Entities.ForEach((Entity entity, ref GemComponent gemComponent, ref Translation translation) =>
                {
                    if (_selectedEntity != null)
                    {
                        EntityManager.AddComponentData(entity,
                            new SelectedGemComponent() { Value = _selectedEntity.Value });
                    }
                });
            }
            else
            {
                _selectedEntity = null;
            }
        }
    }
}