using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace MemorySequence.Gameplay.UI {
    internal class UIManager : MonoBehaviour, IManager{
        private GameManager gameManager;

        private List<BaseUI> uiCollection;

        private void Awake() {
            gameManager = FindObjectOfType<GameManager>();

            uiCollection = FindObjectsOfType<BaseUI>().ToList();
        }
        private void OnEnable() {
            gameManager.onSequenceStartShowing += GetUI<ShowAgainUI>().DisableButton;
            gameManager.onSequenceEndShowing += GetUI<ShowAgainUI>().EnableButton;
            gameManager.challenge.onAnswerWrong += GetUI<ResponseChatboxUI>().ShowWrongAnswer;
            gameManager.challenge.onChallengeIsDone += GetUI<ResponseChatboxUI>().ShowRightAnswer;
        }
        private void OnDisable() {
            gameManager.onSequenceStartShowing -= GetUI<ShowAgainUI>().DisableButton;
            gameManager.onSequenceEndShowing -= GetUI<ShowAgainUI>().EnableButton;
            gameManager.challenge.onAnswerWrong -= GetUI<ResponseChatboxUI>().ShowWrongAnswer;
            gameManager.challenge.onChallengeIsDone -= GetUI<ResponseChatboxUI>().ShowRightAnswer;
        }
        private void Start() {
            GetUI<ShowAgainUI>().RegisterEventClick(gameManager.ShowSequenceChallenge); ;
        }

        private T GetUI<T>() where T : BaseUI {
            foreach (BaseUI ui in uiCollection) {
                if (typeof(T) == ui.GetType()) {
                    return (T)ui;
                }
            }
            return null;
        }
    }
}