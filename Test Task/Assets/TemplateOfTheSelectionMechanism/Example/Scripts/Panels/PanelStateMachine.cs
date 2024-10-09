using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace SelectionTemplate.Example
{
    public class PanelStateMachine : MonoBehaviour, IPanelStateMachine
    {
        public Container container;

        Panel mainPanel;
        Panel currentPanel;

        public Action<Panel> ChangePanel;

        private void Awake()
        {
            mainPanel = GetComponentInChildren<Panel>();
            currentPanel = mainPanel;
        }

        public void ChangeState(Panel newPanel)
        {
            currentPanel.Exit();
            currentPanel = newPanel;
            currentPanel.Enter();
            ChangePanel?.Invoke(currentPanel);
        }

        public void ChangeState(string assetReferencePanelString)
        {
            currentPanel.Exit();
            Addressables.InstantiateAsync(assetReferencePanelString, transform).
               Completed += (handle) =>
               {
                   if (handle.Status == AsyncOperationStatus.Succeeded)
                   {
                       var panel = handle.Result.GetComponent<Panel>();
                       currentPanel = panel;
                       panel.Initialization(this);
                       panel.Enter();
                       ChangePanel?.Invoke(currentPanel);
                   }
               };
        }

        public void SetMainPanel()
        {
            ChangeState(mainPanel);
        }
    }
}
