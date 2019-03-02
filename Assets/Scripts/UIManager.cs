using UnityEngine;
using System.Collections;

/// <summary>
/// UI管理器.
/// </summary>
public class UIManager : MonoBehaviour {
    private MapManager m_MapManager;
    private int pr;
    private CameraFollow m_CameraFollow;

    private GameObject m_StartUI;
    private GameObject m_GameUI;
    private GameObject m_HelpUI;
    private GameObject m_AboutUI;
    //private GameObject m_OpenUI;

    private AudioSource GameAudio;
    private AudioSource StartAudio;
    private AudioSource WalkAudio;
    private AudioSource ButtonAudio;

    private UILabel m_ScoreLabel;
    private UILabel m_GemLabel;
    private UILabel m_GameScoreLabel;
    private UILabel m_GameGemLabel;

    private GameObject m_PlayButton;
    private GameObject m_HelpButton;
    private GameObject m_AboutButton;
    private GameObject m_HBackButton;
    private GameObject m_ABackButton;
    //private GameObject m_SureButton;

    private GameObject m_Left;
    private GameObject m_Right;

    private PlayerController m_PlayerController;

	void Start () {
        m_CameraFollow = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        m_MapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
        pr = m_CameraFollow.pr;

        m_StartUI = GameObject.Find("Start_UI");
        m_GameUI = GameObject.Find("Game_UI");
        m_HelpUI = GameObject.Find("Help_UI");
        m_AboutUI = GameObject.Find("About_UI");
        //m_OpenUI = GameObject.Find("OPen_UI");

        GameAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        StartAudio = GameObject.Find("Camera").GetComponent<AudioSource>();
        WalkAudio = m_GameUI.GetComponent<AudioSource>();
        ButtonAudio = GameObject.Find("Directional Light").GetComponent<AudioSource>();

        m_ScoreLabel = GameObject.Find("Score_Label").GetComponent<UILabel>();
        m_GemLabel = GameObject.Find("Gem_Label").GetComponent<UILabel>();
        m_GameScoreLabel = GameObject.Find("GameScoreLabel").GetComponent<UILabel>();
        m_GameGemLabel = GameObject.Find("GameGemLabel").GetComponent<UILabel>();

        //m_PlayerController = GameObject.Find("cube_battery").GetComponent<PlayerController>();
        Debug.Log(pr + "UI");
        //m_PlayerController = GameObject.Find("cube_books").GetComponent<PlayerController>();
        

        m_HelpButton = GameObject.Find("Label (4)");
        UIEventListener.Get(m_HelpButton).onClick = HelpButtonClick;
        m_PlayButton = GameObject.Find("Label (3)");
        UIEventListener.Get(m_PlayButton).onClick = PlayButtonClick;
        m_AboutButton = GameObject.Find("Label (5)");
        UIEventListener.Get(m_AboutButton).onClick = AboutButtonClick;
        m_HBackButton = GameObject.Find("HBack");
        UIEventListener.Get(m_HBackButton).onClick = BackButtonClick;
        m_ABackButton = GameObject.Find("ABack");
        UIEventListener.Get(m_ABackButton).onClick = BackButtonClick;
        //m_SureButton = GameObject.Find("Sure");
        //UIEventListener.Get(m_SureButton).onClick = SureButtonClick;

        m_Left = GameObject.Find("Left");
        UIEventListener.Get(m_Left).onClick = Left;

        m_Right = GameObject.Find("Right");
        UIEventListener.Get(m_Right).onClick = Right;

        Init();

        m_StartUI.SetActive(true);
        m_GameUI.SetActive(false);
        m_HelpUI.SetActive(false);
        m_AboutUI.SetActive(false);
	}

   

    /// <summary>
    /// 生成Cube
    /// </summary>
    private void CreateCube(int pr)
    {
        Debug.Log(pr);
        if (pr ==1)
        {
            m_PlayerController = GameObject.Find("cube_books").GetComponent<PlayerController>();
        }
        if (pr == 2)
        {
            m_PlayerController = GameObject.Find("cube_battery").GetComponent<PlayerController>();
        }
        if (pr == 3)
        {
            m_PlayerController = GameObject.Find("cube_cake").GetComponent<PlayerController>();
        }
        if (pr == 4)
        {
            m_PlayerController = GameObject.Find("cube_fruit (1)").GetComponent<PlayerController>();
        }
        if (pr == 5)
        {
            m_PlayerController = GameObject.Find("cube_jar").GetComponent<PlayerController>();
        }
        if (pr == 6)
        {
            m_PlayerController = GameObject.Find("cube_mushroom").GetComponent<PlayerController>();
        }
        if (pr == 7)
        {
            m_PlayerController = GameObject.Find("cube_watermelon").GetComponent<PlayerController>();
        }
        if (pr == 8)
        {
            m_PlayerController = GameObject.Find("cube_pilis").GetComponent<PlayerController>();
        }

    }

    private void Init()
    {
        m_ScoreLabel.text = PlayerPrefs.GetInt("score",0) + "";
        m_GemLabel.text = PlayerPrefs.GetInt("gem", 0) + "/100";
        m_GameScoreLabel.text = "0";
        m_GameGemLabel.text = PlayerPrefs.GetInt("gem", 0) + "/100";
    }

    public void UpdateData(int score, int gem)
    {
        m_GemLabel.text = gem + "/100";
        m_GameScoreLabel.text = score.ToString();
        m_GameGemLabel.text = gem + "/100";
    }

    private void PlayButtonClick(GameObject go)
    {
        Debug.Log("游戏开始啦.");
       // m_CameraFollow.PR();
        //m_CameraFollow.Player();
        //m_MapManager.CreateMapItem(0);
        //m_MapManager.CreateCube();
        CreateCube(pr);
        ButtonAudio.Play();
        m_StartUI.SetActive(false);
        m_GameUI.SetActive(true);
        StartAudio.Stop();
        GameAudio.Play();
        m_CameraFollow.startFollow = true;
        m_PlayerController.StartGame();
    }

    private void HelpButtonClick(GameObject go)
    {
        ButtonAudio.Play();
        m_StartUI.SetActive(false);
        m_HelpUI.SetActive(true); 
    }

    private void AboutButtonClick(GameObject go)
    {
        ButtonAudio.Play();
        m_StartUI.SetActive(false);
        m_AboutUI.SetActive(true);
    }

    private void BackButtonClick(GameObject go)
    {
        ButtonAudio.Play();
        m_StartUI.SetActive(true);
        m_AboutUI.SetActive(false);
        m_HelpUI.SetActive(false);
        
        
    }

    /*private void SureButtonClick(GameObject go)
    {
        ButtonAudio.Play();
        m_OpenUI.SetActive(false);
        m_StartUI.SetActive(true);
    }*/

    private void Left(GameObject go)
    {
        WalkAudio.Play();
        m_PlayerController.Left();
    }

    private void Right(GameObject go)
    {
        WalkAudio.Play();
        m_PlayerController.Right();
    }

    public void ResetUI()
    {
        GameAudio.Stop();
        StartAudio.Play();
        m_StartUI.SetActive(true);
        m_GameUI.SetActive(false);
        pr = m_CameraFollow.pr;
        m_GameScoreLabel.text = "0";
        m_ScoreLabel.text = PlayerPrefs.GetInt("score").ToString();
        
    }
}
