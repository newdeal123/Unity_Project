using UnityEngine;
using System.Collections;

// 캐릭터의 시점변환을 위한 코드
public class Move : MonoBehaviour {
	public float MoveSpeed;
	Vector3 lookDirection;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode. LeftArrow) ||
		   Input.GetKey (KeyCode. RightArrow) ||
		   Input.GetKey (KeyCode. UpArrow) ||
		   Input.GetKey (KeyCode. DownArrow) )
		{
			//쳐다보는 방향을 정해준다.
			float xx = Input.GetAxisRaw ("Vertical");
			float zz = Input.GetAxisRaw ("Horizontal");
			lookDirection = xx * Vector3.forward + zz* Vector3.right;

			//쳐다본 방향으로 캐릭터를 돌리고, 캐릭터를 앞쪽으로 나아가게 한다.
			this.transform.rotation = Quaternion.LookRotation (lookDirection);
			this.transform.Translate (Vector3.forward * MoveSpeed * Time.deltaTime);
		}
	}
}
