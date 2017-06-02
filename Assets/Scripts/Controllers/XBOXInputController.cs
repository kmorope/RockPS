using UnityEngine;
using System.Collections;

public class XBOXInputController : MonoBehaviour
{
	
    public enum ControlType{
        game,menu
    }

    public ControlType _controlType = ControlType.game;

	private float _umbral = 0.5f;

	private bool _isListening = true;

	private float _cooldownTime = 0.25f;

    // Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
        switch(_controlType){
            case ControlType.game:
				if (Input.GetAxis("JAxisX") > _umbral && _isListening)
				{
					DisableListening();
					Debug.Log(Input.GetButton("JAxisX Positive"));
				}

				if (Input.GetAxis("JAxisX") < (_umbral * -1) && _isListening)
				{
					DisableListening();
					Debug.Log(Input.GetButton("JAxisX Negative"));
				}
                break;
			case ControlType.menu:
                break;
            default:
                break;
        }
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
