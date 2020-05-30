using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MeshManager {
    private readonly LevelManager levelManager;
    private readonly ObjectStorage objectStorage;
    private readonly Grid grid;
    public GameObject movable;
    private Vector3Int nextTilePosition;
    private Quaternion nextRotation;

    private IList<RoadTile> tiles;
    private int tileCount;
    private float progress;
    
    public MeshManager(LevelManager levelManager, ObjectStorage objectStorage, Grid grid) {
        this.levelManager = levelManager;
        this.objectStorage = objectStorage;
        this.grid = grid;
        movable = GameObject.Find("water");
        tiles = new List<RoadTile>();
        nextTilePosition = new Vector3Int(0, 0, 0);
        nextRotation = Quaternion.identity;
        progress = 0;
        tileCount = 0;
    }

    public void CreateRoad() {
        var map = levelManager.level.Map;
        foreach (MapTile tile in map.tiles) {
            AddRoad((RoadType) tile.type, tile.number);
        }
        /*
        AddRoad(RoadType.FORWARD, 0);
        AddRoad(RoadType.RIGHT, 1);
        AddRoad(RoadType.LEFT, 0);
        AddRoad(RoadType.FORWARD, 2);
        AddRoad(RoadType.RIGHT, 1);
        AddRoad(RoadType.FORWARD, 0);
        AddRoad(RoadType.FORWARD, 1);
        AddRoad(RoadType.RIGHT, 1);
        AddRoad(RoadType.LEFT, 2);
        AddRoad(RoadType.FORWARD, 1);
        AddRoad(RoadType.RIGHT, 1);
        AddRoad(RoadType.FORWARD, 1);
        AddRoad(RoadType.FORWARD, 0);
        AddRoad(RoadType.RIGHT, 1);
        AddRoad(RoadType.LEFT, 2);
        AddRoad(RoadType.FORWARD, 3);
        AddRoad(RoadType.FORWARD, 1);
        AddRoad(RoadType.FORWARD, 4);
        AddRoad(RoadType.FORWARD, 5);
        */

    }

    public void AddRoad(RoadType type, int number) {
        var tileSpawn = grid.CellToLocal(nextTilePosition);
        var start = tileSpawn - (nextRotation * Vector3.up * grid.cellSize.x / 2);
        Object prefab = null;
        Object border = null;
        RoadTile tile = null;
        switch (type) {
            case RoadType.FORWARD:
                tile = new ForwardRoadTile(start, nextRotation);
                prefab = objectStorage.GetForward(number);
                border = objectStorage.forwardComplete;
                break;
            case RoadType.LEFT:
                tile = new LeftRoadTile(start, nextRotation);
                prefab = objectStorage.GetAngle(number);
                border = objectStorage.angleComplete;
                break;
            case RoadType.RIGHT:
                tile = new RightRoadTile(start, nextRotation);
                prefab = objectStorage.GetAngle(number);
                border = objectStorage.angleComplete; 
                nextRotation *= Quaternion.Euler(0, 180, 0);
                break;
        }
        GameObject.Instantiate(prefab, grid.CellToWorld(nextTilePosition), nextRotation, grid.gameObject.transform);
        GameObject.Instantiate(border, grid.CellToWorld(nextTilePosition) + new Vector3(0, 0, -1), nextRotation, grid.gameObject.transform);
        tiles.Add(tile);
        nextTilePosition += tile.GetNextTile();
        nextRotation = tile.GetNextRotation();
    }

    public void Update() {
        progress = progress + Time.deltaTime / 2;
        if(progress >=1) {
            progress = 0;
            tileCount++;
            if (tileCount == tiles.Count) {
                levelManager.Win();
                return;
            }
        }
        var position = tiles[tileCount].GetTransform(progress);
        grid.gameObject.transform.position = new Vector3(position.Position.x * -1, position.Position.y * -1, 10);
        //movable.transform.position = position.Position;
        movable.transform.rotation = position.Rotation; 
    }
}