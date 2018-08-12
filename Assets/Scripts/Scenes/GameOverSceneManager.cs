using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSceneManager : MonoBehaviour {

    public Text result;
    public Text gameOverStat1;
    public Text gameOverStat2;
    public Text gameOverStat3;
    public Text wrongItemsCount;
    public Button mainMenuButton;
    public Button restartButton;

    private void Start() {
        if (GameOverData.playerWon) {
            result.text = "You Won";
        } else {
            result.text = "You Lost";
        }

        gameOverStat1.text = GameOverData.slot1ItemName + ": " + GameOverData.endingItemsSlot1 + " / " + GameOverData.maxItemsSlot1;
        gameOverStat2.text = GameOverData.slot2ItemName + ": " + GameOverData.endingItemsSlot2 + " / " + GameOverData.maxItemsSlot2;
        gameOverStat3.text = GameOverData.slot3ItemName + ": " + GameOverData.endingItemsSlot3 + " / " + GameOverData.maxItemsSlot3;
        wrongItemsCount.text = "Wrong Items: " + GameOverData.wrongItems;

        mainMenuButton.onClick.AddListener(MainMenuButtonClick);
        restartButton.onClick.AddListener(RestartLevel);
    }

    private void RestartLevel() {
        Invoke("Restart", 0.2f);
    }

    private void MainMenuButtonClick() {
        Invoke("LoadMenu", 0.2f);
    }

    private void LoadMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    private void Restart() {
        GameManager.instance.RestartLevel();
    }
}
