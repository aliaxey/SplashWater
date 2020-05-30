﻿
using UnityEngine;
using UnityEngine.UI;

public class Spacing : MonoBehaviour {
    public GameObject left, right;
    private LevelManager levelManager;
    [SerializeField]
    private double speed = 1;
    private const float MAX_DISTANCE = 1.24f;
    private Scrollbar scrollbar;
    private Vector3 targetLeft = Vector3.zero;
    private Vector3 targetRight = Vector3.zero;
    private SplitAnimator animator;
    private SpriteRenderer rightRenderer, leftRenderer;
    
    internal LevelManager Manager {
        get {
            return levelManager;
        }
        set {
            levelManager = value;
        }
    }

    void Start() {
        scrollbar = GameObject.Find("Scrollbar").GetComponent<Scrollbar>();
        scrollbar.onValueChanged.AddListener(OnSetScale);
        animator = new SplitAnimator();
        leftRenderer = left.GetComponent<SpriteRenderer>();
        rightRenderer = right.GetComponent<SpriteRenderer>();
    }


    void Update() {
        var sprite = animator.GetNext(right.transform.localPosition.x);
        leftRenderer.sprite = sprite;
        rightRenderer.sprite = sprite; 
        left.transform.localPosition = Vector3.MoveTowards(left.transform.localPosition, targetLeft, (float) (Time.deltaTime * speed));
        right.transform.localPosition = Vector3.MoveTowards(right.transform.localPosition, targetRight, (float)(Time.deltaTime * speed)); 
    }

    public void OnSetScale(float f) {

        targetLeft = new Vector3(-MAX_DISTANCE * f, 0, 0);
        targetRight = new Vector3(MAX_DISTANCE * f, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Barrier") {
            levelManager.Loose();
        }
    }

}
