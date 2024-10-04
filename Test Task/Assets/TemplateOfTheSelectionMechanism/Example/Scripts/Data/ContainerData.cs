namespace SelectionTemplate.Example
{
    public class ContainerData : BaseData
    {
        public LocationData LocationData { get; set; }
        public CharacterData CharacterData { get; set; }
        public override string ToString() => $"{LocationData}\n{CharacterData}";
    }
}
