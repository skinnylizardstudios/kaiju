using UnityEngine;
using System.Collections.Generic;

public struct EarthGolemPerkCard
{
    public enum CardType { Strength, Fortitude, Agility, Resonance, Majesty, Regeneration, Shatter, Gravity, Petrify, Quake }

    public string CardName;
    public CardType Type;
    public string Description;
    public float DamageBonus;
}

public static class EarthGolemPerkDeck
{
    private static readonly EarthGolemPerkCard[] AllCards = new[]
    {
        new EarthGolemPerkCard { CardName = "Titanfist", Type = EarthGolemPerkCard.CardType.Strength, Description = "+30% Damage, +25% Fist Size", DamageBonus = 0.30f },
        new EarthGolemPerkCard { CardName = "Stoneform", Type = EarthGolemPerkCard.CardType.Fortitude, Description = "+35% Defense", DamageBonus = 0.0f },
        new EarthGolemPerkCard { CardName = "Windstride", Type = EarthGolemPerkCard.CardType.Agility, Description = "+25% Speed", DamageBonus = 0.0f },
        new EarthGolemPerkCard { CardName = "Tremor", Type = EarthGolemPerkCard.CardType.Resonance, Description = "Earthquake Power x1.5", DamageBonus = 0.0f },
    };

    public static EarthGolemPerkCard DrawRandomCard()
    {
        return AllCards[Random.Range(0, AllCards.Length)];
    }
}