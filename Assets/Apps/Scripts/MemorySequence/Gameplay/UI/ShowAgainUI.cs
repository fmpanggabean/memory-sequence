using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MemorySequence.Gameplay.UI
{
    public class ShowAgainUI : BaseUI
    {
        private Button showAgainButton;


        private new void Awake() {
            base.Awake();
            showAgainButton = GetComponent<Button>();
        }
        private void Start() {
            gameManager.OnSequenceStartShowing += DisableButton;
            gameManager.OnSequenceEndShowing += EnableButton;
            showAgainButton.onClick.AddListener(gameManager.ShowSequenceChallenge);
        }

        internal void RegisterEventClick(Action action) {
            showAgainButton.onClick.AddListener(action.Invoke);
        }

        public void EnableButton() {
            showAgainButton.enabled = true;
        }

        public void DisableButton() {
            showAgainButton.enabled = false;
        }
    }
}
