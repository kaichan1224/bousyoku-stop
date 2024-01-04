using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TNRD;

[CreateAssetMenu(fileName = "ShotMaster", menuName = "Data/ShotMaster")]
public class ShotMasterData : ScriptableObject
{
    public List<DictPair<InGameEnum.ShotAlgo, SerializableInterface<IShotStrategy>>> datas;
    public IShotStrategy GetData(InGameEnum.ShotAlgo name)
    {
        foreach (var data in datas)
        {
            if (data.IsEquelKey(name))
            {
                return data.Value.Value;
            }
        }
        return null;
    }
}
