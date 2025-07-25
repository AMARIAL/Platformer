using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState: byte {Menu, Levels, Game, Pause, GameOver}
public class GameManager : MonoBehaviour
{
    [SerializeField] private int lives;
    public static GameManager ST  {get; private set;}
    public int levelNum;
    public GameState currentState;

    private TextMeshProUGUI livesNum;
    private void Awake()
    {
        
        ST = this;
        if (SceneManager.GetActiveScene().name.Contains('-') && 
            int.TryParse(SceneManager.GetActiveScene().name.Split('-')[1], out levelNum))
        {
            currentState = GameState.Game;
            Audio.ST.PlayMusic(Music.game);
        }
    }
    private void Start()
    {
        livesNum = GameObject.Find("Lives").GetComponent<TextMeshProUGUI>();
        livesNum.text = lives.ToString();

        DoPause(false);
    }
    public void ChangeLives(bool flag = false)
    {
        if (flag)
            lives++;
        else if(lives > 0)
            lives--;
        
        livesNum.text = lives.ToString();
    }
    public void DoPause(bool flag = true)
    {
        if (flag)
        {
            Time.timeScale = 0;
            currentState = GameState.Pause;
        }
        else
        {
            Time.timeScale = 1;
            currentState = GameState.Game;
        }
    }
    
}
