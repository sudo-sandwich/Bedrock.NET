# Bedrock.NET

#### A C# library that automates most aspects of addon creation

Bedrock.NET is a library that automates the generation of behaviors, animations, animation controllers, mcfunctions, and many other types of json needed for a minecraft addon. There are still a few features to be added, but the vast majority of an addon can be created entirely in Bedrock.NET. The ultimate goal for this library is for every aspect of addon creation to be handled in either Bedrock.NET or Blockbench. There is no intention for this library to be able to create models, textures, or resource pack animations.

### Features

* Behaviors
* Behavior pack animations and support for adding pre existing resource pack animations
* Behavior pack and resource pack animation controllers
* Functions and commands
* Blocks (written by hyperbeem)
* Crafting recipes
* Basic support for client entities and render controllers

### Projects developed using Bedrock.NET

* [Area 51](https://www.minecraft.net/en-us/pdp?id=7c9e20e6-0727-4a9e-af69-e6a45dd750b5) by Shapescape
* [Block Pets](https://www.minecraft.net/en-us/pdp?id=ba40b96b-c88f-48b4-9305-1a1f0793de0f) by Starfish Studios
* [Craftable Furniture](https://www.minecraft.net/en-us/pdp?id=11007ba6-5170-4650-a191-ac1747d203ae) by Shapescape
* [Demolition 2: Space](https://www.minecraft.net/en-us/pdp?id=2c3b8df9-de5c-4fe9-9c8c-8c54699231c5) by Shapescape
* [Race Day](https://www.minecraft.net/en-us/pdp?id=b6097693-e9e4-4df2-a5e1-c9d9d40f1ba0) by Shapescape
* Upcoming project by Shapescape
* Upcoming project by Starfish Studios
* Upcoming project by Tsunami Studios

## Quick Start

1. Create a new solution in Visual Studio
2. Add this repo as a git submodule in the directory of the solution. (`git submodule add https://github.com/sudo-sandwich/Bedrock.NET.git path/to/place`)
3. Any new projects you create will need to add Bedrock.NET as a reference.

## Recreating the Player Behavior

As an example to get started, here is how you can recreate the vanilla player behavior in Bedrock.NET.

```csharp
// Create a new, empty entity
Entity player = new("minecraft", "player") {
    IsSpawnable = false,
    IsSummonable = false
};

// Create vanilla events
EntityEvent gainBadOmen = player.CreateEvent("minecraft:gain_bad_omen");
EntityEvent clearAddBadOmen = player.CreateEvent("minecraft:clear_add_bad_omen");
EntityEvent triggerRaid = player.CreateEvent("minecraft:trigger_raid");
EntityEvent removeRaidTrigger = player.CreateEvent("minecraft:remove_raid_trigger");

// Create vanilla component groups and add vanilla components
ComponentGroup addBadOmen = player.CreateComponentGroup("minecraft:add_bad_omen", 
    new SpellEffects() { AddEffects = { new SpellEffectsAdd() { Effect = "bad_omen", Duration = 6000, DisplayOnScreenAnimation = true } } }, 
    new Timer() { Time = 0, Looping = false, TimeDownEvent = clearAddBadOmen });
ComponentGroup clearBadOmenSpellEffect = player.CreateComponentGroup("minecraft:clear_bad_omen_spell_effect", 
    new SpellEffects());
ComponentGroup raidTrigger = player.CreateComponentGroup("minecraft:raid_trigger", 
    new RaidTrigger() { Event = removeRaidTrigger, Target = "self" });

// Set component groups to add and remove
gainBadOmen.ComponentsToAdd.Add(addBadOmen);
clearAddBadOmen.ComponentsToAdd.Add(clearBadOmenSpellEffect);
clearAddBadOmen.ComponentsToRemove.Add(addBadOmen);
triggerRaid.ComponentsToAdd.Add(raidTrigger);
removeRaidTrigger.ComponentsToRemove.Add(raidTrigger);

// Add primary components
player.MainComponents.Add(
    new ExperienceReward() { OnDeath = "Math.Min(query.player_level * 7, 100)" },
    new TypeFamily() { Families = { "player" } },
    new IsHiddenWhenInvisible(),
    new Loot() { Table = "loot_tables/empty.json" },
    new CollisionBox() { Width = 0.6, Height = 1.8 },
    new CanClimb(),
    new Movement() { Value = 0.1 },
    new HurtOnCondition() { DamageConditions = { new DamageCondition(new InLava(Subject.Self, Test.Equal, true), "lava", 4) } },
    new Attack() { Damage = 1 },
    new PlayerSaturation() { Value = 20 },
    new PlayerExhaustion() { Value = 0, Max = 4 },
    new PlayerLevel() { Value = 0, Max = 24791 },
    new PlayerExperience() { Value = 0, Max = 1 },
    new Breathable() { TotalSupply = 15, SuffocateTime = -1, InhaleTime = 3.75, GeneratesBubbles = false },
    new Nameable() { AlwaysShow = true, AllowNameTagRenaming = false },
    new Physics(),
    new Pushable() { IsPushable = false, IsPushableByPiston = true },
    new Insomnia() { DaysUntilInsomnia = 3 },
    new Rideable() { 
        SeatCount = 2, 
        FamilyTypes = { "parrot_tame" }, 
        PullInEntities = true, 
        Seats = { 
            new RideableSeat(0.4, -0.2, -0.1) { MinRiderCount = 0, MaxRiderCount = 0, LockRiderRotation = 0 }, 
            new RideableSeat(-0.4, -0.2, -0.1) { MinRiderCount = 1, MaxRiderCount = 2, LockRiderRotation = 0 } } },
    new ScaffoldingClimber(),
    new EnvironmentSensor() { Triggers = { new EnvironmentTrigger(new FilterGroup(Group.AllOf, new HasMobEffect(Subject.Self, Test.Equal, "bad_omen"), new IsInVillage(Subject.Self, Test.Equal, true)), triggerRaid.Name) } }
);

// Create an AddonContent object. AddonContent holds all of files needed for your addon such as behaviors, animations, animation controllers, render controllers, etc..
AddonContent addon = new();
addon.AddEntities(player);
addon.WriteAll(new DirectoryInfo("path/to/behavior_pack"), new DirectoryInfo("path/to/resource_pack"));
```
