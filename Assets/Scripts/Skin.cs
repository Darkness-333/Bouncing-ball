
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Skin : MonoBehaviour, IPointerClickHandler {
    [SerializeField] private SkinStore skinStore;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private GameObject indicator;
    [SerializeField] private int cost;

    public void OnPointerClick(PointerEventData eventData) {
        skinStore.SelectSkin(this);
    }

    public void Select(bool select) {
        indicator.SetActive(select);
        
    }

    public int GetCost() {
        return cost;
    }

    private void OnValidate() {
        costText.SetText(cost.ToString());
    }
}