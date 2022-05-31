using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventario", menuName = "ListaMochila", order = 1)]
//order da igual. Es a que altura me saldra en el menu en Unity

public class MochilaList : ScriptableObject
{
    public List<MochilaItem> itemList;
   
    public float saldo;
}
