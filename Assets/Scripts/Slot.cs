using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

    public GameObject itemObj;
    public GameObject itemCountObj;

    private Image itemImg;
    private Text itemCount;

    public int maxSize = 0;

    public Item slotItem;

    private void Start() {
        itemImg = itemObj.GetComponent<Image>();
        itemCount = itemCountObj.GetComponent<Text>();
    }

    public void SetMaxSize(int size) {
        maxSize = size;
    }

    public void SetCount(int current) {
        itemCount.text = current + " / " + maxSize;
    }

    private void SetImage(Sprite sprite) {
        itemImg.sprite = sprite;
    }

    public void SetItem(GameObject item) {
        slotItem = item.GetComponent<Item>();
        SetImage(slotItem.gameObject.GetComponent<SpriteRenderer>().sprite);
    }
}
