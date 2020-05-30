using System;
[Serializable]
public class MapTile {
    public int type;
    public int number;
    public MapTile(int type, int number) {
        this.type = type;
        this.number = number; 
    }
}