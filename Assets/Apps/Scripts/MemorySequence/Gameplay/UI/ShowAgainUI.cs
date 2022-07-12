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


        private void Awake() {
            showAgainButton = GetComponent<Button>();
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
