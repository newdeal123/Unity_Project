using UnityEngine;
using System.Collections;

public enum MoleState{

    None,
    Open,
    Idle,
    Close,
    Catch

}

public class Hole : MonoBehaviour {

    //두더지들의 상태머신.
    public MoleState MS;

    //이미지들의 묶음.
    public Texture[] Open_Images;
    public Texture[] Idle_Images;
    public Texture[] Close_Images;
    public Texture[] Catch_Images;

    //어떤 두더지인지 체크하기 위한 값.
    public bool GoodMole;
    public int PerGood = 15;

    //이미지들의 묶음.
    public Texture[] Open_Images_2;
    public Texture[] Idle_Images_2;
    public Texture[] Close_Images_2;
    public Texture[] Catch_Images_2;

    //애니메이션 속도를 컨트롤하기 위한 변수.
    public float Ani_Speed;
    public float _now_ani_time;

    int Ani_Count;

    //사운드 플레이용. 
    public AudioClip Open_Sound;
    public AudioClip Catch_Sound;

	//게임매니져에 접근하기 위한 용도의 변수.
	public GameManager GM;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (_now_ani_time >= Ani_Speed)
        {
            if (MS == MoleState.Open)
            {
                Open_Ing();
            }

            if (MS == MoleState.Idle)
            {
                Idle_Ing();
            }

            if (MS == MoleState.Close)
            {
                Close_Ing();
            }

            if (MS == MoleState.Catch)
            {
                Catch_Ing();
            }

            _now_ani_time = 0;
        }
        else
        {
            _now_ani_time += Time.deltaTime;
        }

	}
    
    public void Open_On()
    {
        MS = MoleState.Open;
        Ani_Count = 0;
        audio.clip = Open_Sound;
        audio.Play();

        int a = Random.Range(0, 100);

        if (a <= PerGood)
        {
            GoodMole = true;
        }
        else
        {
            GoodMole = false;
        }

		if(GM.GS == GameState.Ready){
			GM.GO ();
		}
    
    }

    public void Open_Ing()
    {
        if (GoodMole == false)
        {
            renderer.material.mainTexture = Open_Images[Ani_Count];
        }
        else
        {
            renderer.material.mainTexture = Open_Images_2[Ani_Count];
        }



        Ani_Count += 1;

        if (Ani_Count >= Open_Images.Length)
        {
            Idle_On();
        }
    }

    public void Idle_On()
    {
        MS = MoleState.Idle;
        Ani_Count = 0;
    }

    public void Idle_Ing()
    {
        if (GoodMole == false)
        {
            renderer.material.mainTexture = Idle_Images[Ani_Count];
        }
        else
        {
            renderer.material.mainTexture = Idle_Images_2[Ani_Count];
        }

        Ani_Count += 1;

        if (Ani_Count >= Idle_Images.Length)
        {
            Close_On();
        }
    }

    public void Close_On()
    {
        MS = MoleState.Close;
        Ani_Count = 0;
    }

    public void Close_Ing()
    {
        if (GoodMole == false)
        {
            renderer.material.mainTexture = Close_Images[Ani_Count];
        }
        else
        {
            renderer.material.mainTexture = Close_Images_2[Ani_Count];
        }

        Ani_Count += 1;

        if (Ani_Count >= Close_Images.Length)
        {
            StartCoroutine("Wait");
        }
    }

    public void Catch_On()
    {
        MS = MoleState.Catch;
        Ani_Count = 0;
        audio.clip = Catch_Sound;
        audio.Play();

		if(GoodMole==false){
			GM.Count_Bed+=1;
		}
		else
		{
			GM.Count_Good+=1;
		}
    }

    public void Catch_Ing()
    {
        if (GoodMole == false)
        {
            renderer.material.mainTexture = Catch_Images[Ani_Count];
        }
        else
        {
            renderer.material.mainTexture = Catch_Images_2[Ani_Count];
        }
        Ani_Count += 1;

        if (Ani_Count >= Catch_Images.Length)
        {
            StartCoroutine("Wait");
        }
    }

    public IEnumerator Wait()
    {
        MS = MoleState.None;
        Ani_Count = 0;
        float wait_Time = Random.Range(0.5f, 4.5f);
        yield return new WaitForSeconds(wait_Time);
        Open_On();
    }

    public void OnMouseDown()
    {
        if (MS == MoleState.Idle || MS == MoleState.Open)
        {
            Catch_On();
        }
    }

}
