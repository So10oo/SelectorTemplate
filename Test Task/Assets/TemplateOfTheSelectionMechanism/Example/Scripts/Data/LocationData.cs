using UnityEngine;

namespace SelectionTemplate.Example
{
    [CreateAssetMenu(fileName = "LocationData", menuName = "ScriptableObjects/LocationData")]
    public class LocationData : BaseData
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public string Description { get; private set; }

        public override string ToString() => $"LocationData: Name-{Name}; IconName-{Icon.name}; Id-{Id}; Description-{Description};";

    }
}


