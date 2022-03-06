using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New collection", menuName = "CityBuilder/CollectionSO")]
public class CollectionSO : ScriptableObject
{
    public RoadStructureSO roadStructure;
    public List<SingleStructureBaseSO> singleStructures;
    public List<ZoneStructureSO> zoneStructures;

    public List<StructureBaseSO> residentialStructures;
    public List<StructureBaseSO> commercialStoreStructures;
    public List<StructureBaseSO> parkStructures;

    public List<StructureBaseSO> utilitiesStructures;
    public List<StructureBaseSO> emergencyStructures;
    public List<StructureBaseSO> guildStructures;


    public List<StructureBaseSO> roadStructures;
}
