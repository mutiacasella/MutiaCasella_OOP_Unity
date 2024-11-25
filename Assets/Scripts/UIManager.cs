using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Text healthText;
    [SerializeField] private Text pointsText;
    [SerializeField] private Text waveText;
    [SerializeField] private Text enemiesLeftText;

    private int currentPoints = 0;
    public int EnemiesRemaining { get; private set; } 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateHealth(int health)
    {
        Debug.Log("UpdateHealth dipanggil dengan nilai: " + health);
        healthText.text = "Health: " + health;
    }

    public void UpdatePoints(int enemyLevel, int enemiesKilled)
    {
        currentPoints += enemyLevel * enemiesKilled;
        pointsText.text = "Points: " + currentPoints;
    }

    public void UpdateWave(int wave)
    {
        waveText.text = "Wave: " + wave;
    }

    public void UpdateEnemiesRemaining(int enemies)
    {
        EnemiesRemaining = enemies;
        enemiesLeftText.text = "Enemies Left: " + enemies;
    }
}