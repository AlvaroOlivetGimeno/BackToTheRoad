using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemData : ScriptableObject
{
    // Start is called before the first frame update
    private enum ItemsType { Cookie, Water, Medicine, Gasoline };
    [Header("INVENTORY SLOT TYPE:")]
    [SerializeField] private ItemsType SlotItem;

    [Header("SRPITE OF ITEMS:")]
    [SerializeField] public Sprite itemImage;


    private enum itemBehaviour { Life, Thirsty, Hunger, Energy };
    [Header("INVENTORY SLOT TYPE:")]
    [SerializeField] itemBehaviour BehaviourItem;

    [Header("INVENTORY SLOT TYPE:")]
    [SerializeField] private float amountOfitem = 0.0f;

    public float GetItemAmount() { return amountOfitem; }

    public Sprite GetImage() { return itemImage; }

    public string GetItem() { return SlotItem.ToString(); }

    public string GetItemBehaviour() { return BehaviourItem.ToString(); }

}
