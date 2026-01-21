# Earth Golem Complete System v0.0.0.1a

## System Overview

Comprehensive procedural Earth Golem system with **perk cards** (Tarot-like deck), **appearance progression** (every 10 levels), and **procedural gait animation** (level-scaled movement).

## 1. Perk Card System (EarthGolemPerkCard.cs)

### Card Deck (14 Cards Across 10 Types)

**Card Types:**
- **Strength** (Titanfist, Irongrip) - Increased damage & fist size
- **Fortitude** (Stoneform, Bedrock) - Defense & health
- **Agility** (Windstride, Afterimage) - Speed & stride length
- **Resonance** (Tremor) - Ability power & earth effects
- **Majesty** (Colossus) - Presence & intimidation
- **Regeneration** (Earthblood) - Health recovery
- **Shatter** (Rupture) - Destruction power
- **Gravity** (Gravitas) - Weight & knockback
- **Petrify** (Marble) - Maximum defense
- **Quake** (Seismic) - Impact & AOE damage

## 2. Appearance Progression (Every 10 Levels)

| Level | Stage | Fist Girth | Leg Thickness | Muscle | Texture |
|-------|-------|-----------|---------------|---------|----------|
| 1-10 | Young Golem | 1.0x | 1.0x | 0.3 | Smooth |
| 11-20 | Hardened Golem | 1.2x | 1.15x | 0.5 | Rough |
| 21-30 | Mighty Golem | 1.4x | 1.3x | 0.65 | Cracked |
| 31-40 | Colossal Golem | 1.6x | 1.45x | 0.75 | Jagged |
| 41+ | Ancient Golem | 1.8x | 1.6x | 0.85 | Crystalline |

## 3. Procedural Gait System

Level-based gait parameters:
- Walk Speed: Slower at higher levels
- Stride Length: Increases with level
- Arm Swing: Larger swings for bigger creatures
- Body Bob: Decreases (heavier = less bouncy)
- Ground Shake: Increases dramatically with size
- Forward Lean: More pronounced at higher levels

## Completion Status

✅ Scaling system (1m to 1km)
✅ Appearance progression (every 10 levels)
✅ Perk card deck (14 unique cards across 10 types)
✅ Procedural gait (level-scaled movement)
✅ Visual color evolution
✅ Stat bonus system
