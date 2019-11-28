using System.Collections;
using System.Collections.Generic;
using Components;
using Unity.Entities;
using UnityEngine;

public class GemPrefabsAuthoring : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
{
    public GameObject[] GemPrefabs;


    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var buffer = dstManager.AddBuffer<GemPrefabBufferElement>(entity);

        foreach (var prefab in GemPrefabs)
        {
            buffer.Add(new GemPrefabBufferElement()
            {
                Prefab = conversionSystem.GetPrimaryEntity(prefab)
            });
        }
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.AddRange(GemPrefabs);
    }
}
