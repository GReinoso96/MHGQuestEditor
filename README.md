# MHGQuestEditor

A quest editing tool, MHGQuestEditor is a GUI tool that is currently abandoned, it can only load and display some data.

## QuestConverter
The actual in-development command-line tool to convert between MHG's .mib and a plain text JSON.

Currently only supports conversion of .mib to .json and only a few data groups are converted:

* Header Data
* Basic Data
* Supplies
* Rewards
* Script
* Supplies

## Usage

```QuestConverter [input]```

Conversion depends on the input format.

## JSON Data
### Header Data
All "Ptr" variables here will be ignored when regenerating a .mib file.

| Variable | Description |
| - | - |
| monsterHP | HP Group for boss monsters |
| hrp | HRP gained on completion |
| onlineFlag | Unknown purpouse, it's set to a different value for online quests |
| bossSize | Boss base size percentage, default 100 |
| difficulty | Monster difficulty |
| spawnID | Where to spawn, 0: base camp |
| bossSizeClass | Unknown, relates to boss size |
| supplyType | How supplies are delivered |
| supplyMon | Check Supply Types section |
| supplyNum | Check Supply Types section |

### Difficulties
| Value | Description |
| - | - |
| 0 | Low Rank / Village |
| 1 | High Rank |
| 2 | G Rank |
| 3 | Training |

### Supply Types
| Value | Description | supplyMon | supplyNum |
| - | - |
| 0 | Delivered at the start | Unused | Unused |
| 1 | Delivered at Random | Unused | Unused |
| 2 | Slay x Monster n times | Monster to slay | Number of slays |

### Quest Data
This is the block that is mirrored for every quest in lobby.bin.

| Variable | Description |
| - | - |
| Type |  Quest Type |
| questFlags | Quest Flags |
| stars | Visual star rating |
| fee | Zenny fee |
| reward | Zenny reward |
| cartCost | Zenny lost on cart |
| timeLimit | Time limit in ticks (minutes * 1800) |
| locale | Hunting ground |
| unk | Unknown |
| conditions | Quest requirements |
| id | Quest unique ID |
| title | Quest title |
| win | Objective text |
| fail | Fail conditions text |
| description | Quest description text |

### Quest Types
| Value | Description |
| - | - |
| 1 | Hunting Quest |
| 2 | Gathering Quest |
| 9 | Special Quest (Fatalis) |
| 17 | Huntaton Quest (Yian Kut-Ku) |

### Quest Flags
Add the numbers of each flag you want.

| Value | Description |
| - | - |
| 1 | BBQ Festival Quest |
| 2 | Silent Battle |
| 4 | Urgent Music (Event quest only) |
| 8 | Catless Scat Music (Event quest only) |
| 16 | Disables Farcaster |
| 32 | Max Timer on Quest Clear (Huntaton, Elder Dragons) |
| 64 | No Difficulty Roll (Enabled for all offline quests) |
| 128 | No Difficulty Increase when a new boss spawns |

### Locales
| Value | Description |
| - | - |
| 1 | Fortress |
| 2 | Forest and Hills |
| 3 | Desert |
| 4 | Swamp |
| 5 | Volcano |
| 6 | Jungle |
| 7 | Castle Schrade |
| 8 | Battleground |

## Supply Data
Up to 32 item slots

| Variable | Description |
| - | - |
| id | Item ID |
| amount | Amount on this slot |

## Reward Data

| Variable | Description |
| - | - |
| type | Reward Group Type |
| rewards | Array of rewards for this group |

### Reward Types
| Value | Description |
| - | - |
| 32768 | Basic rewards, first entry is always received |
| 1 | Break Chest (Basa, Gravi) or Horns (Gypceros, Blos) |
| 2 | Break a Rathian's head |
| 3 | Break a Rathian's wings |
| 4 | Break a Rathalos's head |
| 5 | Break a Rathalos' wings |
| 10 | Break Kut-Ku's ears (G Wii only) |
| 11-15 | Fatalis Bonus 1-5 |
| 16 | Break Lao's Horn |
| 17 | Break Lao's Head |
| 18 | Break Lao's Back |
| 19 | Break Lao's Right Shoulder |
| 20 | Break Lao's Left Shoulder |
| 21-25 | Deliver x Items (Starts at 0, increases by 5) |
| 36-40 | Crimson Fatalis Bonus 1-5 |
| 242-256 | Slay x number of target monster (Starts at 1, increases by 1) |

### Reward Items

| Variable | Description |
| - | - |
| chance | Chance to get |
| id | Item ID |
| amount | Amount on this slot |

## Script Data
Quest progression code

| Variable | Description |
| - | - |
| opcode | Function |
| arg1-3 | Variables for this function |

### Opcodes
No arg means to leave them at 0

| Value | Description | arg1-3 |
| - | - |
| 27 | At the start of every quest, initiates quest timer and other data | None |
| 2 | Set a monster slaying goal | 1: Monster ID, 2: Amount |
| 4 | Set an item delivery goal | 1: Item ID, 2: Amount |

WIP