using UnityEngine;

namespace SelectionTemplate.Example
{
    public class Container : MonoBehaviour
    {
        [HideInInspector] public ContainerData containerData;
        //[SerializeField] PanelStateMachine panelStateMachine;

        private void Awake()
        {
            containerData = ScriptableObject.CreateInstance<ContainerData>();
            //panelStateMachine.ChangePanel += LogData;
        }

        public void LogData()
        {
            Debug.Log(containerData.ToString());
        }
    }
}
