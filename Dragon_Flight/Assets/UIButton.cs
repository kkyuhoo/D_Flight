using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
	public Button Button1;

	void Start()
	{
		Button btn = Button1.GetComponent<Button>();
		btn.onClick.AddListener(Play);
	}

	void Play()
	{
		SceneManager.LoadScene("Play");
	}

}
