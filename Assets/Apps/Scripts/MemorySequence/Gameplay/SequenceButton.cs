using System;
using UnityEngine;

namespace MemorySequence.Gameplay {
    public class SequenceButton : MonoBehaviour {
        //actions
        public event Action<SequenceButton> onClick;

        //component reference
        private Animation animationComponent;

        private ClickHandler clickHandler;

        private bool isClickable;

        private void Awake() {
            clickHandler = new ClickHandler();
            animationComponent = GetComponent<Animation>();

            isClickable = false;
        }

        private void Update() {
            if (clickHandler.IsClickedAt(this) && isClickable) {
                onClick?.Invoke(this);
            }
        }

        internal void SetPosition(Vector3 position) {
            transform.position = position;
        }

        internal void Present() {
            PlayAnimation();
            PlaySound();
        }

        private void PlaySound() {
            //Debug.LogWarning("Not implemented function: PlaySound");
        }

        private void PlayAnimation() {
            animationComponent.Play("SequenceButton@present");
        }

        internal void DisableClick() {
            isClickable = false;
        }

        internal void EnableClick() {
            isClickable = true;
        }
    }
}
