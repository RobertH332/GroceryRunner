using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float forwardSpeed;
    private float strafeSpeed;

    private float forwardSpeedEasy = 160f;
    private float strafeSpeedEasy = 600f;

    private float forwardSpeedNormal = 220f;
    private float strafeSpeedNormal = 660f;

    private float forwardSpeedHard = 260f;
    private float strafeSpeedHard = 700f;

    public GameObject toStartObj;
    public GameObject cartBarTutorialObj;
    public GameObject slotTutorialObj;
    public GameObject moveTutorialObj;

    public AudioSource pickupSound;

    private Rigidbody2D rb;
    private PlayerInventory inv;

    private float movement = 0;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        inv = GetComponent<PlayerInventory>();
    }

    private void Start() {
        if (GameData.selectedMode == GameData.GameModes.Easy) {
            forwardSpeed = forwardSpeedEasy;
            strafeSpeed = strafeSpeedEasy;
        } else if (GameData.selectedMode == GameData.GameModes.Normal) {
            forwardSpeed = forwardSpeedNormal;
            strafeSpeed = strafeSpeedNormal;
        } else if (GameData.selectedMode == GameData.GameModes.Hard) {
            forwardSpeed = forwardSpeedHard;
            strafeSpeed = strafeSpeedHard;
        }
    }

    private void Update() {
        if (!GameManager.instance.isPlaying) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                GameManager.instance.StartPlaying();
                toStartObj.SetActive(false);
                cartBarTutorialObj.SetActive(false);
                slotTutorialObj.SetActive(false);
                moveTutorialObj.SetActive(false);
            }
        } else {
            movement = Input.GetAxis("Horizontal");

            if (Input.GetKeyDown(KeyCode.R)) {
                GameManager.instance.RestartLevel();
            }
        }
    }

    public void FixedUpdate() {
        Vector3 targetVel = rb.velocity;

        if (GameManager.instance.isPlaying) {
            if (movement < -0.1) {
                transform.rotation = Quaternion.Euler(0, 0, 25);
            } else if (movement > 0.1) {
                transform.rotation = Quaternion.Euler(0, 0, -25);
            } else {
                transform.rotation = Quaternion.identity;
            }

            targetVel.x += movement * strafeSpeed;
        }

        targetVel.y = forwardSpeed;

        rb.velocity = targetVel * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Item") {
            inv.AddItem(other.gameObject.GetComponent<Item>());
            pickupSound.Play();
            Destroy(other.gameObject);
        }
    }
}
