using System.Collections.Generic;
using UnityEngine;

public class ObjectStorage {
    private List<Object> forwardPrefabs;
    private List<Object> anglePrefabs;
    public Object forwardComplete { get; private set; }
    public Object angleComplete { get; private set; }
   
    public ObjectStorage() {
        forwardPrefabs = new List<Object>();
        anglePrefabs = new List<Object>();
        forwardPrefabs.AddRange(Resources.LoadAll("forwardPrefabs"));
        anglePrefabs.AddRange(Resources.LoadAll("anglePrefabs"));
        forwardComplete = Resources.Load("forward_complete");
        angleComplete = Resources.Load("angle_complete");
    }

    public Object GetForward(int number) {
        return forwardPrefabs[number];
    }
    public Object GetAngle(int number) {
        return anglePrefabs[number];
    }

}