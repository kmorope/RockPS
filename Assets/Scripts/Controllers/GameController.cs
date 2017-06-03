using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    static public GameController instance;

    int frameCount = 0;
 
    Command playCards = new PlayCard();

    Command evaluateRules = new EvaluateRules();

    Player playerOne = new Player(Player.PlayerType.Human);

    Player playerTwo = new Player(Player.PlayerType.NPC);

    Dictionary<int, Command> commandsList = new Dictionary<int, Command>();

    string playerOneCards = string.Empty;

    string playerTwoCards = string.Empty;

    public enum GameState
    {
        play, replay
    }

    public GameState gameState = GameState.play;

    public int cardsQty = 5;

    void Start()
    {
        playerOne.DealCard(cardsQty);
        playerTwo.DealCard(cardsQty);
        instance = this;
    }

    void Update()
    {
        frameCount++;//Number to Save the frame

        /// Repetir juego
		if (gameState == GameState.replay)
		{
			foreach (var item in commandsList)
			{
                if (item.Key == frameCount)
				{   
					item.Value.Execute();
				}
			}
		}
    }

    public void SaveCommand(Command command)
    {
        commandsList.Add(frameCount, command);
    }

    public void ReplayGame(){
        gameState = GameState.replay;
        frameCount = 0;
    }
}
