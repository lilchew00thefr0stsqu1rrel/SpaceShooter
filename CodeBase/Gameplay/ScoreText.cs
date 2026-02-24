using TMPro;
using UnityEngine;

namespace SpaceShooter
{
    public class ScoreText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_Text;

        private int lastScoreText;

        private void Update()
        {
            int score = Player.Instance.Score;

            if (lastScoreText != score) 
            {
                m_Text.text = "Score : " + score.ToString();
                lastScoreText = score;
            }
        }
    }
}

