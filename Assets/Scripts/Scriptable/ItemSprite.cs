using System;
using UnityEngine;

[CreateAssetMenu(fileName ="New Gadget", menuName="item")]
public class ItemSprite : ScriptableObject
{
    public string nombreGadget;
    public int priceGarget;
    public Sprite imageGadget;
}
