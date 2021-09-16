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
* Support for most features of client entities and render controllers

### Projects developed using Bedrock.NET

* [Area 51](https://www.minecraft.net/en-us/pdp?id=7c9e20e6-0727-4a9e-af69-e6a45dd750b5) by Shapescape
* [Block Pets](https://www.minecraft.net/en-us/pdp?id=ba40b96b-c88f-48b4-9305-1a1f0793de0f) by Starfish Studios
* [Craftable Furniture](https://www.minecraft.net/en-us/pdp?id=11007ba6-5170-4650-a191-ac1747d203ae) by Shapescape
* [Demolition 2: Space](https://www.minecraft.net/en-us/pdp?id=2c3b8df9-de5c-4fe9-9c8c-8c54699231c5) by Shapescape
* [Race Day](https://www.minecraft.net/en-us/pdp?id=b6097693-e9e4-4df2-a5e1-c9d9d40f1ba0) by Shapescape
* [Weapons Unlimited](https://www.minecraft.net/en-us/pdp?id=a0fec85a-3949-49c5-9045-336de22756e4) by Starfish Studios
* Upcoming project by Shapescape
* Upcoming project by Starfish Studios
* Upcoming project by Tsunami Studios

## Quick Start

1. Create a new solution in Visual Studio
2. Add this repo as a git submodule in the directory of the solution. (`git submodule add https://github.com/sudo-sandwich/Bedrock.NET.git path/to/place`)
3. Any new projects you create will need to add Bedrock.NET as a reference.

## Recreating the Player Behavior

As an example to get started, here is how you can recreate the vanilla player behavior and client entity in Bedrock.NET.

```csharp
// Create a new, empty entity and initialize the server and client files
Entity player = new Entity("minecraft", "player");
player.CreateServer();
player.CreateClient();

player.Server.IsSpawnable = false;
player.Server.IsSummonable = false;

// Create vanilla events.
EntityEvent gainBadOmen = player.Server.CreateEvent("minecraft:gain_bad_omen");
EntityEvent clearAddBadOmen = player.Server.CreateEvent("minecraft:clear_add_bad_omen");
EntityEvent triggerRaid = player.Server.CreateEvent("minecraft:trigger_raid");
EntityEvent removeRaidTrigger = player.Server.CreateEvent("minecraft:remove_raid_trigger");

// Create vanilla component groups.
ComponentGroup addBadOmen = player.Server.CreateComponentGroup("minecraft:add_bad_omen", new SpellEffects() { AddEffects = { new SpellEffectsAdd() { Effect = "bad_omen", Duration = 6000, DisplayOnScreenAnimation = true } } }, new Timer() { Time = 0, Looping = false, TimeDownEvent = clearAddBadOmen });
ComponentGroup clearBadOmenSpellEffect = player.Server.CreateComponentGroup("minecraft:clear_bad_omen_spell_effect", new SpellEffects());
ComponentGroup raidTrigger = player.Server.CreateComponentGroup("minecraft:raid_trigger", new RaidTrigger() { Event = removeRaidTrigger, Target = "self" });

// Assign component groups to events.
gainBadOmen.ComponentsToAdd.Add(addBadOmen);
clearAddBadOmen.ComponentsToAdd.Add(clearBadOmenSpellEffect);
clearAddBadOmen.ComponentsToRemove.Add(addBadOmen);
triggerRaid.ComponentsToAdd.Add(raidTrigger);
removeRaidTrigger.ComponentsToRemove.Add(raidTrigger);

// Add main components.
player.Server.MainComponents.Add(
	new ExperienceReward() { OnDeath = "Math.Min(query.player_level * 7, 100)" },
	new TypeFamily() { Families = { "player", Constants.ApplyEffectFamily } },
	new IsHiddenWhenInvisible(),
	new Loot() { Table = "loot_tables/empty.json" },
	new CollisionBox() { Width = 0.6, Height = 1.8 },
	new CanClimb(),
	new Movement() { Value = 0.1 },
	new HurtOnCondition() { DamageConditions = { new DamageCondition(new FilterGroup(Group.AllOf, new InLava(Subject.Self, Test.Equal, true)), "lava", 4) } },
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
	new Rideable() { SeatCount = 2, FamilyTypes = { "parrot_tame" }, PullInEntities = true, Seats = { new RideableSeat(0.4, -0.2, -0.1) { MinRiderCount = 0, MaxRiderCount = 0, LockRiderRotation = 0 }, new RideableSeat(-0.4, -0.2, -0.1) { MinRiderCount = 1, MaxRiderCount = 2, LockRiderRotation = 0 } } },
	new ScaffoldingClimber(),
	new EnvironmentSensor() { Triggers = { new EnvironmentTrigger(new FilterGroup(Group.AllOf, new HasMobEffect(Subject.Self, Test.Equal, "bad_omen"), new IsInVillage(Subject.Self, Test.Equal, true)), triggerRaid.Name) } }
);

// Basically just add a ton of stuff to the client entity.
player.Client.AddMaterial(new Material("default", "entity_alphatest"));
player.Client.AddMaterial(new Material("cape", "entity_alphatest"));
player.Client.AddMaterial(new Material("animated", "player_animated"));
player.Client.AddTexture(new Texture("default", "textures/entity/steve"));
player.Client.AddTexture(new Texture("cape", "textures/entity/cape_invisible"));
player.Client.AddGeometry(new Geometry("default", "geometry.humanoid.custom"));
player.Client.AddGeometry(new Geometry("cape", "geometry.cape"));
player.Client.GeometryScale = 0.9375;
player.Client.InitializeScripts.AddRange(new string[] {
	"variable.is_holding_right = 0.0;",
	"variable.is_blinking = 0.0;",
	"variable.last_blink_time = 0.0;",
	"variable.hand_bob = 0.0;"
});
player.Client.PreAnimationScripts.AddRange(new string[] {
	"variable.helmet_layer_visible = 1.0;",
	"variable.leg_layer_visible = 1.0;",
	"variable.boot_layer_visible = 1.0;",
	"variable.chest_layer_visible = 1.0;",
	"variable.attack_body_rot_y = Math.sin(360*Math.sqrt(variable.attack_time)) * 5.0;",
	"variable.tcos0 = (math.cos(query.modified_distance_moved * 38.17) * query.modified_move_speed / variable.gliding_speed_value) * 57.3;",
	"variable.first_person_rotation_factor = math.sin((1 - variable.attack_time) * 180.0);",
	"variable.hand_bob = query.life_time < 0.01 ? 0.0 : variable.hand_bob + ((query.is_on_ground && query.is_alive ? math.clamp(math.sqrt(math.pow(query.position_delta(0), 2.0) + math.pow(query.position_delta(2), 2.0)), 0.0, 0.1) : 0.0) - variable.hand_bob) * 0.02;",
	"variable.map_angle = math.clamp(1 - variable.player_x_rotation / 45.1, 0.0, 1.0);",
	"variable.item_use_normalized = query.main_hand_item_use_duration / query.main_hand_item_max_duration;"
});
player.Client.AddRootAnimation(new ExistingAnimation("root", "controller.animation.player.root"));
player.Client.Animations.Add(new ExistingAnimation("base_controller", "controller.animation.player.base"));
player.Client.Animations.Add(new ExistingAnimation("hudplayer", "controller.animation.player.hudplayer"));
player.Client.Animations.Add(new ExistingAnimation("humanoid_base_pose", "animation.humanoid.base_pose"));
player.Client.Animations.Add(new ExistingAnimation("look_at_target", "controller.animation.humanoid.look_at_target"));
player.Client.Animations.Add(new ExistingAnimation("look_at_target_ui", "animation.player.look_at_target.ui"));
player.Client.Animations.Add(new ExistingAnimation("look_at_target_default", "animation.humanoid.look_at_target.default"));
player.Client.Animations.Add(new ExistingAnimation("look_at_target_gliding", "animation.humanoid.look_at_target.gliding"));
player.Client.Animations.Add(new ExistingAnimation("look_at_target_swimming", "animation.humanoid.look_at_target.swimming"));
player.Client.Animations.Add(new ExistingAnimation("look_at_target_inverted", "animation.player.look_at_target.inverted"));
player.Client.Animations.Add(new ExistingAnimation("cape", "animation.player.cape"));
player.Client.Animations.Add(new ExistingAnimation("move.arms", "animation.player.move.arms"));
player.Client.Animations.Add(new ExistingAnimation("move.legs", "animation.player.move.legs"));
player.Client.Animations.Add(new ExistingAnimation("swimming", "animation.player.swim"));
player.Client.Animations.Add(new ExistingAnimation("swimming.legs", "animation.player.swim.legs"));
player.Client.Animations.Add(new ExistingAnimation("riding.arms", "animation.player.riding.arms"));
player.Client.Animations.Add(new ExistingAnimation("riding.legs", "animation.player.riding.legs"));
player.Client.Animations.Add(new ExistingAnimation("holding", "animation.player.holding"));
player.Client.Animations.Add(new ExistingAnimation("brandish_spear", "animation.humanoid.brandish_spear"));
player.Client.Animations.Add(new ExistingAnimation("holding_spyglass", "animation.humanoid.holding_spyglass"));
player.Client.Animations.Add(new ExistingAnimation("charging", "animation.humanoid.charging"));
player.Client.Animations.Add(new ExistingAnimation("attack.positions", "animation.player.attack.positions"));
player.Client.Animations.Add(new ExistingAnimation("attack.rotations", "animation.player.attack.rotations"));
player.Client.Animations.Add(new ExistingAnimation("sneaking", "animation.player.sneaking"));
player.Client.Animations.Add(new ExistingAnimation("bob", "animation.player.bob"));
player.Client.Animations.Add(new ExistingAnimation("damage_nearby_mobs", "animation.humanoid.damage_nearby_mobs"));
player.Client.Animations.Add(new ExistingAnimation("bow_and_arrow", "animation.humanoid.bow_and_arrow"));
player.Client.Animations.Add(new ExistingAnimation("use_item_progress", "animation.humanoid.use_item_progress"));
player.Client.Animations.Add(new ExistingAnimation("skeleton_attack", "animation.skeleton.attack"));
player.Client.Animations.Add(new ExistingAnimation("sleeping", "animation.player.sleeping"));
player.Client.Animations.Add(new ExistingAnimation("first_person_base_pose", "animation.player.first_person.base_pose"));
player.Client.Animations.Add(new ExistingAnimation("first_person_empty_hand", "animation.player.first_person.empty_hand"));
player.Client.Animations.Add(new ExistingAnimation("first_person_swap_item", "animation.player.first_person.swap_item"));
player.Client.Animations.Add(new ExistingAnimation("first_person_attack_controller", "controller.animation.player.first_person_attack"));
player.Client.Animations.Add(new ExistingAnimation("first_person_attack_rotation", "animation.player.first_person.attack_rotation"));
player.Client.Animations.Add(new ExistingAnimation("first_person_vr_attack_rotation", "animation.player.first_person.vr_attack_rotation"));
player.Client.Animations.Add(new ExistingAnimation("first_person_walk", "animation.player.first_person.walk"));
player.Client.Animations.Add(new ExistingAnimation("first_person_map_controller", "controller.animation.player.first_person_map"));
player.Client.Animations.Add(new ExistingAnimation("first_person_map_hold", "animation.player.first_person.map_hold"));
player.Client.Animations.Add(new ExistingAnimation("first_person_map_hold_attack", "animation.player.first_person.map_hold_attack"));
player.Client.Animations.Add(new ExistingAnimation("first_person_map_hold_off_hand", "animation.player.first_person.map_hold_off_hand"));
player.Client.Animations.Add(new ExistingAnimation("first_person_map_hold_main_hand", "animation.player.first_person.map_hold_main_hand"));
player.Client.Animations.Add(new ExistingAnimation("first_person_crossbow_equipped", "animation.player.first_person.crossbow_equipped"));
player.Client.Animations.Add(new ExistingAnimation("third_person_crossbow_equipped", "animation.player.crossbow_equipped"));
player.Client.Animations.Add(new ExistingAnimation("third_person_bow_equipped", "animation.player.bow_equipped"));
player.Client.Animations.Add(new ExistingAnimation("crossbow_hold", "animation.player.crossbow_hold"));
player.Client.Animations.Add(new ExistingAnimation("crossbow_controller", "controller.animation.player.crossbow"));
player.Client.Animations.Add(new ExistingAnimation("shield_block_main_hand", "animation.player.shield_block_main_hand"));
player.Client.Animations.Add(new ExistingAnimation("shield_block_off_hand", "animation.player.shield_block_off_hand"));
player.Client.Animations.Add(new ExistingAnimation("blink", "controller.animation.persona.blink"));
player.Client.RenderControllers.Add(new ExistingRenderController("controller.render.player.first_person"), "variable.is_first_person");
player.Client.RenderControllers.Add(new ExistingRenderController("controller.render.player.third_person"), "!variable.is_first_person && !variable.map_face_icon");
player.Client.RenderControllers.Add(new ExistingRenderController("controller.render.player.map"), "variable.map_face_icon");
player.Client.EnableAttachables = true;

// Create an AddonContent object. AddonContent holds all of files needed for your addon such as behaviors, animations, animation controllers, render controllers, etc..
AddonContent addon = new();
addon.Entities.Add(player);
addon.WriteAll("path/to/behavior_pack", "path/to/resource_pack");
```
