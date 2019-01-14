using UnityEngine;
using System.Collections;

public enum GameState
{
    Ready,
    Play,
    End
}

public class GameManager : MonoBehaviour {

    public GameState GS;                //게임매니져의 상태관리.

    public Hole[] Holes;                //구멍 스크립트들(배열).
    public float LimitTime;             //게임 제한시간.
    public GUIText TimeText;            //게임 제한시간을 표기하기 위한GUIText.

    public int Count_Bed;               //나쁜두더지를 잡은 횟수.
    public int Count_Good;              //착한 두더지를 잡은 횟수.

    public GameObject FinishGUI;        //결과화면을 보여주기 위한 오브젝트.
    public GUIText Final_Count_Bed;     //결과화면에서 나쁜 두더지를 잡은 숫자를 보여 줄 GUIText.
    public GUIText Final_Count_Good;    //결과화면에서 착한 두더지를 잡은 숫자를 보여 줄 GUIText.
    public GUIText Final_Score;         //결과화면에서 착한 두더지를 잡은 숫자를 보여 줄 GUIText.

    public AudioClip ReadySound;        //레디...하는 경우에 플레이 할 사운드.
    public AudioClip GoSound;           //고! 하 는경우에 플레이 할 사운드.
    public AudioClip FinishSound;       //끝나고 결과화면이 나올 경우에 플레이 할 사운드.

    void Start()
    {
        audio.clip = ReadySound;
        audio.Play();
    }

	public void GO(){

		GS= GameState.Play;
		audio.clip = GoSound;
		audio.Play();
	}

    void Update()
    {
        if (GS == GameState.Play)
        {
            LimitTime -= Time.deltaTime;
            if (LimitTime <= 0)
            {
                LimitTime = 0;
				//게임이 끝나는 시점.
				End();

            }
        }
        TimeText.text = string.Format("{0:N2}", LimitTime);
    }

	void End(){

		GS= GameState.End;
		Final_Count_Bed.text = string.Format("{0}",Count_Bed);
		Final_Count_Good.text = string.Format("{0}",Count_Good);
		Final_Score.text = string.Format("{0}",Count_Bed*100-Count_Good*1000);
		FinishGUI.gameObject.SetActive(true);
		audio.clip = FinishSound;
		audio.Play();

	}
}
