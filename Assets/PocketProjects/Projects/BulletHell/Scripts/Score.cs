using TMPro;
using UnityEngine;

namespace PocketProjects.BulletHell
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class Score : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private float scoreSpeed = 0;

        private TextMeshProUGUI textField;

        private float lastScoreTime;

        private int score;

        private void Start()
        {
            textField = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            if (Time.time - lastScoreTime > scoreSpeed)
            {
                IncrementScore();
            }
        }

        private void IncrementScore()
        {
            score++;

            PlayerPrefs.SetInt("BulletHellScore", score);

            if (score > PlayerPrefs.GetInt("BulletHellHighScore", 0))
            {
                PlayerPrefs.
            }

            UpdateTextField();
        }

        private void UpdateTextField()
        {
            textField.text = $"Score: {score}";
        }
    }
}
