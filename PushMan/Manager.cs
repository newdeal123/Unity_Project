using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
	public int Count;			//떨어지는 박스의 갯수 세기.
	public float _time;			//박스가 떨어지기까지 걸리는 시간측정.
	bool End;					//박스가 다 떨어졌는지 체크한다.

	public GUIText Text_time;	//시간 표기를 위한 GUIText.

	public GameObject ClearGUI;
	public GameObject FailGUI;

	void OnTriggerEnter(Collider Get)
	{
				//부딪힌 오브젝트릐 태그가 BOX일 경우 Count증가.
				if (Get.collider.tag == "Box") {
						Count += 1;
				}
				
				//부딪힌 오브젝트의 태그가 Player인 경우 End를 활성화 한다.
				if (Get.collider.tag == "Player" && End== false) {
						End=true;
						FailGUI.SetActive (true);
				}
				
				//Cout가 16보다 커지면 End활성화.
				if (Count >= 16 && End== false) {
						End = true;
						ClearGUI.SetActive (true);
				}
	}
		
	void Update() {
			if(End==false){
				_time+=Time.deltaTime;
			}
		Text_time.text = _time.ToString ();
		}


}
