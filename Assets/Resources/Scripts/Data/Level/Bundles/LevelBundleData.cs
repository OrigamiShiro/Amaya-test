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

        public int ColumnsCount => _columnsCount;
        public int RowsCount => _rowsCount;
        public int MaxCardsCapacity => _columnsCount * _rowsCount;
        public IReadOnlyCollection<CardBundleData> Cards => _cards;

    }
}
