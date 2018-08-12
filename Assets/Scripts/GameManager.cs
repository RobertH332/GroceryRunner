using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool isPlaying = false;
    [HideInInspector]
    public PlayerController thePlayer;

    public GameObject[] items;

    public static GameManager instance = null;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        thePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void StartPlaying() {
        isPlaying = true;
    }

    public void StartLevel() {
        RestartLevel();
    }

    public void RestartLevel() {
        isPlaying = false;
        SceneManager.LoadScene("Game");
    }
}
