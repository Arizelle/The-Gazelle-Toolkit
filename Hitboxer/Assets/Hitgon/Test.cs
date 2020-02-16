using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	// public Vector2 offset;
	// public Vector2 size;

	public Vector2 start;
	public Vector2 end;

	BoxCollider2D bCol;

	void Awake()
	{
		bCol = gameObject.GetComponent<BoxCollider2D>();
	}

	void Update()
	{
		// bCol.offset = offset;
		// bCol.size = size;

		bCol.offset = new Vector2(
			(start.x+end.x)/2,
			(start.y+end.y)/2
		);
		bCol.size = new Vector2(
			Mathf.Max(start.x, end.x) - Mathf.Min(start.x, end.x),
			Mathf.Max(start.y, end.y) - Mathf.Min(start.y, end.y)
		);
	}
}
