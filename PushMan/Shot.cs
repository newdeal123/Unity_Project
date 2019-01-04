using UnityEngine;
using System.Collections;

//보이지않는 레이저 인식 코드.


public class Shot : MonoBehaviour {
	public float Power = 200f;
	public float Range = 10f;

	void Update ()
	{
		Debug.DrawRay (transform.position, this.transform.forward * Range, Color.red);

		//space bar입력되면,
		if (Input.GetKeyDown (KeyCode.Space)) 
				{
						RaycastHit hit;
						//일직선 상의 레이저 발사 충돌값을 받아온다.
						if (Physics.Raycast (transform.position, transform.forward, out hit, Range)) 
						{
								//부딪힌 오브젝트의 tag가 Box이면,
								if (hit.collider.gameObject.tag == "Box") 
								{
										//콘솔창에 메시지를 띄우고, 그 쪽을 향해 바람을 발사.
										Debug.Log (hit.collider.name);
										hit.rigidbody.AddForceAtPosition (transform.forward * Power, hit.point);
								}
						}
				}
	}
		
}
