using Components;
using Unity.Collections;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEditor.PackageManager;

public class GameHandler : MonoBehaviour
{
    public GameObject[] gems;

    public int columnCount;
    
    public int rowCount;

    public static Entity[] GemPrefabs;
    
    private EntityManager _em;

    void Start()
    {
        _em = World.Active.EntityManager;

        GemPrefabs = new Entity[gems.Length];

        for (var i = 0; i < gems.Length; i++)
        {
            GemPrefabs[i] = GameObjectConversionUtility.ConvertGameObjectHierarchy(gems[i], World.Active);
        }


        for (var i = 0; i < columnCount; i++)
        {
            for (var j = 0; j < rowCount; j++)
            {
                var entity = _em.CreateEntity();
                _em.AddComponentData(entity, new EmptyComponent());
                _em.AddComponentData(entity, new GemComponent());
                _em.AddComponentData(entity, new GridPositionComponent() { Value = new int2(i, j)});
            }
        }
    }
}
