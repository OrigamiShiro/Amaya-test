using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Amaya
{
    public class CardCreator
    {
        public CardData CreateSingle(string bundleDataPath, Transform parent)
        {
            var cardBundle = ResourceLoader.Load<CardBundleData>(bundleDataPath);
            var card = CreateCard(cardBundle, parent);
            return card;
        }

        public CardData CreateSingle(CardBundleData cardBundleData, Transform parent) => CreateCard(cardBundleData, parent);
       
        private CardData CreateCard(CardBundleData data, Transform parent)
        {
            var card = CardData.GetInstance(parent);
            card.SetData(data);
            return card;
        }
    }
}
