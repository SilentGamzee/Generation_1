using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roll : MonoBehaviour
{

    public List<GameObject> obj_list = new List<GameObject>();
    public List<Sprite> sprite_list = new List<Sprite>();
    public GameObject GameLine;
    public Button roll_button;
    public Sprite ball;
    public GameObject waiter;
    public float StartDelay;

    

    private float t {
        get => t1;
        set
        {
            t1 = value;
            if (value == 0)
                waiter.SetActive(false);
            else
                waiter.SetActive(true);
        }
    }

    public static int items_count = 5;
    public static int r_ball;
    public static GameObject _waiter;
    public static bool _LAUNCH_GAME = false;

    private static Sprite _ball;
    private static List<GameObject> _obj_list;
    private static List<Sprite> _sprite_list;
    private static Sprite LastSprite;

    
    private float t1;

    void Start()
    {
        _ball = ball;
        _obj_list = obj_list;
        _sprite_list = sprite_list;
        _waiter = waiter;

        ShuffleScript.Init(obj_list);
        for (var i = 0; i < obj_list.Count; i++)
        {
            var obj = obj_list[i];
            obj.AddComponent<ImageClickScript>().Init(i);
        }

        items_count = Random.Range(3, 5);
        UpdateImages();

        roll_button.onClick.AddListener(OnRollButton);
    }

    public static void OnGameEnd()
    {
        ShowBall();
    }

    public void OnRollButton()
    {
        if (ShuffleScript.InProgress 
            || PlayerMechanic._LOSE 
            || _LAUNCH_GAME 
            || !ImageClickScript.IsGameEnded) return;
        t = 0;
        PlayerMechanic.ROUND_COUNTER++;
        ShuffleScript.Test_shuffle = false;
        
        items_count = Random.Range(3, 5);
        UpdateImages();
        ShuffleScript.ReturnToStartPoints();
        ShowBall();
        Debug.Log("Roll");
        _LAUNCH_GAME = true;
    }

    private static void ShowBall()
    {
        var ball = _obj_list[r_ball];
        var img = ball.GetComponent<Image>();
        img.sprite = _ball;
    }

    private static void HideBall()
    {
        var ball = _obj_list[r_ball];
        var img = ball.GetComponent<Image>();
        img.sprite = LastSprite;
    }

    private static void UpdateImages()
    {
        r_ball = Random.Range(0, items_count);
        var r = Random.Range(0, _sprite_list.Count - 1);
        LastSprite = _sprite_list[r];

        
        for (var i = 0; i < _obj_list.Count; i++)
        {
            var obj = _obj_list[i];
            if (i >= items_count)
            {
                obj.SetActive(false);
                continue;
            }
            obj.SetActive(true);
            var img = obj.GetComponent<Image>();

            img.sprite = LastSprite;
        }
    }



    void Update()
    {
        if (!_LAUNCH_GAME) return;
        t += Time.deltaTime;
        waiter.transform.Rotate(0, 0, 1.5f, Space.Self);
        if (t < StartDelay) return;
        t = 0;

        HideBall();
        ShuffleScript.Shuffle(ball);
        _LAUNCH_GAME = false;
    }
}
