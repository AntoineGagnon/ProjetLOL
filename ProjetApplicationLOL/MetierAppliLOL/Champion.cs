using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;

namespace MetierAppliLOL
{

    public partial class Champion
    {

        public const int NBSPELLS = 5;

        /// <summary>
        /// Champion's name.
        /// </summary>
        public readonly String Name;

        /// <summary>
        /// Champion's surname.
        /// </summary>

        public readonly String Dignity;

        /// <summary>
        /// Champion's rate given by the user.
        /// </summary>
        public int Rating
        {
            get
            {
                return mRating;
            }
            set
            {
                if (value > 0 && value <= 5)
                {
                    mRating = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Rating"));
                }
                else
                {
                    mRating = 0;
                }
            }
        }
        private int mRating;

        /// <summary>
        /// Path to the champion's icon in this assembly. i.e : Aaatrox/Icone.png
        /// </summary>
        public String IconPath { get; private set; }

        /// <summary>
        /// User's opinion on the champion.
        /// </summary>
        public String Opinion = "";

        /// <summary>
        /// Array of the champion's spells.
        /// </summary>
        public readonly Spell[] Spells = new Spell[NBSPELLS];

        /// <summary>
        /// List of the factions the champion belongs to.
        /// </summary>
        public readonly List<Faction> Factions = new List<Faction>();

        /// <summary>
        /// List of the roles of a champion.
        /// </summary>
        public readonly List<Role> Roles = new List<Role>();

        /// <summary>
        /// Name of the different spells keys used to trigger a champion's Spells.
        /// Also used to create the path to a champion's pictures.
        /// </summary>
        String[] SpellKey = new String[] { "_Passive", "Q", "W", "E", "R" };


        public Champion(String name, String dignity, Spell[] spells, Faction[] factions, Role[] roles)
        {
            Name = name;
            Dignity = dignity;
            IconPath = name + "/" + name + ".png";

            if (spells.Length != NBSPELLS)
            {
                return;
            }
            else
            {
                Spells = spells;
            }

            for (int i = 0; i < NBSPELLS; i++)
            {
                Spells[i].IconPath = name + "/" + name + SpellKey[i] + ".png";

            }
            foreach (Faction f in factions)
            {
                Factions.Add(f);
            }

            foreach (Role r in roles)
            {
                Roles.Add(r);
            }

        }

        public static List<Champion> Champions = new List<Champion>{
                        //new Champion(
            //        "","",
            //        new Spell[]{
            //            new Spell("",""),
            //            new Spell("",""),
            //            new Spell("",""),
            //            new Spell("",""),
            //            new Spell("","")},
            //        new Faction[]{},
            //        new Role[]{}),

            new Champion(
                    "Ahri","The Nine-Tailed Fox",
                    new Spell[]{
                        new Spell("Essence Theft","Gains a charge of Essence Theft whenever a spell hits an enemy (max: 3 charges per spell). Upon reaching 9 charges, Ahri's next spell heals her whenever it hits an enemy."),
                        new Spell("Orb of deception","Ahri sends out and pulls back her orb, dealing magic damage on the way out and true damage on the way back.\nDeals 40/65/90/115/140 (+33% Ability Power) magic damage on the way out, and 40/65/90/115/140 (+33% Ability Power) true damage on the way back."),
                        new Spell("Fox-Fire","Ahri releases three fox-fires, that lock onto and attack nearby enemies.\nReleases three fox-fires that lock on to nearby enemies (prioritizes Champions) dealing 40/65/90/115/140 (+40% Ability Power) magic damage.Enemies hit with multiple fox-fires take 30% damage from each additional fox-fire beyond the first, for a maximum of 0 damage to a single enemy."),
                        new Spell("Charm","Ahri blows a kiss that damages and charms an enemy it encounters, causing them to walk harmlessly towards her. Ahri deals additional damage to recently charmed enemies.\nBlows a kiss dealing 60/90/120/150/180 (+35% Ability Power) magic damage and charms an enemy causing them to walk harmlessly towards Ahri for 1/1.25/1.5/1.75/2 second(s).Enemies hit by Charm take 20% more magic damage from Ahri for 6 seconds. Orb of Deception's true damage is also increased by this effect."),
                        new Spell("Spirit Rush","Ahri dashes forward and fires essence bolts, damaging 3 nearby enemies (prioritizes Champions). Spirit Rush can be cast up to three times before going on cooldown.\nNimbly dashes forward firing 3 essence bolts at nearby enemies (prioritizes Champions) dealing 70/110/150 (+30% Ability Power) magic damage. Can be cast up to three times within 10 seconds before going on cooldown.")},
                    new Faction[]{Faction.Ionia},
                    new Role[]{Role.Mage,Role.Assassin}),

                new Champion(
                    "Aatrox","The Darkin Blade",
                    new Spell[]{
                        new Spell("Blood Well","When using an ability that costs Health, Aatrox stores the self-inflicted damage into the Blood Well. Upon taking fatal damage Aatrox extracts the blood from the well and recovers it as health over a brief duration. Additionally, Aatrox gains 1% Attack Speed for every 2% blood that is in the well."),
                        new Spell("Dark Flight","Aatrox takes flight and slams down at a targeted location, dealing damage and knocking up enemies at the center of impact.\nAatrox takes flight and slams down at a targeted location, dealing 70/115/160/205/250 (+60% bonus Attack Damage) physical damage to all nearby enemies and knocking up targets at the center of impact for 1 second."),
                        new Spell("Blood Thirst / Blood Price","While toggled on Aatrox deals bonus damage every third subsequent attack at the expense of his own Health. While toggled off Aatrox restores Health every third subsequent attack.\nWhile toggled off Aatrox benefits from Blood Thirst, while toggled on Blood Price is activated and removes Blood Thirst.\nBlood Thirst: Every third attack, Aatrox restores 20/25/30/35/40 (+25% bonus Attack Damage) Health, increased by 200% when below half Health.\nBlood Price: Every third attack, Aatrox deals 60/95/130/165/200 (+100% bonus Attack Damage) bonus physical damage and loses Health."),
                        new Spell("Blades of Torment","Aatrox unleashes the power of his blade, dealing damage to all enemies hit and slowing them.\nAatrox unleashes the power of his blade, dealing 75/110/145/180/215 (+60% Ability Power) (+60% bonus Attack Damage) Magic Damage to all enemies hit and slowing them by 40% for 1.75/2/2.25/2.5/2.75 seconds."),
                        new Spell("Massacre","Aatrox draws in the blood of his foes, damaging all nearby enemy champions around him and gaining increased Attack Speed and bonus Attack Range for a short duration.\nAatrox draws in the blood of his foes, dealing 200/300/400 (+100% Ability Power) magic damage to all enemy champions around him, increasing his Attack Speed by 40/50/60%, and gaining 175 Attack Range for 12 seconds.")},
                    new Faction[]{Faction.Independent},
                    new Role[]{Role.Fighter,Role.Tank}),

                new Champion(
                    "DrMundo","The Madman of Zaun",
                    new Spell[]{
                        new Spell("Adrenaline Rush","Dr. Mundo regenerates 0.3% of his maximum Health each second. "),
                        new Spell("Infected Cleaver","Dr. Mundo hurls his cleaver, dealing damage equal to a portion of his target's current Health and slowing them for a short time. Dr. Mundo delights in the suffering of others, so he is returned half of the health cost when he successfully lands a cleaver.\nDr. Mundo hurls his cleaver, dealing magic damage equal to 15/18/21/23/25% of the target's current Health (80/130/180/230/280 damage minimum) and slowing them by 40% for 2 seconds.Half of the health cost is refunded if the cleaver hits a target."),
                        new Spell("Burning Agony","Dr. Mundo drains his health to reduce the duration of disables and deal continual damage to nearby enemies.\nToggle: Dr. Mundo deals 35/50/65/80/95 (+20% Ability Power) magic damage to nearby enemies, and reduces the duration of disables on Dr. Mundo by 10/15/20/25/30%."),
                        new Spell("Masochism","Masochism increases Dr. Mundo's Attack Damage by a flat amount for 5 seconds. In addition, Dr. Mundo also gains an additional amount of Attack Damage for each percentage of Health he is missing.\nIncreases Attack Damage by 40/55/70/85/100 for 5 seconds.\nDr. Mundo gains an additional +0.4/0.55/0.7/0.85/1 Attack Damage for each percentage of Health he is missing. "),
                        new Spell("Sadism","Dr. Mundo sacrifices a portion of his Health for increased Movement Speed and drastically increased Health Regeneration.\nDr. Mundo regenerates 40/50/60% of his maximum Health over 12 seconds. Additionally, he gains 15/25/35% Movement Speed. ")},
                    new Faction[]{Faction.Zaun},
                    new Role[]{Role.Fighter,Role.Tank}),

                new Champion(
                    "Teemo","The Swift Scout",
                    new Spell[]{
                        new Spell("Camouflage","If Teemo stands still and takes no actions for a short duration, he becomes stealthed indefinitely.\nAfter leaving stealth, Teemo gains the Element of Surprise, increasing his attack speed by 40% for 3 seconds."),
                        new Spell("Blinding Dart","Obscures an enemy's vision with a powerful venom, dealing damage to the target unit and blinding it for the duration.\nDeals 80/125/170/215/260 (+80% Ability Power) magic damage and blinds the target for 1.5/1.75/2/2.25/2.5 seconds. "),
                        new Spell("Move Quick","Teemo scampers around, passively increasing his movement speed until he is struck by an enemy champion or turret. Teemo can sprint to gain bonus movement speed that isn't stopped by being struck for a short time.\nPassive: Teemo's Movement Speed is increased by 10/14/18/22/26% unless he has been damaged by an enemy champion or turret in the last 5 seconds.\nActive: Teemo sprints, gaining twice his normal bonus for 3 seconds. This bonus is not lost when struck. "),
                        new Spell("Toxic Shot","Each of Teemo's attacks will poison the target, dealing damage on impact and each second after for 4 seconds.\nTeemo's basic attacks poison their target, dealing 10/20/30/40/50 (+30% Ability Power) magical damage upon impact and 6/12/18/24/30 (+10% Ability Power) magical damage each second for 4 seconds."),
                        new Spell("Noxious Trap","Uses a stored mushroom to place a trap that detonates if an enemy steps on it, spreading poison to nearby enemies that slows movement speed by 30/40/50% and deals 200/325/450 (+50% Ability Power) magic damage over 4 seconds. Traps last 10 minutes.\nTeemo forages for a mushroom every 35/31/27 seconds, but he is only big enough to carry 3 at once.")},
                    new Faction[]{Faction.Bandle_City},
                    new Role[]{Role.Marksman,Role.Assassin}),

                new Champion(
                    "Twitch","The Plague Rat ",
                    new Spell[]{
                        new Spell("Deadly Venom","Twitch's basic attacks infect the target, dealing true damage each second."),
                        new Spell("Ambush","Twitch becomes invisible for a short duration, while invisible Twitch gains movement speed. When leaving invisibility twitch gains Attack Speed for a short duration. After 1.25 seconds of not taking damage or after 3 seconds, Twitch turns invisible for 4/5/6/7/8 seconds.\nTwitch gains 20% Movement Speed while invisible and gains 30/40/50/60/70% Attack Speed for 5 seconds after coming out of invisibility."),
                        new Spell("Venom Cask","Twitch hurls a cask of venom that explodes in an area, slowing targets and applying deadly venom to the target.\nTwitch hurls a cask of venom that explodes in an area adding 2 stacks of Deadly Venom and slowing targets by 25/30/35/40/45% for 3 seconds."),
                        new Spell("Contaminate","Twitch wreaks further havoc on poisoned enemies with a blast of his vile diseases.\nDeals 20/35/50/65/80 physical damage plus 15/20/25/30/35 (+20% Ability Power) (+0) per stack of Deadly Venom to all nearby enemies affected by Deadly Venom."),
                        new Spell("Rat-Ta-Tat-Tat","Twitch unleashes the full power of his crossbow, shooting bolts over a great distance that pierce all enemies caught in their path.\nFor 7 seconds Twitch gains 300 Attack Range, 20/28/36 Attack Damage and his basic attacks become piercing bolts that deal 20% less damage to subsequent targets down to a minimum of 40% damage.")},
                    new Faction[]{Faction.Zaun},
                    new Role[]{Role.Marksman,Role.Assassin}),

                new Champion(
                    "Thresh","The Chain Warden",
                    new Spell[]{
                        new Spell("Damnation","Thresh can harvest the souls of enemies that die near him, permanently granting him armor and ability power."),
                        new Spell("Death Sentence","Thresh binds an enemy in chains and pulls them toward him. Activating this ability a second time pulls Thresh to the enemy. Grab an enemy, then pull them to you or leap to them.\nThrows out his scythe, dealing 80/120/160/200/240 (+50% Ability Power) magic damage to the first unit hit and pulling them toward him for 1.5 seconds.\nDeath Sentence's cooldown is reduced by 3 seconds if it strikes an enemy.\nReactivate this ability to pull Thresh to the bound enemy."),
                        new Spell("Dark Passage","Thresh throws out a lantern that shields nearby allied Champions from damage. Allies can click the lantern to dash to Thresh.\nCreate a shielding lantern that an ally can use to dash to you. Throw the Lantern to a point. If an ally near the Lantern clicks it, they pick it up and Thresh pulls both back to him.Additionally, allies who come near it gain a shield lasting 4 seconds that absorbs up to 60/95/130/165/200 (+40% Ability Power) damage. Allies can only receive the shield once per cast."),
                        new Spell("Flay","Thresh's attacks wind up, dealing more damage the longer he waits between attacks.\nWhen activated, Thresh sweeps his chain, knocking all enemies hit in the direction of the blow.\nPassive: Deal magic damage on each hit that builds up when not attacking. This value is equal to total souls collected plus up to 80/110/140/170/200% of Attack Damage, based on the amount of time since his last attack.\nActive: Knock nearby enemies in the direction of your choice. Deals 65/95/125/155/185 (+40% Ability Power) magic damage in a line beginning behind him. Enemies hit are pushed in the direction of the swing, then slowed by 20/25/30/35/40% for 1.5 seconds.Cast forward to push; cast backward to pull."),
                        new Spell("The Box","A prison of walls that slow and deal damage if broken. Trap enemies inside walls that slow and deal damage if broken.\nCreates a prison of spectral walls around himself. Enemy Champions who walk through a wall suffer 250/400/550 (+100% Ability Power) magic damage and are slowed by 99% for 2 seconds, but break that wall. Once one wall is broken, remaining walls deal half damage and apply half slow duration. An enemy cannot be affected by multiple walls simultaneously.")},
                    new Faction[]{Faction.Shadow_Isles},
                    new Role[]{Role.Support,Role.Fighter}),

                new Champion(
                    "Cassiopeia","The Serpent's Embrace",
                    new Spell[]{
                        new Spell("Deadly Cadence","After casting a spell, any subsequent spellcasts will cost 10% less Mana for 5 seconds (effect stacks up to 5 times)."),
                        new Spell("Noxious Blast","Cassiopeia blasts an area with a delayed high damage poison, granting her increased Movement Speed if she hits a champion.\nCassiopeia blasts an area with a delayed high damaging poison, dealing 75/115/155/195/235 (+80% Ability Power) magic damage over 3 seconds and granting her 15/17.5/20/22.5/25% Movement Speed for 3 seconds if she hits a champion."),
                        new Spell("Miasma","Cassiopeia releases a cloud of poison, lightly damaging and slowing any enemy that happens to pass through it.\nCassiopeia releases a growing cloud of poison that lasts for 7 seconds. Any enemy that passes through it is poisoned for 2 seconds, dealing 25/35/45/55/65 (+15% Ability Power) magic damage each second and slowing them by 15/20/25/30/35%. Continual exposure renews this poison."),
                        new Spell("Twin Fang","Cassiopeia lets loose a damaging attack at her target. If the target is poisoned the cooldown of this spell is refreshed.\nCassiopeia deals 50/85/120/155/190 (+55% Ability Power) magic damage to her target. If the target is poisoned then Twin Fang's cooldown is reduced to 0.5 seconds."),
                        new Spell("Petrifying Gaze","Cassiopeia releases a swirl of magical energy from her eyes, stunning any enemies in front of her that are facing her and slowing any others with their back turned.\nCassiopeia deals 200/325/450 (+60% Ability Power) magic damage to all enemies in front of her. Enemies facing her are stunned for 2 seconds while enemies facing away are slowed by 60%.")},
                    new Faction[]{Faction.Shurima_Desert,Faction.Noxus},
                    new Role[]{Role.Mage}),

                new Champion(
                    "Poppy","The Iron Ambassador ",
                    new Spell[]{
                        new Spell("Valiant Fighter","All physical and magic damage dealt to Poppy that exceeds 10% of her current health is reduced by 50%. This does not reduce damage from structures."),
                        new Spell("Devastating Blow","Poppy crushes her opponent, dealing attack damage plus a flat amount and 8% of her target's max health as bonus damage. The bonus damage cannot exceed a threshold based on rank.\nPoppy crushes her opponent, dealing 20/40/60/80/100 (+100% Attack Damage) (+60% Ability Power) plus 8% of her target's maximum health as magic damage. The base plus percent health bonus damage cannot exceed 75/150/225/300/375."),
                        new Spell("Paragon of Demacia","Passive: Upon receiving damage from or dealing damage with a basic attack, Poppy's armor and damage are increased for 5 seconds. This effect can stack 10 times.\nActive: Poppy gains max stacks of Paragon of Demacia and her movement speed is increased for 5 seconds.\nPassive: Upon receiving damage from or dealing damage with a basic attack, Poppy's armor and damage are increased by 1.5/2/2.5/3/3.5 for 5 seconds. This effect can stack 10 times.\nActive: Poppy gains max stacks of Paragon of Demacia and her movement speed is increased by 17/19/21/23/25% for 5 seconds."),
                        new Spell("Heroic Charge","Poppy charges at an enemy and carries them further. The initial impact deals a small amount of damage, and if they collide with terrain, her target will take a high amount of damage and be stunned.\nPoppy charges at an enemy and carries them for a short distance. The initial impact deals 50/75/100/125/150 (+40% Ability Power) magic damage. If they collide with terrain, her target takes 75/125/175/225/275 (+40% Ability Power) magic damage and will be stunned for 1.5 seconds."),
                        new Spell("Diplomatic Immunity","Poppy focuses intently on a single enemy champion, dealing increased damage to them. Poppy is immune to any damage and abilities from enemies other than her target.\nFor 6/7/8 seconds, Poppy is immune to any damage and abilities from enemies other than her target enemy champion.Poppy deals 20/30/40% increased damage to the marked target.")},
                    new Faction[]{Faction.Bandle_City,Faction.Demacia},
                    new Role[]{Role.Fighter,Role.Assassin}),

                new Champion(
                    "Sona","Maven of the Strings ",
                    new Spell[]{
                        new Spell("Power Chord","After casting 3 spells, Sona's next attack deals bonus magic damage in addition to a bonus effect depending on what song Sona is currently playing."),
                        new Spell("Hymn of Valor","Sona plays the Hymn of Valor, granting nearby allied champions bonus Attack Damage and Ability Power. Additionally, casting this ability sends out bolts of sound, dealing magic damage to the nearest two enemy champions or monsters.\nPersistent Aura: Increases the Attack Damage and Ability Power of nearby allied Champions by 4/8/12/16/20.\nActivation: Deals 50/100/150/200/250 (+50% Ability Power) magic damage to the nearest two enemies (prioritizes Champions).\nPower Chord - Staccato: Deals double power chord damage."),
                        new Spell("Aria of Perseverance","Sona plays the Aria of Perseverance, granting nearby allied champions bonus Armor and Magic Resist. Additionally, casting this ability sends out healing melodies, healing Sona and a nearby wounded ally.\nPersistent Aura: Grants nearby allied Champions 6/7/8/9/10 bonus Armor and Magic Resist.\nActivation: Heals Sona and the most wounded nearby allied Champion for 40/55/70/85/100 (+25% Ability Power) and grants 6/7/8/9/10 additional Armor and Magic Resist for 3 seconds.\nPower Chord - Diminuendo: Reduces an enemy's total damage output by 20% (+[0]%) for 3 seconds."),
                        new Spell("Song of Celerity","Sona plays the Song of Celerity, granting nearby allied champions bonus Movement Speed. Additionally, casting this ability energizes nearby allies with a burst of speed.\nPersistent Aura: Grants nearby allied Champions 4/8/12/16/20 bonus Movement Speed.\nActivation: Grants nearby allies 4/6/8/10/12% (+[0]%) Movement Speed for 1.5 seconds.\nPower Chord - Tempo: Slows an enemy by 40% (+[4% Ability Power]%) for 2 seconds."),
                        new Spell("Crescendo","Sona plays her ultimate chord, forcing enemy champions to dance and dealing magic damage to them.\nStrikes an irresistible chord forcing enemy Champions to dance for 1.5 seconds and take 150/250/350 (+50% Ability Power) magic damage.")},
                    new Faction[]{Faction.Demacia,Faction.Ionia},
                    new Role[]{Role.Support,Role.Mage}),

                new Champion(
                    "Lucian","The Purifier",
                    new Spell[]{
                        new Spell("Lightslinger","Whenever Lucian uses an ability, his next attack becomes a double-shot."),
                        new Spell("Piercing Light","Lucian shoots a bolt of piercing light through a target.\nShoots a bolt of piercing light through an enemy unit, damaging enemies in a line for 80/110/140/170/200 (+60/75/90/105/120% Attack Damage) (60/75/90/105/120% of bonus Attack Damage) physical damage. Deals 75% damage to minions."),
                        new Spell("Ardent Blaze","Lucian shoots a missile that explodes in a star shape, marking enemies. Lucian gains Movement Speed for attacking marked enemies.\nFires a shot that explodes upon enemy contact or reaching the end of its path. The explosion deals 60/100/140/180/220 (+90% Ability Power) (+60% bonus Attack Damage) magic damage and marks enemies for 6 seconds.Damaging marked targets grants Lucian 40 Movement Speed for 2 seconds."),
                        new Spell("Relentless Pursuit","Lucian dashes a short distance, removing all slow effects.\nDashes a short distance, removing all slow effects.If Lucian kills an enemy while The Culling is active, the cooldown of Relentless Pursuit is reset."),
                        new Spell("The Culling","Lucian unleashes a torrent of shots from his weapons.\nLucian moves freely while firing rapidly in a single direction for 3 seconds. His shots collide with the first enemy they hit and each do 40/50/60 (+10% Ability Power) (+25% bonus Attack Damage) physical damage. The number of shots scales with his Attack Speed. The Culling does 400% damage to minions.Lucian may use Relentless Pursuit during The Culling.Reactivate The Culling to cancel early.")},
                    new Faction[]{Faction.Demacia},
                    new Role[]{Role.Marksman}),

                new Champion(
                    "Ziggs","The Hexplosives Expert",
                    new Spell[]{
                        new Spell("Short Fuse","Every 12 seconds, Ziggs' next basic attack deals bonus magic damage. This cooldown is reduced whenever Ziggs uses an ability."),
                        new Spell("Bouncing Bomb","Ziggs throws a bouncing bomb that deals magic damage.\nZiggs throws a bouncing bomb that deals 75/120/165/210/255 (+65% Ability Power) magic damage."),
                        new Spell("Satchel Charge","Ziggs flings an explosive charge that detonates after 4 seconds, or when this ability is activated again. The explosion deals magic damage to enemies, knocking them away. Ziggs is also knocked away, but takes no damage.\nZiggs flings an explosive charge that detonates after 4 seconds, or when this ability is activated again. The explosion deals 70/105/140/175/210 (+35% Ability Power) magic damage to enemies, knocking them away.Ziggs is also knocked away, but takes no damage."),
                        new Spell("Hexplosive Minefield","Ziggs scatters proximity mines that detonate on enemy contact, dealing magic damage and slowing.\nZiggs scatters proximity mines that detonate on enemy contact, dealing 40/65/90/115/140 (+30% Ability Power) magic damage. Enemies hit are slowed by 20/25/30/35/40% for 1.5 seconds.Enemies triggering a mine take 40% damage from additional mines. Mines disarm automatically after 10 seconds."),
                        new Spell("Mega Inferno Bomb","Ziggs deploys his ultimate creation, the Mega Inferno Bomb, hurling it an enormous distance. Enemies in the primary blast zone take more damage than those farther away.\nZiggs deploys his ultimate creation, the Mega Inferno Bomb, hurling it an enormous distance. Enemies in the primary blast zone take 250/375/500 (+90% Ability Power) magic damage. Enemies farther away take 80% damage. Minions take double damage.")},
                    new Faction[]{Faction.Bandle_City},
                    new Role[]{Role.Mage}),

                new Champion(
                    "Kennen","The Heart of the Tempest",
                    new Spell[]{
                        new Spell("Mark of the Storm","Kennen's abilities add a Mark of the Storm to its target for 6.25 seconds. Upon receiving 3 Marks of the Storm, an opponent is stunned for 1 second and Kennen gains 25 Energy.\nThe stun has a diminished effect if it occurs again within 7 seconds."),
                        new Spell("Thundering Shuriken","Kennen throws a fast moving shuriken towards a location, causing damage and adding a Mark of the Storm to any opponent that it hits.\nThrows a shuriken that deals 75/115/155/195/235 (+75% Ability Power) magic damage to the first enemy it hits."),
                        new Spell("Electrical Surge","Kennen passively deals extra damage and adds a Mark of the Storm to his target every few attacks, and he can activate this ability to damage and add another Mark of the Storm to targets who are already marked.\nPassive: Every 5 attacks, Kennen deals bonus magic damage equal to 40/50/60/70/80% of his attack damage and adds a Mark of the Storm to his target.\nActive: Sends a surge of electricity through all nearby targets afflicted by Mark of the Storm, dealing 65/95/125/155/185 (+55% Ability Power) magic damage."),
                        new Spell("Lightning Rush","Kennen morphs into a lightning form, enabling him to pass through units. Any enemy unit he runs through takes damage and gets a Mark of the Storm.\nKennen gains 335 movement speed and ignores unit collision for 2 seconds, dealing 85/125/165/205/245 (+60% Ability Power) magic damage to any enemy he passes through.\nAdditionally, Kennen will gain 10/20/30/40/50 Armor and Magic Resist for 4 seconds. Kennen gains 40 Energy the first time he passes through an enemy.Lightning Rush deals half damage to minions."),
                        new Spell("Slicing Maelstrom","Kennen summons a storm that strikes at random nearby enemy champions for magical damage.\nSummons a magical storm that deals 80/145/210 (+40% Ability Power) magic damage to a random enemy champion near Kennen every 0.5/0.4/0.33 seconds. This storm attacks up to 6/10/15 times and cannot hit the same target more than 3 times.")},
                    new Faction[]{Faction.Ionia,Faction.Bandle_City},
                    new Role[]{Role.Mage,Role.Marksman}),

                new Champion(
                    "Kassadin","The Void Walker",
                    new Spell[]{
                        new Spell("Void Stone","Kassadin takes 15% reduced magic damage and ignores unit collision."),
                        new Spell("Null Sphere","Kassadin fires an orb of void energy at a target, dealing damage and interrupting channels. The excess energy forms around himself, granting a temporary shield that absorbs magic damage.\nKassadin fires an orb of void energy at a target enemy, dealing 80/105/130/155/180 (+70% Ability Power) magic damage and interrupting channels.The excess energy forms around himself, granting a shield that absorbs 40/70/100/130/160 (+30% Ability Power) magic damage for 1.5 seconds."),
                        new Spell("Nether Blade","Passive: Kassadin's basic attacks deal bonus magic damage.\nActive: Kassadin's next basic attack deals significant bonus magic damage and restores Mana.\nPassive: Kassadin's basic attacks draw energy from the void, dealing 20 (+10% Ability Power) bonus magic damage.\nActive: Kassadin charges his Nether Blade, causing his next basic attack to deal 40/65/90/115/140 (+60% Ability Power) bonus magic damage and restore 4/5/6/7/8% of his missing Mana (increases to 20/25/30/35/40% against champions)."),
                        new Spell("Force Pulse","Kassadin draws energy from spells cast in his vicinity. Upon charging up, Kassadin can use Force Pulse to damage and slow enemies in a cone in front of him.\nKassadin draws energy from spells cast in his vicinity, gaining a charge whenever a spell is cast near him.Upon reaching 6 charges, Kassadin can use Force Pulse to deal 80/105/130/155/180 (+70% Ability Power) magic damage and slow enemies by 30/35/40/45/50% for 3 seconds in a cone in front of him."),
                        new Spell("Riftwalk","Kassadin teleports to a nearby location dealing damage to nearby enemy units. Multiple Riftwalks in a short period of time cost additional Mana but also deal additional damage.\nKassadin teleports to a nearby location dealing 80/100/120 (+0) magic damage to surrounding enemy units.Each subsequent Riftwalk within the next 12 seconds doubles the Mana cost and deals an additional 40/50/60 (+0) magic damage per stack, stacks up to 4 times.")},
                    new Faction[]{Faction.Void},
                    new Role[]{Role.Assassin,Role.Mage}),

                new Champion(
                    "Rumble","The Mechanized Menace",
                    new Spell[]{
                        new Spell("Junkyard Titan","Every spell Rumble casts gives him Heat.\nWhen he reaches 50% Heat he reaches Danger Zone, granting all his basic abilities bonus effects.\nWhen he reaches 100% heat, he starts Overheating, granting his basic attacks bonus damage, but making him unable to cast spells for a few seconds."),
                        new Spell("Flamespitter","Rumble torches opponents in front of him, dealing magic damage in a cone for 3 seconds. While in Danger Zone this damage is increased.\nRumble torches his opponents, dealing 75/135/195/255/315 (+100% Ability Power) magic damage in a cone over 3 seconds. This spell deals half damage to minions and neutral monsters. Danger Zone Bonus: Deals 50% bonus damage."),
                        new Spell("Scrap Shield","Rumble pulls up a shield, protecting him from damage and granting him a quick burst of speed. While in Danger Zone, the shield strength and speed bonus is increased.\nRumble tosses up a shield for 2 seconds that absorbs 50/80/110/140/170 (+40% Ability Power) damage. Rumble also gains an additional 10/15/20/25/30% Movement Speed for 1 second. Danger Zone Bonus: 50% increase in shield health and Movement Speed."),
                        new Spell("Electro Harpoon","Rumble launches a taser, electrocuting his target with magic damage and slowing their Movement Speed. A second shot can be fired within 3 seconds. While in Danger Zone the damage and slow percentage is increased.\nRumble shoots his opponent with up to 2 tasers, dealing 45/70/95/120/145 (+40% Ability Power) magic damage and applying a stacking slow of 15/20/25/30/35% for 3 seconds. Danger Zone Bonus: Damage and slow percentage increased by 50%.After using this ability you may cast it a second time at no cost within 3 seconds."),
                        new Spell("The Equalizer","Rumble fires off a group of rockets, creating a wall of flames that damages and slows enemies.\nRumble launches a line of rockets that creates a burning trail for 5 seconds. Enemies in the area have their Movement Speed slowed by 35% and take 130/185/240 (+30% Ability Power) magic damage each second.You can control the placement of this attack by clicking and dragging your mouse in a line.")},
                    new Faction[]{Faction.Bandle_City},
                    new Role[]{Role.Fighter,Role.Mage}),

                new Champion(
                    "Nunu","The Yeti Rider",
                    new Spell[]{
                        new Spell("Visionary","Nunu can cast a spell for free after 5 attacks."),
                        new Spell("Consume","Nunu commands the yeti to take a bite out of a target minion or monster, dealing heavy damage to it and healing himself.\nCommands the yeti to bite out of a minion or monster, dealing 400/550/700/850/1000 true damage to the target and healing himself for 70/115/160/205/250 (+75% Ability Power).\nNunu gains bonuses for 120/150/180/210/240 seconds based on what he consumed.\nReptiles: Your attacks and spells deal an additional 1% of your maximum health as magic damage.\nGolems: 10% increased Size and Maximum Health.\nWolves or Wraiths: Killing a unit grants 15% Movement Speed for 3 seconds."),
                        new Spell("Blood Boil","Nunu invigorates himself and an allied unit by heating their blood, increasing their Movement and Attack Speeds.\nThe heat of Nunu and a target ally's blood rises, increasing Movement Speed by 8/9/10/11/12% and Attack Speed by 25/30/35/40/45% for 12 seconds."),
                        new Spell("Ice Blast","Nunu launches a ball of ice at an enemy unit, dealing damage and temporarily slowing their Movement and Attack Speeds.\nNunu launches a ball of ice at an enemy unit, dealing 85/130/175/225/275 (+100% Ability Power) magic damage and slowing their Movement Speed by 20/30/40/50/60% and Attack Speed by 25% for 3 seconds."),
                        new Spell("Absolute Zero","Nunu begins to sap the area of heat, slowing all nearby enemies. When the spell ends, he deals massive damage to all enemies caught in the area.\nNunu begins to sap the area of heat, slowing all nearby enemies. When the spell ends, he deals massive damage to all enemies caught in the area. Nunu saps the area of heat, channeling up to 3 seconds, slowing surrounding enemy units' Movement Speed by 50% and Attack Speed by 25%.Enemies caught in the area when the channel ends receive up to 625/875/1125 (+250% Ability Power) magic damage, depending on how long the spell was channeled.")},
                    new Faction[]{Faction.Freljord},
                    new Role[]{Role.Support,Role.Fighter}),
        };
    }
}
