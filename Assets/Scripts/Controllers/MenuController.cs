using UnityEngine;
using System.Collections; 
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{



    public Button _playButton;

    public Button _settingsButton;

    public Button _historyButton;

	// Use this for initialization
	void Start()
	{
		Flip(true,_playButton);
	}

	// Update is called once per frame
	void Update()
	{
			
	}

	public void Flip(bool open,Button btn)
	{
		var rt = btn.gameObject.GetComponent(typeof(RectTransform)) as RectTransform;
		rt.sizeDelta = open ? new Vector2(280, 280) : new Vector2(200, 200); 
	}
}