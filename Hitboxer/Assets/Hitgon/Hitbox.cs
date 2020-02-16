/*\
	Hitbox.cs is an attempt at making this tool a static class

	void AttackingUpdate()
	{
		switch (curAct)
		{
			case (Action.2B)
			{
				timer += Time.deltaTime;
			//	Hitbox.Simple(bCol, origin, end);

				timer = Hitbox.Simple(timer, bCol, origin, end);
			}
		}
	}

	So the current timer is passed to whichever Hitbox function, along with:
		origin(s), end(s), and if complex then timestamps

	Timestamps are an array of percents of total animation time,
		with the last being the total time in animation
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Hitbox
{
	// Needs to know: collider to use, dimensions, when to change state?
	public static float Draw (float timer, Vector2 actor, BoxCollider2D box, Vector2 origin, Vector2 end, float animTime)
	{

		if (timer == 0f)
			Set(actor, box, origin, end);
		
		timer += Time.deltaTime;
	}

	// another for arrays of one animated box

	// another for multiple boxes, no animation

	// another for multiple boxes with animation


	// then all this again for 3d


	static void Set(Vector2 actor, BoxCollider2D box, Vector2 origin, Vector2 end)
	{
		box.offset = new Vector2(
			actor.x + )
	}
}
