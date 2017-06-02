using UnityEngine.UI;

public class GUIChange: Command {
    private Player player;
    private Text textGui;
    public GUIChange(Player _player,Text _textgui){
        player = _player;
        textGui = _textgui;
    }
	public override void Execute(){
		textGui.text = player.GetPoints();
	} 
}