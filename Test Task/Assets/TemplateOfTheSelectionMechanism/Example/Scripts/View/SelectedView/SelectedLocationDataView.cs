using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SelectionTemplate.Example
{
    public class SelectedLocationDataView : SelectedDataView<LocationData>
    {
        [SerializeField] TextMeshProUGUI _nameView;
        [SerializeField] Image _iconView;
        [SerializeField] TextMeshProUGUI _descriptionView;
        public override void ViewData(LocationData data)
        {
            if (_nameView == null || _iconView == null || _descriptionView == null)
                return;

            _descriptionView.text = data.Description;
            _nameView.text = data.Name;
            _iconView.sprite = data.Icon;
        }
    }
}

