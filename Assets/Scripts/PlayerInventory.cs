using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {

    public GameObject levelObj;

    private int slot1Count = 0;
    private int slot2Count = 0;
    private int slot3Count = 0;
    private int otherCount = 0;
    private int inventoryCount = 0;
    private int maxInventorySize = 0;

    public Text inventoryCountText;
    public Slider inventoryBar;
    public GameObject slot1Obj;
    public GameObject slot2Obj;
    public GameObject slot3Obj;

    private List<float> usedValues = new List<float>();

    private Slot slot1;
    private Slot slot2;
    private Slot slot3;

    private int extraSpace;
    private int extraSpaceEasy = 3;
    private int extraSpaceNormal = 1;
    private int extraSpaceHard = 0;

    private static int minItemReq = 4;
    private static int maxItemReq = 16;


    private void Start() {
        if (GameData.selectedMode == GameData.GameModes.Easy) {
            extraSpace = extraSpaceEasy;
        } else if (GameData.selectedMode == GameData.GameModes.Normal) {
            extraSpace = extraSpaceNormal;
        } else if (GameData.selectedMode == GameData.GameModes.Hard) {
            extraSpace = extraSpaceHard;
        }

        slot1 = slot1Obj.GetComponent<Slot>();
        slot2 = slot2Obj.GetComponent<Slot>();
        slot3 = slot3Obj.GetComponent<Slot>();

        slot1.SetItem(GameManager.instance.items[UniqueRandom(0, GameManager.instance.items.Length)]);
        slot2.SetItem(GameManager.instance.items[UniqueRandom(0, GameManager.instance.items.Length)]);
        slot3.SetItem(GameManager.instance.items[UniqueRandom(0, GameManager.instance.items.Length)]);
        usedValues.Clear();

        slot1.SetMaxSize(Random.Range(minItemReq, maxItemReq));
        slot2.SetMaxSize(Random.Range(minItemReq, maxItemReq));
        slot3.SetMaxSize(Random.Range(minItemReq, maxItemReq));

        maxInventorySize = slot1.maxSize + slot2.maxSize + slot3.maxSize + extraSpace;
        UpdateUI();
    }

    public void AddItem(Item item) {
        if (slot1.slotItem.itemName == item.itemName) {
            slot1Count++;
        } else if (slot2.slotItem.itemName == item.itemName) {
            slot2Count++;
        } else if (slot3.slotItem.itemName == item.itemName) {
            slot3Count++;
        } else {
            otherCount++;
        }

        inventoryCount = slot1Count + slot2Count + slot3Count + otherCount;
        UpdateUI();
        
        if (inventoryCount >= maxInventorySize) {
            if (slot1Count >= slot1.maxSize && slot2Count >= slot2.maxSize && slot3Count >= slot3.maxSize) {
                GameOverData.playerWon = true;
            } else {
                GameOverData.playerWon = false;
            }

            GameOverData.endingItemsSlot1 = slot1Count;
            GameOverData.endingItemsSlot2 = slot2Count;
            GameOverData.endingItemsSlot3 = slot3Count;
            GameOverData.maxItemsSlot1 = slot1.maxSize;
            GameOverData.maxItemsSlot2 = slot2.maxSize;
            GameOverData.maxItemsSlot3 = slot3.maxSize;
            GameOverData.wrongItems = otherCount;
            GameOverData.slot1ItemName = slot1.slotItem.name;
            GameOverData.slot2ItemName = slot2.slotItem.name;
            GameOverData.slot3ItemName = slot3.slotItem.name;

            SceneManager.LoadScene("GameOver");
        } else if (slot1Count >= slot1.maxSize && slot2Count >= slot2.maxSize && slot3Count >= slot3.maxSize) {
            GameOverData.playerWon = true;

            GameOverData.endingItemsSlot1 = slot1Count;
            GameOverData.endingItemsSlot2 = slot2Count;
            GameOverData.endingItemsSlot3 = slot3Count;
            GameOverData.maxItemsSlot1 = slot1.maxSize;
            GameOverData.maxItemsSlot2 = slot2.maxSize;
            GameOverData.maxItemsSlot3 = slot3.maxSize;
            GameOverData.wrongItems = otherCount;
            GameOverData.slot1ItemName = slot1.slotItem.name;
            GameOverData.slot2ItemName = slot2.slotItem.name;
            GameOverData.slot3ItemName = slot3.slotItem.name;

            SceneManager.LoadScene("GameOver");
        }
    }

    private void UpdateUI() {
        slot1.SetCount(slot1Count);
        slot2.SetCount(slot2Count);
        slot3.SetCount(slot3Count);
        inventoryBar.value = CalculateStorageBar();
        inventoryCountText.text = "Cart: " + inventoryCount + " / " + maxInventorySize;
    }

    public int UniqueRandom(int min, int max) {
        int val = Random.Range(min, max);

        while (usedValues.Contains(val)) {
            val = Random.Range(min, max);
        }

        usedValues.Add(val);
        return val;
    }

    private float CalculateStorageBar() {
        return (float) inventoryCount / maxInventorySize;
    }
}
