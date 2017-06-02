using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card:MonoBehaviour
{ 	
	public enum CardTypes
    {
        Piedra = 1,
        Papel = 2,
        Tijera = 3
    }

	private CardTypes _type;

	public Card(CardTypes type)
    {
        _type = type;
    }

    public CardTypes GetCardType()
    {
        return _type;
    }

    public void SwitchCard(bool open){
        var rt = this.gameObject.GetComponent(typeof(RectTransform)) as RectTransform;
        rt.sizeDelta = open ? new Vector2(122, 137) : new Vector2(89, 100);
        var image = this.gameObject.GetComponent(typeof(Image)) as Image; 
        var cardImage = open ? _type.ToString().ToLower() : "giphy";
        image.sprite = Resources.Load("Images/" + _type.ToString().ToLower(), typeof(Sprite)) as Sprite;
    }

    public void SetStatus(bool status){
        this.gameObject.SetActive(status);
    }
}
