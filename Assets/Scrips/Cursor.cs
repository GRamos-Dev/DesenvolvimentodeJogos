using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D crosshairTexture;  // atribua a textura da crosshair no Inspector
    public Vector2 hotSpot = Vector2.zero; // ponto "quente" do cursor (geralmente o centro da crosshair)
    public CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        Cursor.SetCursor(crosshairTexture, hotSpot, cursorMode);
    }
}
