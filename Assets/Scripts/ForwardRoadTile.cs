using UnityEngine;

internal class ForwardRoadTile : RoadTile {
    private Vector3 direction;
    public ForwardRoadTile(Vector3 startPosition, Quaternion rotation) : base(startPosition, rotation) {
        direction = rotation * Vector3.up; 
    }

    public override Vector3Int GetNextTile() {
        return new Vector3Int(Mathf.RoundToInt(direction.x), Mathf.RoundToInt(direction.y), Mathf.RoundToInt(direction.z)); 
    }

    public override PositionBundle GetTransform(float factor) {
        var length = 4 * factor;
        return new PositionBundle(startPosition + (direction * length), rotation);  
    }

    public override Quaternion GetNextRotation() {
        return rotation;
    }
}