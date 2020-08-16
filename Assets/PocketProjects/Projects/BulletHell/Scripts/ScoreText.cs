using TMPro;
using UnityEngine;

namespace PocketProjects.BulletHell
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreText : MonoBehaviour
    {
        private TextMeshProUGUI textField;

        private void Start()
        {
            textField = GetComponent<TextMeshProUGUI>();

            SetTextField();
        }

        private void SetTextField()
        {
            int score = PlayerPrefs.GetInt("BulletHellScore", 0);
            int highScore = PlayerPrefs.GetInt("BulletHellHighScore", 0);

            textField.text = $"Score: {score}\nHigh Score: {highScore}";
        }
    }
}
