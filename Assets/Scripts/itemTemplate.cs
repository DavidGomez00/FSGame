using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(SpriteRenderer))]
public class itemTemplate : MonoBehaviour
{
    public ShopItem item;
    public TMP_Text priceText;
    public TMP_Text nameText;
    public SpriteRenderer image;
    // Start is called before the first frame update
    void Start()
    {
        priceText.text = item.price + "Scumcoins";
        nameText.name = item.name;
        image.sprite = item.image;
        image.size = new Vector2(0.000015f, 0.000015f);
    }
}
