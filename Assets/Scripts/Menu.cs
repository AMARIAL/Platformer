using UnityEngine;

public class Menu : MonoBehaviour
{
    public static Menu ST  {get; private set;}

    private void Awake()
    {
        ST = this;
    }

    public void MenuButton()
    {
        if(GameManager.ST.currentState != GameState.Game) return;
        
        GameManager.ST.DoPause();
    }

}
