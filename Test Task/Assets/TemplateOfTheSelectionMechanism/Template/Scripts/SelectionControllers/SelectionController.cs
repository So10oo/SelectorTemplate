using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace SelectionTemplate
{
    public abstract class SelectionController<TData> : MonoBehaviour where TData : BaseData
    {
        [SerializeField] AssetReferenceBaseData[] _datas;
        public Action<TData> OnSelectedDataChanged;
        protected SelectedDataView<TData> _selectedDataView;
        AsyncOperationHandle<TData> _currentDataAsyncOperationHandle;
        int _currentIndex = 0;

        public virtual void AwakeMonoBehaviour()
        {
            _selectedDataView = GetComponentInChildren<SelectedDataView<TData>>();
        }

        public virtual void StartMonoBehaviour()
        {
            SetCurrentData(_currentIndex);
        }

        public void NextData()
        {
            _currentIndex = AddCyclicCurrentIndexDatas(1);
            SetCurrentData(_currentIndex);
        }
        public void PreviousData()
        {
            _currentIndex = AddCyclicCurrentIndexDatas(-1);
            SetCurrentData(_currentIndex);
        }
        void SetCurrentData(int index)
        {
            if (!_currentDataAsyncOperationHandle.IsDone)
                return;

            if (_currentDataAsyncOperationHandle.IsValid())
            {
                //Debug.Log($"Release {_currentDataAsyncOperationHandle.Result.name}");
                Addressables.Release(_currentDataAsyncOperationHandle);
            }

            _currentDataAsyncOperationHandle = _datas[index].LoadAssetAsync<TData>();
            _currentDataAsyncOperationHandle.Completed += (handle) =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    _selectedDataView?.ViewData(handle.Result);
                    OnSelectedDataChanged?.Invoke(handle.Result);
                    //Debug.Log($"LoadCompleted {_currentDataAsyncOperationHandle.Result.name}");
                    //Debug.Log($"{_currentDataAsyncOperationHandle.Result.name}.GetInstanceID : {_currentDataAsyncOperationHandle.Result.GetInstanceID()}");
                    //Debug.Log($"{_datas[index].SubObjectName}.GetInstanceID(Asset) : {_datas[index].Asset.GetInstanceID()}");
                }
            };

        }
        int AddCyclicCurrentIndexDatas(int added)
        {
            int currentIndex = GetCurrentIndexDatas();
            return currentIndex.AddCyclic(added, _datas.Length);
        }
        int GetCurrentIndexDatas()
        {
            return _currentIndex;
            //if (_currentDataAsyncOperationHandle.IsValid())
            //{
            //    var data = _datas.First<AssetReferenceBaseData>((x) => x.Asset.GetInstanceID() == _currentDataAsyncOperationHandle.Result.GetInstanceID());
            //    return Array.IndexOf(_datas, data);
            //}
            //else
            //{
            //    return 0;
            //}
        }

        public virtual void OnDisableMonoBehaviour()
        {
        }
        public virtual void OnEnableMonoBehaviour()
        {
        }
        private void OnDisable()
        {
            OnDisableMonoBehaviour();
        }
        private void OnEnable()
        {
            OnEnableMonoBehaviour();
        }
        private void Awake()
        {
            AwakeMonoBehaviour();
        }
        private void Start()
        {
            StartMonoBehaviour();
        }
    }
}