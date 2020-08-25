using TMPro;
using UnityEngine;

namespace PocketProjects
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreText : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private string scorePlayerPref = null;
        [SerializeField] private string highScorePlayerPref = null;

        private TextMeshProUGUI textField;

        private void Start()
        {
            textField = GetComponent<TextMeshProUGUI>();

            SetTextField();
        }

        private void SetTextField()
        {
            int score = PlayerPrefs.GetInt(scorePlayerPref, 0);
            int highScore = PlayerPrefs.GetInt(highScorePlayerPref, 0);

            textField.text = $"Score: {score}\nHigh Score: {highScore}";
        }
    }
}
