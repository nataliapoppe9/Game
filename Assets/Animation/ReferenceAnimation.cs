using UnityEngine;
using UnityEngine.Events;

public class ReferenceAnimation : MonoBehaviour
{
    public void OpenMochila()
    {
        CanvasManager.gm.AbrirCerrarMochila();
    }
}
