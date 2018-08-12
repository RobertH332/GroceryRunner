using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuModeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Text data;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) {
        data.gameObject.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData pointerEventData) {
        data.gameObject.SetActive(false);
    }
}
