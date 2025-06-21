using UnityEngine;

public enum GameState: byte {Menu, Levels, Game, Pause, GameOver}
public class GameManager : MonoBehaviour
{
    public static GameManager ST  {get; private set;}
    private void Awake()
    {
        ST = this;
    }
    
    private void Start()
    {
        
    }
}
