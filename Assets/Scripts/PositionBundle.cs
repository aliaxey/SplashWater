using UnityEngine;
/*
public class PositionBundle {
    private Vector3 position;
    private Quaternion rotation;
    public Vector3 Position {
        get {
            return position; 
        }
    }
    public Quaternion Rotation {
        get {
            return rotation;
        }
    }

    public PositionBundle(Vector3 position, Quaternion rotation) {
        this.position = position;
        this.rotation = rotation;
    }
}
*/
public struct PositionBundle {
    Vector3 position;
    Quaternion rotation;

    public PositionBundle(Vector3 position, Quaternion rotation) {
        this.position = position;
        this.rotation = rotation;
    }
    public Quaternion Rotation {
        get {
            return rotation;
        }
        set {
            rotation = value;
        }
    }
    public Vector3 Position {
        get {
            return position;
        }

        set {
            position = value;
        }
    }
}