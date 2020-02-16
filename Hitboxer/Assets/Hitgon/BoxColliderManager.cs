/*
	TENTATIVE USAGE GUIDE

	SETUP
		- Attach both this and a BoxCollider2D to the GameObject


/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public struct HitboxAnim
{
	public 
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderManager : MonoBehaviour
{
	BoxCollider2D bCol;
	public float timer = 0f;
	int index = 0;
	float[] times;
	Vector2[] starts;
	Vector2[] ends;
	bool keepBox;

	public float[] testTimes;
	public Vector2[] testStarts;
	public Vector2[] testEnds;

	void Awake()
	{
		bCol = gameObject.GetComponent<BoxCollider2D>();
	}

	void Start()
	{
		//AnimateBox(testTimes, testStarts, testEnds);
	}

//	public void SetCollider(BoxCollider2D _bCol)
//	{
//		bCol = _bCol;
//	}

	public void AnimateBox(float[] _times, float endtime, Vector2[] _starts, Vector2[] _ends)
	{
		float[] _temp = new float[_times.Length+1];
		for (int i = 0; i < _times.Length; i++)
			_temp[i] = _times[i];

		_temp[_temp.Length-1] = endtime;
		AnimateBox(_temp, _starts, _ends);
	}

	public void AnimateBox(float[] _times, Vector2[] _starts, Vector2[] _ends)
	{
		if (_times.Length != _starts.Length || _starts.Length != _ends.Length)
		{
			print ("Collider animation arrays are of differing lengths!");
			return;
		}

		times = new float[_times.Length];
		starts = new Vector2[_starts.Length];
		ends = new Vector2[_ends.Length];

		times = _times;
		starts = _starts;
		ends = _ends;

		SetBox(_starts[0], _ends[0]);

		timer += Time.deltaTime;
	}

	public void AnimateBox(float[] _times, float endtime, Vector2[] _starts, Vector2[] _ends, bool _keepBox)
	{
		keepBox = _keepBox;

		float[] _temp = new float[_times.Length+1];
		for (int i = 0; i < _times.Length; i++)
			_temp[i] = _times[i];

		_temp[_temp.Length-1] = endtime;
		AnimateBox(_temp, _starts, _ends);
	}

	public void AnimateBox(float[] _times, Vector2[] _starts, Vector2[] _ends, bool _keepBox)
	{
		keepBox = _keepBox;

		if (_times.Length != _starts.Length || _starts.Length != _ends.Length)
		{
			print ("Collider animation arrays are of differing lengths!");
			return;
		}

		times = new float[_times.Length];
		starts = new Vector2[_starts.Length];
		ends = new Vector2[_ends.Length];

		times = _times;
		starts = _starts;
		ends = _ends;

		timer += Time.deltaTime;
	}

	void Update()
	{
		if (timer > 0)
		{
			if (timer < times[index])
			{
				timer += Time.deltaTime;
			}
			else 
			{
				index++;

				if (index == times.Length)
				{
					if (!keepBox)
						bCol.size = Vector2.zero;

					timer = 0;
					index = 0;
				}
				else
				{
					SetBox(starts[index], ends[index]);
					timer += Time.deltaTime;
				}
			}
		}
	}

	public void SetBox(Vector2 start, Vector2 end)
	{
		if (bCol == null)
		{
			print ("No BoxCollider2D to shape");
			return;
		}

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
