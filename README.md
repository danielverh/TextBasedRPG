# TBRPG GAME (TEXTBASED RPG GAME)
## Structure:
### Items:
#### Weapons:
`RGame\Items\Weapons`
#### Weapons Interface:
`RGame\Items\Weapons\Weapons.cs`
#### Food
`RGame\Items\Food`
#### Food Inteface:
`RGame\Items\Food\Food.cs`
#### Tools
`RGame\Items\Tools`
#### Tools Inteface:
`RGame\Items\Tools\Tools.cs`
### Gameplay:
#### Main game startup:
`RGame\Game.cs`
#### Main player class
`RGame\Player.cs`
#### Console controller:
`RConsole.cs`
### Utilities:
#### Settings controller:
`Utilities\Settings.cs`
#### Questions class:
`Utilities\Question.cs`

## Creating new items

Add new items (food, tools and weapons) in `RGame\Items\[category]`

There are pre-made intefaces. so a new weapons:

```csharp
namespace RPG.RGame.Items.Weapons
{
    public class example : Weapons
    {
        public example()
        {
            Name = "Example Weapon";
        }
        public int Damage
        {
            get; private set;
        }
        public string Name
        {
            get; private set;
        }
        public int Price
        {
            get; private set;
        }
        public int remainingHealth
        {
            get;
            set;
        }
        public int totalHealth
        {
            get; private set;
        }
    }
}
## RConsole class
```csharp
using static RPG.RConsole;
WriteLine("text...");
Write("\nmoreText...:");
string s = ReadLine();

int result = Ask("A question","Option 1", "Option 2", "Option 3");
```
## Settings:

Settings are stored in list in the `%AppData%\RPG\settings.settings` file using a BinaryFormatter and a `[Serializable]` class.

### Hoe gebruik je de Settings API?
Use the key to store and retreive data.

#### Put data
```csharp
Settings settings = new Settings();
ettings.putInt("intKey",123);
settings.putString("stringKey","Your String");
settings.putBool("boolKey",true);
// Don't forget to commit with:
settings.Commit();
```
#### Get data:
```csharp
Settings settings = new Settings();
int i = settings.getInt("intKey");
string s = settings.getString("stringKey");
bool b = settings.getBool("boolKey");
```

## Player
### Player API:

```csharp
Player player = new Player("John Smith");
// Properties:
player.Name; // The players name.
player.Health; // the remaining health max. 100 min. 0 (negative is dead)
player.Strength; // The players bonus on his weapon damage
player.Hunger; // Remaining hunger max 10 min 0 (negative is dead)
player.Money; // Current users amount of money
```
