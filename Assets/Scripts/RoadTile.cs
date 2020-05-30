using UnityEngine;

public abstract class RoadTile {
    protected Vector3 startPosition;
    protected Quaternion rotation;

    public RoadTile(Vector3 startPosition, Quaternion rotation) {
        this.startPosition = startPosition;
        this.rotation = rotation; 
    }

    public abstract PositionBundle GetTransform(float factor);

    public abstract Vector3Int GetNextTile();

    public abstract Quaternion GetNextRotation();
}