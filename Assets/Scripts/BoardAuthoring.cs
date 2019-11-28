using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class BoardAuthoring : MonoBehaviour, IDeclareReferencedPrefabs
{
    public int ColumnCount;

    public int RowCount;

    public GemPrefabsAuthoring GemPrefabs;


    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(GemPrefabs.gameObject);
    }
}
