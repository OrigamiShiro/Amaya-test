using System.Collections.Generic;
using UnityEngine;

namespace Amaya
{
    [CreateAssetMenu(fileName = "New Level Bundle", menuName = "Amaya/Bundles/Level", order = 2)]
    public class LevelBundleData : ScriptableObject
    {
        [SerializeField] private int _columnsCount;
        [SerializeField] private int _rowsCount;
        [SerializeField] private List<CardBundleData> _cards;
        private string _target;

        public int ColumnsCount => _columnsCount;
        public int RowsCount => _rowsCount;
        public int MaxCardsCapacity => _columnsCount * _rowsCount;
        public IReadOnlyCollection<CardBundleData> Cards => _cards;
        public string Target => _target;

        private void Awake()
        {
            _target = RandomTarget();
        }

        private string RandomTarget()
        {
            var randIndex = Random.Range(0, Cards.Count - 1);
            return _cards[randIndex].Key;
        }

    }
}
