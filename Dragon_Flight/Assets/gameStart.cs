using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour
{
    public GameObject scoreDistance;
    public GameObject score;

    //scoreDistance�� static scoreDistance ���
    void Start()
    {

    }

    //Ȱ��ȭ �� ������
    void OnEnable()
    {
        scoreDistance.GetComponent<Text>().text = Timer.scoreDistance.ToString("F0") + "M";
        score.GetComponent<Text>().text = PlayerController.score.ToString("F0") + "M";
    }

    //��ư ������ �¿�Ƽ�� ����
    public void StartGame()
    {
        gameObject.SetActive(false);
        //���� �Ͻ����� ����
        Time.timeScale = 1;
        //distance reset
        Timer.scoreDistance = 0;
        //score reset
        PlayerController.score = 0;
        //���� �� �ٽ� ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}