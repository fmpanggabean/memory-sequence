using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MemorySequence.Gameplay.UI
{
    public class ResponseChatboxUI : BaseUI
    {
        public Image avatar;
        public GameObject narrationContainer;
        public TMP_Text narrationText;


        private void Start() {
            gameManager.challenge.OnAnswerWrong += ShowWrongAnswer;
            gameManager.challenge.OnChallengeIsDone += ShowRightAnswer;

            narrationContainer.SetActive(false);
        }
        public void ShowWrongAnswer() {
            StartCoroutine( NarrationEnumerator("Wrong Answer") );
        }
        public void ShowRightAnswer() {
            StartCoroutine(NarrationEnumerator("Right Answer"));
        }
        private IEnumerator NarrationEnumerator(string msg) {
            narrationContainer.SetActive(true);
            narrationText.text = msg;
            yield return new WaitForSeconds(1);
            narrationContainer.SetActive(false);
        }
    }
}
