using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSwing : MonoBehaviour
{
	public BoxColliderManager bcm;

	public float busyTime = .5f;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			float[] times = new float[3];
			times[0] = .4f*busyTime;
			times[1] = .6f*busyTime;
			times[2] = busyTime;

			Vector2[] starts = new Vector2[3];
			starts[0] = new Vector2(0,0);
			starts[1] = new Vector2(.5f,-.5f);
			starts[2] = new Vector2(0,0);

			Vector2[] ends = new Vector2[3];
			ends[0] = new Vector2(0,0);
			ends[1] = new Vector2(2,1);
			ends[2] = new Vector2(0,0);

			bcm.AnimateBox(times,starts,ends);
		}
	}
}
