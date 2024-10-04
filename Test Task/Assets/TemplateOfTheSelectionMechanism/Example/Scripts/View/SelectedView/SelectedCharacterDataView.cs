using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SelectionTemplate.Example
{
    public class SelectedCharacterDataView : SelectedDataView<CharacterData>
    {
        [SerializeField] TextMeshProUGUI _nameView;
        [SerializeField] Image _iconView;
        Character3DModelView _character3DModelView;
        public override void ViewData(CharacterData data)
        {
            if (_nameView == null || _iconView == null || _character3DModelView == null)
                return;

            _nameView.text = $"{data.Name} - {data.Level}";
            _iconView.sprite = data.Icon;
            _character3DModelView?.ViewData(data.Avatar);
        }
        public void SetupCharacter3DModelView(Character3DModelView character3DModelView)
        {
            _character3DModelView = character3DModelView;
        }
    }
}
