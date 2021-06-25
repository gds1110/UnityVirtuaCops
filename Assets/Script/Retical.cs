using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Retical : MonoBehaviour
{


    [SerializeField]   Texture2D currsorArrow;
    [SerializeField] Texture2D currsorHand;
    public Vector2 hotSpot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;
   

    private void Awake()
    {

    }
    private void Start()
    {
        Cursor.SetCursor(currsorArrow, hotSpot, CursorMode.ForceSoftware);
        
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(currsorHand, hotSpot, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(currsorArrow, hotSpot, CursorMode.ForceSoftware);
    }


    //Texture2D ConvertSpriteToTexture(Sprite sprite)
    //{
    //    try
    //    {
    //        if (sprite.rect.width != sprite.texture.width)
    //        {
    //            Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
    //            Color[] colors = newText.GetPixels();
    //            Color[] newColors = sprite.texture.GetPixels((int)System.Math.Ceiling(sprite.textureRect.x),
    //                                                         (int)System.Math.Ceiling(sprite.textureRect.y),
    //                                                         (int)System.Math.Ceiling(sprite.textureRect.width),
    //                                                         (int)System.Math.Ceiling(sprite.textureRect.height));
    //            Debug.Log(colors.Length + "_" + newColors.Length);
    //            newText.SetPixels(newColors);
    //            newText.Apply();
    //            return newText;
    //        }
    //        else
    //            return sprite.texture;
    //    }
    //    catch
    //    {
    //        return sprite.texture;
    //    }
    //}

}
