using System;
using UnityEngine;
using System;

namespace MemorySequence.Gameplay {
    public class ClickHandler {
        public event Action onClicked;

        public bool IsClickedAt(SequenceButton sequenceButton) {
            if (!Input.GetMouseButtonDown(0)) {
                return false;
            }

            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast(clickPosition, Vector3.zero);

            if (hit2d == false) {
                return false;
            } else if (hit2d.transform.GetComponent<SequenceButton>() == null) {
                return false;
            } else if (hit2d.transform.GetComponent<SequenceButton>() != sequenceButton) {
                return false;
            }

            onClicked?.Invoke();
            return true;
        }
    }
}