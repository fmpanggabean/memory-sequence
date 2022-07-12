using System;
using UnityEngine;

namespace MemorySequence.Gameplay {
    public class SequenceButton : MonoBehaviour {
        //actions
        public event Action<SequenceButton> onClick;

        //component reference
        private Animation animationComponent;
        private AudioSource audioSource;

        private ClickHandler clickHandler;

        private bool isClickable;

        private void Awake() {
            clickHandler = new ClickHandler();
            animationComponent = GetComponent<Animation>();
            audioSource = GetComponent<AudioSource>();

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
            audioSource.Play();
        }

        public void SetAudio(AudioClip clip) {
            audioSource.clip = clip;
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
