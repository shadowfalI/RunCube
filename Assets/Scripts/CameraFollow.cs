using UnityEngine;
using System.Collections;

/// <summary>
/// 摄像机跟随角色移动.
/// </summary>
public class CameraFollow : MonoBehaviour {

    private Transform m_Transform;

    private Transform m_player;

    private MapManager m_MapManager;

    private UIManager m_UIManager;

    public int pr;

    public bool startFollow = false;

    private Vector3 normalPos;

   
   

	void Start () {
        m_UIManager = GameObject.Find("UI Root").GetComponent<UIManager>();
        m_MapManager = GameObject.Find("MapManager").GetComponent<MapManager>();

       
        
        m_Transform = gameObject.GetComponent<Transform>();
        normalPos = m_Transform.position;
        //m_player = GameObject.Find("cube_books").GetComponent<Transform>();
        PR();
        Player(pr);

        Debug.Log(pr + "Cam");

	}

    public void PR()
    {
        pr = CalcCubePR();
    }

    /// <summary>
    /// 生成不同Cube的概率
    /// </summary>
    /// <returns></returns>
    public int CalcCubePR()
    {
        int pr1 = Random.Range(1, 100);
        if (0 < pr1 && pr1 <= 10)
        {
            return 1;
        }
        if (10 < pr1 && pr1 <= 20)
        {
            return 2;
        }
        if (20 < pr1 && pr1 <= 30)
        {
            return 3;
        }
        if (30 < pr1 && pr1 <= 40)
        {
            return 4;
        }
        if (40 < pr1 && pr1 <= 50)
        {
            return 5;
        }
        if (50 < pr1 && pr1 <= 60)
        {
            return 6;
        }
        if (60 < pr1 && pr1 <= 70)
        {
            return 7;
        }
        if (70 < pr1 && pr1 <= 80)
        {
            return 8;
        }
        return 1;
    }

    /*public void CreateCube()
    {
       
        GameObject cube = null;
        Vector3 pos = new Vector3(0, 0, 0);
        Vector3 rot = new Vector3(0, 0, 0);
        Debug.Log(pr);
        if (pr == 1)
        {
            cube = GameObject.Instantiate(m_prefab_cube_books, pos, Quaternion.Euler(rot)) as GameObject;
           
            Debug.Log("生成了一个cube_books");
        }
        if (pr == 2)
        {
            cube = GameObject.Instantiate(m_prefab_cube_battery, pos, Quaternion.Euler(rot)) as GameObject;
            
            Debug.Log("生成了一个cube_battery");
        }
        if (pr == 3)
        {
            cube = GameObject.Instantiate(m_prefab_cube_cake, pos, Quaternion.Euler(rot)) as GameObject;
           
            Debug.Log("生成了一个cube_cake");
        }
        if (pr == 4)
        {
            cube = GameObject.Instantiate(m_prefab_cube_fruit, pos, Quaternion.Euler(rot)) as GameObject;
            
            Debug.Log("生成了一个cube_fruit");
        }
        if (pr == 5)
        {
            cube = GameObject.Instantiate(m_prefab_cube_jar, pos, Quaternion.Euler(rot)) as GameObject;
           
            Debug.Log("生成了一个cube_jar");
        }
        if (pr == 6)
        {
            cube = GameObject.Instantiate(m_prefab_cube_mushroom, pos, Quaternion.Euler(rot)) as GameObject;
            
            Debug.Log("生成了一个cube_mushroom");
        }
        if (pr == 7)
        {
            cube = GameObject.Instantiate(m_prefab_cube_watermelon, pos, Quaternion.Euler(rot)) as GameObject;
           
            Debug.Log("生成了一个cube_watermelon");
        }
        if (pr == 8)
        {
            cube = GameObject.Instantiate(m_prefab_cube_pilis, pos, Quaternion.Euler(rot)) as GameObject;
            
            Debug.Log("生成了一个cube_pilis");
        }

    }*/

    public void Player(int pr)
    {
        
       // GameObject cube = null;
        //Vector3 pos = new Vector3(0, 0, 0);
        //Vector3 rot = new Vector3(0, 0, 0);
        Debug.Log(pr);
        if (pr == 1)
        {
            
            //cube = GameObject.Instantiate(m_prefab_cube_books, pos, Quaternion.Euler(rot)) as GameObject;
            m_player = GameObject.Find("cube_books").GetComponent<Transform>();
        }
        if (pr == 2)
        {
            
           // cube = GameObject.Instantiate(m_prefab_cube_battery, pos, Quaternion.Euler(rot)) as GameObject;
            m_player = GameObject.Find("cube_battery").GetComponent<Transform>();
        }
        if (pr == 3)
        {
            
           // cube = GameObject.Instantiate(m_prefab_cube_cake, pos, Quaternion.Euler(rot)) as GameObject;
            m_player = GameObject.Find("cube_cake").GetComponent<Transform>();
        }
        if (pr == 4)
        {
            //cube = GameObject.Instantiate(m_prefab_cube_fruit, pos, Quaternion.Euler(rot)) as GameObject;
            m_player = GameObject.Find("cube_fruit (1)").GetComponent<Transform>();
        }
        if (pr == 5)
        {
            //cube = GameObject.Instantiate(m_prefab_cube_jar, pos, Quaternion.Euler(rot)) as GameObject;
            m_player = GameObject.Find("cube_jar").GetComponent<Transform>();
        }
        if (pr == 6)
        {
            //cube = GameObject.Instantiate(m_prefab_cube_mushroom, pos, Quaternion.Euler(rot)) as GameObject;
            m_player = GameObject.Find("cube_mushroom").GetComponent<Transform>();
        }
        if (pr == 7)
        {
            //cube = GameObject.Instantiate(m_prefab_cube_watermelon, pos, Quaternion.Euler(rot)) as GameObject;
            m_player = GameObject.Find("cube_watermelon").GetComponent<Transform>();
        }
        if (pr == 8)
        {
            //cube = GameObject.Instantiate(m_prefab_cube_pilis, pos, Quaternion.Euler(rot)) as GameObject;
            m_player = GameObject.Find("cube_pilis").GetComponent<Transform>();
        }
    }

	void Update () {
        CameraMove();
	}

    /// <summary>
    /// 摄像机移动.
    /// </summary>
    void CameraMove()
    {
        if (startFollow)
        {
            //摄像机开始跟随.......
            //Player(pr);
            Vector3 nextPos = new Vector3(m_Transform.position.x, m_player.position.y + 1.5f, m_player.position.z);
            //m_Transform.position = nextPos;
            m_Transform.position = Vector3.Lerp(m_Transform.position, nextPos, Time.deltaTime);
        }
    }

    public void ResetCamera()
    {
        m_Transform.position = normalPos;
        PR();
        Debug.Log(pr + "reca");
    }
}
