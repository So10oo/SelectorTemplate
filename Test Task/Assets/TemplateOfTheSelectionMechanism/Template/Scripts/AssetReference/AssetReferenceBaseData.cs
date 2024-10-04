using System;
using UnityEngine.AddressableAssets;

namespace SelectionTemplate
{
    [Serializable]
    public class AssetReferenceBaseData : AssetReferenceT<BaseData>
    {
        public AssetReferenceBaseData(string guid) : base(guid)
        {
        }
    }
}
 
