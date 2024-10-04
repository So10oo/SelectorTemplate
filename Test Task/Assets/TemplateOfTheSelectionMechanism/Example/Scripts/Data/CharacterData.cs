using UnityEngine;

namespace SelectionTemplate.Example
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData")]
    public class CharacterData : BaseData
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public int Level { get; private set; }
        [field: SerializeField] public GameObject Avatar { get; private set; }
        public override string ToString() => $"CharacterData: Name-{Name}; IconName-{Icon.name}; Level-{Level}; AvatarName-{Avatar.name};";
    }
}

