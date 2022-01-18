using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[CreateAssetMenu(fileName ="New Item", menuName ="Item")]
public class ShopItem : ScriptableObject
{
    public new string name;
    public bool adquired;
    public int price;
    public Sprite image;
    public int type;
    public int id;
  

    public int getId() {
        return this.id;
    }

    public int getType()
    {
        return this.type;
    }

    public int getPrice()
    {
        return this.price;
    }

    public bool getAdquired()
    {
        return this.adquired;
    }

    public void setAdquired(bool newState) 
    {
        this.adquired = newState;
    }

    public void setId(int newId) 
    {
        this.id = newId;
    }

    //Para mostrar en el debug de shopScript
    public override string ToString()
    {
        return ("ID: " + id + " Precio: " + price + " Tipo: " + type + " Adquirido: " + adquired.ToString());
    }

    public void showBought() {
        //image.color = Color.white;
    }
}
