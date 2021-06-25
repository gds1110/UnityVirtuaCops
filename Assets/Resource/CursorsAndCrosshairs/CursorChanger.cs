using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour {

    public Texture2D cursor;
    public Texture2D cursorArrow;

	// Use this for initialization
	void Start () {
        Cursor.SetCursor(cursor, new Vector2(0, 0), CursorMode.Auto);
	}

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }


}
