using UnityEngine;
using System.Collections;

public class GameData {
    public enum GameModes {
        Easy,
        Normal,
        Hard
    }

    public static GameModes selectedMode = GameModes.Normal;
}
