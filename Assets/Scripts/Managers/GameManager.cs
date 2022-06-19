using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        private int _collectibleCount = 0;
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

        public void AddCollectible()
        {
            _collectibleCount++;
        }

        public void RemoveCollectible()
        {
            _collectibleCount--;
            if (_collectibleCount <= 0)
                HiderWon();
        }

        public void AddNPC(NPC npc)
        {
            _npcs.Add(npc);
        }
        
        public void StartApplause()
        {
            Debug.Log("Pretend the applause has started.");
        }

        public void SeekerWon()
        {
            Debug.Log("Caught player.");
            _collectibleCount = 0;
            SceneManager.LoadScene("SampleScene");
        }

        public void HiderWon()
        {
            Debug.Log("Hider wins!");
            SceneManager.LoadScene("SampleScene");
        }
    }
}
