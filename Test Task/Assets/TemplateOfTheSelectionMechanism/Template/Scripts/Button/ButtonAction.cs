using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SelectionTemplate
{
    [RequireComponent(typeof(Button))]
    public class ButtonAction : MonoBehaviour
    {
        [SerializeField] KeyCode _key;
        [SerializeField] UnityEvent _action;

        private void OnEnable()
        {
            GetComponent<Button>().onClick.AddListener(InvokeAction);
        }

        private void OnDisable()
        {
            GetComponent<Button>().onClick.RemoveListener(InvokeAction);
        }

        void InvokeAction() => _action?.Invoke();

        private void Update()
        {
            if (Input.GetKeyDown(_key))
                InvokeAction();
        }
    }
}
