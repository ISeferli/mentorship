# Ubisoft Mentorship Project

This project is based on the challenge “The more you have, the worse it gets.” for Develop At Ubisoft mentorship program of 2026. It is 3D isometric rogue-like game where the player gains new abilities, while the difficulty of encounters increases as the run progresses.

---

## Tech Stack

- **Unity Version**: Unity 6.2
- **Language**: C#
- **Render Pipeline**: URP

---

## Gameplay

The player progresses through levels, gaining elemental abilities that increase both power and challenge.

---

## Features

- **Player Movement & Combat**: Move with **A/W/S/D**, dash with **Shift**, attack with **mouse buttons**. Player mechanics scripts are in the `Character` folder that contains `Character.cs`, `CharacterAttack.cs` and `CharacterMovement.cs`.

- **Player Stats**: Player stats are defined in the scriptable object `Stats/BaseStat`.

- **Sword Weapon Logic**: The `Weapon/SwordWeapon.cs` script handles sword collisions and applies damage to enemies on contact. 

- **Enemy AI**: Basic State Machine with states Roaming, Chasing, Attacking, Taking Damage, Death. Scripts are in `Enemy` folder. `EnemyAI` contains the State Machine mechanics and connects the enemy with the other functions in `EnemyMovement.cs` and `EnemyAttack.cs`. The latter contains the logic behind character damage.

- **Cinemachine Camera**: In `Level` folder, `LevelCamera.cs` manages the camera for each level, setting the camera to follow the player dynamically.

- **Level Transitions**: Custom enemy waves per level.  
  - `Level/LevelDifficulty.cs` (scriptable object) defines difficulty.  
  - `Game/LevelDifficultyManager.cs` manages level difficulty.  
  - `Level/LevelTransition.cs` handles scene transitions triggered by `Portals/Portal.cs`.

- **Game Manager**: A Singleton in `Game/GameManager.cs` that tracks the current run and level progress.

- **Enemy Spawning**: System `Game/EnemySpawner.cs` to handle enemy spawning in specific range of area in the specific level until the maximum wave is reached.

- **Elemental System**: In `Abilities/Attack`, two different type of elemental attack damage are implemented.

- **UI Elements**: Health, stamina, menus, and upgrade panels handled in `GameUI` folder. 

- **Upgrade System**:  
  - Upgrade panel after each level wave on `Upgrade/UI/UpgradePanel.cs`.  
  - **Decorator Pattern** allows dynamic ability upgrades. Each ability upgrade that uses this pattern exists in `Abilities/` folder.  
  - **Factory Pattern** manages ability integration while assigning each ability from the UI panel to the character instance.  

---

## How to Play

### Unity
1. Download the `.zip` file from the release section  
2. Extract all files
3. Import it in Unity
4. Start from `MainMenu` scene.

> Note: Assets used in development are included in `.gitignore`.

### EXE File
1. Run the **.exe** file  
2. Use:
   - **A**, **W**, **S**, **D** – Character movement
   - **Shift** - Character Dash
   - **Left Mouse Button** – Left sword attack
   - **Right Mouse Button** – Right sword attack
   - **Esc** – Pause Game

---

## License
This project is for **portfolio purposes** only.  
Not intended for commercial distribution.

---

## Author
**Iliodora Seferli**  
Portfolio: [*Link of Project Code* ](https://github.com/ISeferli/mentorship.git)

  - [*Contact Me* ](mailto:iliodorasef@gmail.com)
  - [*LinkedIn*](https://www.linkedin.com/in/iliodora-seferli-926ab8187)