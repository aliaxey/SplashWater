using UnityEngine;

public class LevelManager {
    private GameObject winWindow;
    private GameObject looseWindow;
    private Bootstrapper bootstrapper;
    public Level level { get; private set; }

    public LevelManager(Bootstrapper bootstrapper) {
        this.bootstrapper = bootstrapper;
        winWindow = GameObject.Find("WinPanel");
        looseWindow = GameObject.Find("LoosePanel");
        level = GameObject.Find("Level").GetComponent<Level>();
    }

    public void Retry() {
        level.StartGame();
    }

    public void Win() {
        bootstrapper.isPlaying = false;
        level.Stage++;
        winWindow.GetComponent<Animator>().SetTrigger("show");
    }
    public void Loose() {
        bootstrapper.isPlaying = false;
        looseWindow.GetComponent<Animator>().SetTrigger("show");
    }

}