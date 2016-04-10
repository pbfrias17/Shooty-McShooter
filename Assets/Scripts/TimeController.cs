using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {

	private float fdtCopy;

	// Use this for initialization
	void Start () {
		fdtCopy = Time.fixedDeltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(1)) {
			Time.timeScale = .01f;
			Time.fixedDeltaTime = .02f * Time.timeScale;
		} else {
			Time.timeScale = 1;
			Time.fixedDeltaTime = fdtCopy;
		}
	}
}
