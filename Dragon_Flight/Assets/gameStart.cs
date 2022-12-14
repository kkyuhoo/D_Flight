using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour
{
    public GameObject scoreDistance;
    public GameObject score;

    //scoreDistance에 static scoreDistance 출력
    void Start()
    {

    }

    //활성화 될 때마다
    void OnEnable()
    {
        scoreDistance.GetComponent<Text>().text = Timer.scoreDistance.ToString("F0") + "M";
        score.GetComponent<Text>().text = PlayerController.score.ToString("F0") + "M";
    }

    //버튼 누르면 셋엑티브 폴스
    public void StartGame()
    {
        gameObject.SetActive(false);
        //게임 일시정지 해제
        Time.timeScale = 1;
        //distance reset
        Timer.scoreDistance = 0;
        //score reset
        PlayerController.score = 0;
        //현재 씬 다시 시작
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}