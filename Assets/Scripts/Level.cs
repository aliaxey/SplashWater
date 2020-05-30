using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Level : MonoBehaviour {
    private LevelMap map;
    private int loadedStage;
    public int Stage { get; set; } = 1;
    public LevelMap Map {
        get {
            if (loadedStage != Stage) {
                LoadLevel(); 
            }
            return map;
        }
    }

    void Start() {
        DontDestroyOnLoad(this);
        loadedStage = 0;
    }

    public void StartGame() {
        SceneManager.LoadScene("game");
    }

    private void LoadLevel() {
        try {

            //StreamReader reader = new StreamReader());//reader.ReadToEnd();
            string json = Resources.Load<TextAsset>($"Levels/level{Stage}").text; 
            map = JsonUtility.FromJson<LevelMap>(json);
        } catch (FileNotFoundException) {
            GenerateLevel(); 
        }
        loadedStage = Stage;
    }
    private void GenerateLevel() {
        List<MapTile> tiles = new List<MapTile>();
        tiles.Add(new MapTile(0, 0)); 
        bool left = false; 
        for (int i = 0; i < 16 + Stage; i++) {
            var type = 0; 
            if (i % 3 == 0) {
                type = left ? 1 : 2;
                left = !left;
            }
            tiles.Add(new MapTile(type, Mathf.RoundToInt(UnityEngine.Random.Range(0, 5))));
        }
        map = new LevelMap();
        map.tiles = tiles.ToArray();
    }
}
