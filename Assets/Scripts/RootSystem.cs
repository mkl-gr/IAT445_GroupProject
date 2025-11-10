using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RootSystem : MonoBehaviour {

    [System.Serializable]
    public class RootSystemStructure
    {
        public List<CuttableRoots> rootsList; // Roots that retreat for as long as the bulb is damaged
        public List<CuttableRoots> oppositeRootsList; // Roots that grow for as long as the bulb is damaged
        public CuttableBulb bulb; // A reference to the bulb itself
    }
    public List<RootSystemStructure> rootsNBulbs = new List<RootSystemStructure>();

    void Start() {
    }        

    void Update() {
    }

    public void RegrowGroup(int bulbID) {
        for (int i = 0; i < rootsNBulbs.Count; i++) {
            if (rootsNBulbs[i].bulb.GetBulbID() == bulbID) {
                foreach (CuttableRoots cuttableRoot in rootsNBulbs[i].rootsList) {
                    cuttableRoot.Relink();
                }
                foreach (CuttableRoots oppRoot in rootsNBulbs[i].oppositeRootsList) {
                    oppRoot.Retreat();
                }
                return;
            }
        }
    }

    public void RetreatGroup(int bulbID) {
        for (int i = 0; i < rootsNBulbs.Count; i++) {
            if (rootsNBulbs[i].bulb.GetBulbID() == bulbID) {
                rootsNBulbs[i].bulb.SetRegrowthTimer();
                foreach (CuttableRoots cuttableRoot in rootsNBulbs[i].rootsList) {
                    cuttableRoot.Retreat();
                }
                foreach (CuttableRoots oppRoot in rootsNBulbs[i].oppositeRootsList) {
                    oppRoot.Relink();
                }
                return;
            }
        }
    }
}
