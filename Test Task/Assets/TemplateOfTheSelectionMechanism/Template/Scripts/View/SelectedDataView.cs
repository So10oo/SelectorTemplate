using UnityEngine;
namespace SelectionTemplate
{
    public abstract class SelectedDataView<TData> : MonoBehaviour, IView<TData> where TData : BaseData
    {
        public abstract void ViewData(TData data);
    }
}