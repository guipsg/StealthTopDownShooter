using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour {
	public static Vector3 cursorPos;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		cursorPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		cursorPos.z = 0;
		transform.position = cursorPos;
	}
}
