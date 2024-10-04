using UnityEngine.AddressableAssets;

namespace SelectionTemplate.Example
{
    public class SelectionLocationPanel : LoadingSelectedPanel<LocationData>
    {
        protected override void OnSetData(LocationData data)
        {
            panelStateMachine.container.containerData.LocationData = data;
        }

        protected override void ReleaseCurrentData(ContainerData containerData)
        {
            if (containerData.LocationData != null)
                Addressables.Release(containerData.LocationData);
            
        }
    }
}
