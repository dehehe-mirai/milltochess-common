using Miltochess;
using NUnit.Framework;

namespace Tests
{
    public class SongTests
    {
        [Test]
        public void HaveSynergyList()
        {
            Synerger synergy = new Song();
            synergy.SetName("synergy");

            synergy.AddSynergyUnitId(1);
            Assert.AreEqual(1, synergy.GetSynergyUnitIdList().Count);
        }
    }
}