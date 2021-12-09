using System.Collections.Generic;

namespace Miltochess {
    public interface Synerger
    {
        void AddSynergyUnitId(int v);
        List<int> GetSynergyUnitIdList();
        void SetName(string v);
    }

}