using UnityEngine;

public class RightRoadTile : RoadTile {

    public const float CELL_RADIUS = 2;

    public RightRoadTile(Vector3 startPosition, Quaternion rotation) : base(startPosition, rotation) {

    }

    public override Vector3Int GetNextTile() {
        var vector = rotation * new Vector3(1, 0, 0);
        return new Vector3Int(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y), 0);
    }

    public override PositionBundle GetTransform(float factor) {
        float angle = -90 * factor;
        var x = -CELL_RADIUS * Mathf.Cos(Mathf.Deg2Rad * angle);
        var y = -CELL_RADIUS * Mathf.Sin(Mathf.Deg2Rad * angle);
        var localPosition = (new Vector3(x, y, 0) + (Vector3.right * CELL_RADIUS));
        var position = rotation * localPosition;
        return new PositionBundle(startPosition + position, rotation * Quaternion.Euler(0, 0, angle));
    }

    public override Quaternion GetNextRotation() {

        return rotation * Quaternion.Euler(0, 0, -90);
    }
}