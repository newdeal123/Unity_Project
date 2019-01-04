using UnityEngine;
using System.Collections;

public class SceneMove : MonoBehaviour {
	public string SceneName;

	//마우스가 클릭되었을때.
	public void OnMouseDown() {
		Application.LoadLevel(SceneName);
		}

}
