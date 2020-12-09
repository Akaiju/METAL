using UnityEngine;
using System.Collections;

public class MoveSampleR : MonoBehaviour
{	
	void Start()
	{
		iTween.MoveBy(gameObject, iTween.Hash("x", -45, "easeType", 
			"easeInOutExpo", "loopType", "pingPong", "speed", 20, "delay", 1));
	}
}

