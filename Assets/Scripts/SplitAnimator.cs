using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SplitAnimator {
    private List<Sprite> frames = new List<Sprite>();


    public SplitAnimator() {
        frames.AddRange(Resources.LoadAll<Sprite>("anim"));
    }

    public Sprite GetNext(float dx) {
        int frame = (int)((dx * 2.2f) * (frames.Count-1));
        if (frame >= frames.Count) {
            frame = frames.Count - 1;
        }
        Sprite sprite = frames[frame];
        return sprite; 
    }
}
