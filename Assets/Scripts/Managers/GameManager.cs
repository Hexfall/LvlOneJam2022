using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                
                var go = new GameObject("GameManager");
                go.AddComponent<GameManager>();

                return _instance;
            }
        }

        private List<NPC> _npcs = new();

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void AddNPC(NPC npc)
        {
            _npcs.Add(npc);
        }
        public void StartApplause(){
            
        }
    }
}
