using System.Collections.Generic;

namespace Miltochess {
    public class Song : Synerger
    {
        string name;
        List<int> synergyId = new List<int>();

        public void AddSynergyUnitId(int v)
        {
            synergyId.Add(v);
        }

        public List<int> GetSynergyUnitIdList()
        {
            return synergyId;
        }

        public void SetName(string v)
        {
            name = v;
        }
    }
}