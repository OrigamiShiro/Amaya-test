using UnityEngine;

namespace Amaya
{
    [CreateAssetMenu(fileName = "New Card Bundle", menuName = "Amaya/Bundles/Card", order = 1)]
    public class CardBundleData : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private string _key;

        public Sprite Sprite => _sprite;
        public string Key => _key;
    }
}
