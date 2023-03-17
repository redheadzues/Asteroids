using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.CodeBase.UI
{
    public class GameOverWindow : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private TMP_Text _scoreText;

        public Button RestartButton => _restartButton;

        public void Construct(int score)
        {
            _scoreText.text = "You score: " + score.ToString();
        }
    }
}
