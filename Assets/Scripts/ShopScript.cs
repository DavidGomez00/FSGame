using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopScript : MonoBehaviour
{
    public TMP_Text currencyTXT;
    public List<itemTemplate> items;
    public List<ShopItem> itemsAdquired;
    public int[] idsAdquired;
  
    // Start is called before the first frame update
    void Start()
    {
        currencyTXT.text = "Currency: " + PlayerPrefs.GetInt("Currency");
        
        //Llama a la función que distribuye linealmente los objetos en el scroll
        reArrangeObjs();

        //Leemos del binnary formatter los ids de los objetos adquiridos, buscamos cuales son, y los guardamos para usar en esta ejecución
        idsAdquired = new int[items.Count];
        int[] temp = SaveSystem.LoadPlayerData().idsAdquired;
        temp.CopyTo(idsAdquired, 0);

        if (idsAdquired.Length > 0)
        {
            int i = -1;
            foreach (itemTemplate s in items)
            {
                i++;
                if (s.item.id == idsAdquired[i])
                {
                    itemsAdquired.Add(s.item);
                }
            }
        }
    }

    public void GetCurrency()
    {
        currencyTXT.text = "Currency: " + PlayerPrefs.GetInt("Currency");
    }

    public void reArrangeObjs() {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].gameObject.transform.localPosition = new Vector3(1.9f + (i * 2), 0, 0);
        }
    }

    //Gestiona la compra de un objeto de la tienda pasado por referencia
    public void buyItem(ShopItem itemToBuy) 
    {

        int currentCurrency = PlayerPrefs.GetInt("Currency");
        Debug.Log(itemToBuy.ToString());

        //Gestiona la compra si tienes el dinero suficiente y no has comprado ya el objeto
        if (currentCurrency >= itemToBuy.price && itemToBuy.adquired == false)
        {
            currentCurrency -= itemToBuy.price;
            PlayerPrefs.SetInt("Currency", currentCurrency);
            itemToBuy.adquired = true;
            GetCurrency();
            Debug.Log(itemToBuy.ToString());
            itemsAdquired.Add(itemToBuy);

            //TODO: No está guardando el id del nuevo objeto comprado, por lo tanto no ira al save system 
        }
        else 
        {
            Debug.LogWarning("No puedes comprar el objeto, ya lo tienes o no tienes dinero suficiente");
        }
    }
}
