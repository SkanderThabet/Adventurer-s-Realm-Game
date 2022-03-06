using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZonePlacementHelper : StructureModificationHelper
{
    private Vector3 _mapBottomLeftCorner;
    private Vector3 _startPoint;
    private Vector3? _previousEndPosition = null;
    private bool _startPositionAcquired = false;
    private Queue<GameObject> _gameObjectsToReuse = new Queue<GameObject>();
    private int _structuresOldQty = 0; 

    public ZonePlacementHelper(StructureRepository structureRepository, GridStructure grid, IPlacementManager placementManager, Vector3 mapBottomLeftCorner, IResourceManager resourceManager) 
        : base(structureRepository, grid, placementManager, resourceManager)
    {
        this._mapBottomLeftCorner = mapBottomLeftCorner;
    }

    public override void PrepareStructureForModification(Vector3 inputPosition, string structureName, StructureType structureType)
    {
        base.PrepareStructureForModification(inputPosition, structureName, structureType);
        GameObject buildingPrefab = _structureData.prefab;
        Vector3 gridPosition = _grid.CalculateGridPosition(inputPosition);
        var gridPositionInt = Vector3Int.FloorToInt(gridPosition);

        if (!_grid.IsCellTaken(gridPosition))
        {
            if (_structuresToBeModified.ContainsKey(gridPositionInt))
            {
                RevokeStructurePlacementAt(gridPositionInt);
                _resourceManager.ReduceMoneyFromShoppingCartAmount(_structureData.placementCost);
                _resourceManager.ReduceSteelFromShoppingCartAmount(_structureData.requiredSteelAmount);
                _resourceManager.ReduceWoodFromShoppingCartAmount(_structureData.requiredWoodAmount);
            }
            else
            {
                PlaceNewStructureAt(gridPosition, buildingPrefab, gridPositionInt);
                _resourceManager.AddMoneyToShoppingCartAmount(_structureData.placementCost);
                _resourceManager.AddSteelToShoppingCartAmount(_structureData.requiredSteelAmount);
                _resourceManager.AddWoodToShoppingCartAmount(_structureData.requiredWoodAmount);
            }

        }
    }

    private void PlaceNewStructureAt(Vector3 gridPosition, GameObject buildingPrefab, Vector3Int gridPositionInt)
    {
        Vector3 distance1 = new Vector3(0.0f,0.1f,0.0f);
                                 Vector3Int distance2    = new Vector3Int(0,0,0);

  for(int i = 0 ; i<_structureData.width;i++){
            for(int j = 0 ; j<_structureData.height-1;j++){
    
          distance1 = new Vector3(3.0f*i,0.1f,3.0f*j);

         Vector3Int position1 = new Vector3Int(-3*i,0,3*j);
     GameObject objToSpawn=  new GameObject();
    if(!_grid.IsCellTaken(distance1)) {
        _structuresToBeModified.Add(gridPositionInt + position1,objToSpawn);
    }
                  }
        }
        
        if(_structureData.width==1&&_structureData.height!=1){
                distance1 = new Vector3(3.0f*0,0.1f,3.0f*_structureData.height);
                          distance2    = new Vector3Int(0,0,3*_structureData.height);

        }else{
                distance1 = new Vector3(3.0f*_structureData.width,0.1f,3.0f*_structureData.height);
                          distance2    = new Vector3Int(-3*_structureData.width,0,3*_structureData.height);

        }
        
        if(_structureData.height==1&&_structureData.width!=1){
                            distance1 = new Vector3(3.0f*_structureData.width,0.1f,3.0f*0);
                                      distance2    = new Vector3Int(-3*_structureData.width,0,0);

        }else{

        
                        distance1 = new Vector3(3.0f*_structureData.width,0.1f,3.0f*_structureData.height);
                                  distance2    = new Vector3Int(3*_structureData.width,0,3*_structureData.height);


    }if(_structureData.width==1&&_structureData.height==1){
    distance1 = new Vector3(3.0f*0,0.1f,3.0f*0);
              distance2    = new Vector3Int(0,0,0);

    }else{
    distance1 = new Vector3(3.0f*_structureData.width,0.1f,3.0f*_structureData.height);
              distance2    = new Vector3Int(3*_structureData.width,0,3*_structureData.height);

    }
        if(!_grid.IsCellTaken(distance1)) {

         Vector3 distance3 =  new Vector3((distance1.x/2),0.1f,(distance1.z/2));
        _structuresToBeModified.Add(gridPositionInt + distance2, _placementManager.CreateGhostStructure(gridPosition + distance3, buildingPrefab));
        }
    }
    private void RevokeStructurePlacementAt(Vector3Int gridPositionInt)
    {
        var structure = _structuresToBeModified[gridPositionInt];
        _placementManager.DestroySingleStructure(structure);
        _structuresToBeModified.Remove(gridPositionInt);
    }

    public override void CancelModifications()
    {
        base.CancelModifications();
    }

    public override void ConfirmModifications()
    {
        if (_structureData.GetType() == typeof(ZoneStructureSO) && ((ZoneStructureSO)_structureData).zoneType == ZoneType.Residential)
        {
            _resourceManager.AddToPopulation(((ZoneStructureSO)_structureData).GetResidentsAmount() * _structuresToBeModified.Count);
        }
        base.ConfirmModifications();
    }

}
