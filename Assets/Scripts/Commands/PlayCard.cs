using UnityEngine;
using UnityEngine.UI;

public class PlayCard: Command {

	private GameObject[] gameObjects;
	private GameObject mainGameObject;
	private Player player;
	private int playerIndexCard; 
	public override void Execute(){
		foreach (var obj in gameObjects)
        {
            obj.GetComponent<Button>().interactable = false;
        }
		if(player.GetPlayerType() == Player.PlayerType.NPC){
			playerIndexCard = Random.Range(0, player.GetCardsList().Count);
			player.GetCardsList()[playerIndexCard].SwitchCard(true);
		}
	} 
}
