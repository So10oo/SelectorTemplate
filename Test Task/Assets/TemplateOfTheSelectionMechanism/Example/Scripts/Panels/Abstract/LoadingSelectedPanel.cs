using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SelectionTemplate.Example
{
    public abstract class LoadingSelectedPanel<TData> : Panel where TData : BaseData
    {
        [SerializeField] protected SelectionController<TData> selectionController;

        protected PanelStateMachine panelStateMachine;

        public override void Initialization(PanelStateMachine panelStateMachine)
        {
            this.panelStateMachine = panelStateMachine;
            ReleaseCurrentData(panelStateMachine.container.containerData);
        }

        protected abstract void ReleaseCurrentData(ContainerData containerData);
        //{
        //    var properties = containerData.GetType().GetProperties();
        //    foreach (var property in properties)
        //    {
        //        if (property.PropertyType == typeof(TData) && property.CanWrite)
        //        {
        //            var value = property.GetValue(containerData);
        //            Addressables.Release((TData)value);
        //            return;
        //        }
        //    }
        //}

        protected abstract void OnSetData(TData data);

        public void SetMainPanel()
        {
            panelStateMachine.SetMainPanel();
        }

        public override void Enter()
        {
            base.Enter();
            selectionController.OnSelectedDataChanged += OnSetData;
        }

        public override void Exit()
        {
            base.Exit();
            selectionController.OnSelectedDataChanged -= OnSetData;
            gameObject.SetActive(false);
            Addressables.ReleaseInstance(gameObject);
        }
    }
}