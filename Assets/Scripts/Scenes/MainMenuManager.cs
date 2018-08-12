using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

	public Button easyBtn;
    public Button normalBtn;
    public Button hardBtn;

    private void Start() {
        easyBtn.onClick.AddListener(SelectEasyMode);
        normalBtn.onClick.AddListener(SelectNormalMode);
        hardBtn.onClick.AddListener(SelectHardMode);
    }

    private void SelectEasyMode() {
        GameData.selectedMode = GameData.GameModes.Easy;
        Invoke("StartLevel", 0.2f);
    }

    private void SelectNormalMode() {
        GameData.selectedMode = GameData.GameModes.Normal;
        Invoke("StartLevel", 0.2f);
    }

    private void SelectHardMode() {
        GameData.selectedMode = GameData.GameModes.Hard;
        Invoke("StartLevel", 0.2f);
    }

    private void StartLevel() {
        if (GameManager.instance == null) {
            SceneManager.LoadScene("Game");
        } else {
            GameManager.instance.StartLevel();
        }
    }
}
