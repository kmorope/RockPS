using UnityEngine; 
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
     
    public Button _playButton;

    public Button _settingsButton;

    public Button _historyButton;

    public int _focusedButton = 0;

	float _umbral = 0.5f;

	bool _isListening = true;

	float _cooldownTime = 0.25f;


	// Use this for initialization
	void Start()
	{
		Flip(true,_playButton);
        _focusedButton = 1;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetAxis("JAxisY") > _umbral && _isListening)
		{
            if (_focusedButton < 3)
                _focusedButton++;
			DisableListening();
			Flip(_focusedButton == 1, _playButton);
            Flip(_focusedButton == 2, _settingsButton);
            Flip(_focusedButton == 3, _historyButton);
		}

		if (Input.GetAxis("JAxisY") < (_umbral * -1) && _isListening)
		{
            if (_focusedButton > 1)
                _focusedButton--;
			DisableListening();
			Flip(_focusedButton == 1, _playButton);
			Flip(_focusedButton == 2, _settingsButton);
			Flip(_focusedButton == 3, _historyButton);
		}
	}

	public void Flip(bool open,Button btn)
	{
		var rt = btn.gameObject.GetComponent(typeof(RectTransform)) as RectTransform;
		rt.sizeDelta = open ? new Vector2(280, 280) : new Vector2(200, 200); 
	}

	private void DisableListening()
	{
		_isListening = false;
		Invoke("EnableListening", _cooldownTime);
	}

	private void EnableListening()
	{
		_isListening = true;
	}
}