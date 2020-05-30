using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumber : MonoBehaviour {
    void Start() {
        var level = GameObject.Find("Level").GetComponent<Level>();
        GetComponent<Text>().text = $"Level {level.Stage}";
    }

}
