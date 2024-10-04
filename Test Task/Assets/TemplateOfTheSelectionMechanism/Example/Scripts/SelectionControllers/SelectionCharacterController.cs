using UnityEngine;

namespace SelectionTemplate.Example
{
    public class SelectionCharacterController : SelectionController<CharacterData>
    {
        [SerializeField] Character3DModelView _character3DModelViewPrefab;

        public override void OnDisableMonoBehaviour()
        {
            base.OnDisableMonoBehaviour();
            if (_character3DModelViewPrefab != null)//при выходе из игры
                Destroy(_character3DModelViewPrefab.gameObject);
        }

        public override void OnEnableMonoBehaviour()
        {
            base.OnEnableMonoBehaviour();
            _character3DModelViewPrefab = Instantiate(_character3DModelViewPrefab);
            (_selectedDataView as SelectedCharacterDataView)?.SetupCharacter3DModelView(_character3DModelViewPrefab);
        }
    }
}