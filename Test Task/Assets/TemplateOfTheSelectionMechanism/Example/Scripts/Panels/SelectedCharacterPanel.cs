using UnityEngine.AddressableAssets;

namespace SelectionTemplate.Example
{
    public class SelectedCharacterPanel : LoadingSelectedPanel<CharacterData>
    {
        protected override void OnSetData(CharacterData data)
        {
            panelStateMachine.container.containerData.CharacterData = data;
        }

        protected override void ReleaseCurrentData(ContainerData containerData)
        {
            if (containerData.CharacterData != null)
                Addressables.Release(containerData.CharacterData);
        }
    }
}

