using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrapper : MonoBehaviour {
    public Grid grid;
    private Object pref;
    private ObjectStorage objectStorage;
    private LevelManager levelManager;
    private MeshManager meshManager;
    internal bool isPlaying;

    void Start() {
        objectStorage = new ObjectStorage();
        levelManager = new LevelManager(this); 
        meshManager = new MeshManager(levelManager, objectStorage, grid);
        GameObject.Find("water").GetComponent<Spacing>().Manager = levelManager;
        meshManager.CreateRoad();
        isPlaying = true;
        
    }

    void Update() {
        if (isPlaying) {
            meshManager.Update();
        }
    }

    public void Restart() {
        levelManager.Retry();
    }

    public void ToMenu() {
        SceneManager.LoadScene("menu");
    }

}
