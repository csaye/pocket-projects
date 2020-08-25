using TMPro;
using UnityEngine;

namespace PocketProjects
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class Score : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private float scoreSpeed = 0;
        [SerializeField] private string scorePlayerPref = null;
        [SerializeField] private string highScorePlayerPref = null;

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
                lastScoreTime = Time.time;
                IncrementScore();
            }
        }

        private void IncrementScore()
        {
            score++;

            PlayerPrefs.SetInt(scorePlayerPref, score);

            // Set new high score if necessary
            if (score > PlayerPrefs.GetInt(highScorePlayerPref, 0))
            {
                PlayerPrefs.SetInt(highScorePlayerPref, score);
            }

            UpdateTextField();
        }

        private void UpdateTextField()
        {
            textField.text = $"Score: {score}";
        }
    }
}
