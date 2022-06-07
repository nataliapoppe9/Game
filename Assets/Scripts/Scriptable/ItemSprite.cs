using System;
using UnityEngine;

[CreateAssetMenu(fileName ="New Gadget", menuName="item")]
public class ItemSprite : ScriptableObject
{
    public string nombreGadget;
    public string detailsGadget;
    public int priceGadget;
    public Sprite imageGadget;
}
