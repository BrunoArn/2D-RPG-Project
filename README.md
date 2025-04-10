# 2D-RPG-Project

This is a 2D top-down game developed in Unity, primarily focused on exploring and implementing game feel techniques and advanced use of the Unity Editor alongside C# scripting.

The project includes multiple enemy types, bullet hell patterns, and interactable scenery elements. It serves as a learning-focused environment to experiment with responsive gameplay mechanics, efficient editor tooling, and scalable architecture.

## 🚀 Features
- 🔫 Multiple Enemy Types
        Basic movement and chase logic
        Bullet hell-style projectile systems
        Customizable parameters for each enemy via ScriptableObjects or inspector controls

- 🎇 Bullet Hell System
        Modular system to define projectile spread, patterns, timing, and direction
        Parameterized from the Editor for quick iteration

- 🧱 Scenery and Environment Logic
        Interactable objects (e.g., doors, switches, hazards)
        Dynamic effects and feedback
        Editor tooling for positioning, grouping, and controlling behaviors

- 🎮 Game Feel Focus
        Screen shake, hit pause, impact sounds
        Smooth player movement and input buffering
        Feedback-driven interactions

- 🛠️ Editor Tooling
        Custom inspectors and attributes
        Serialized fields for quick tuning
        Organized folder structure and naming conventions


## 📸 Screenshots

![Screenshot](ReadMeImages/1.png)
![Screenshot](ReadMeImages/2.png)
![Screenshot](ReadMeImages/3.png)

## 🎥 Demo

![Demo](ReadMeImages/teste1.gif)

## 🛠️ Tech Stack
- Unity 6 (6000.0.30f1)
- C#
- URP
- GitHub

## Project Structure

Assets/
├── Animation/                  # Animation assets organized by object
│   ├── Bow/
│   ├── Flower/
│   ├── Gold Coin/
│   ├── Grape/
│   ├── NPCs/
│   ├── Player/
│   ├── Slime/
│   ├── Staff/
│   ├── Sword/
│   └── Torch/
├── Material/
│   └── Shaders/               # Custom shaders (if any)
├── Prefabs/                   # Reusable GameObjects
│   ├── Enemies/
│   ├── Environment/
│   ├── PickUps/
│   ├── Scene Management/
│   ├── VFX/
│   └── Weapons/
├── Resources/                 # Assets loaded dynamically via Resources.Load
├── Scenes/
│   ├── Scene_1/
│   └── Scene_2/
├── Scripts/                   # Core and gameplay scripts
│   ├── Enemies/
│   ├── Inventory/
│   ├── Misc/
│   ├── Player/
│   ├── Scene Management/
│   ├── Scriptable Objects/
│   └── Weapons/
├── Settings/
│   └── Scenes/                # Scene settings or configuration assets
├── Sprite/                    # Sprite assets by category
│   ├── Buildings/
│   ├── Enemies/
│   ├── Environment/
│   ├── Inventory UI/
│   ├── Misc/
│   ├── NPC's/
│   ├── Player/
│   └── UI/
├── TextMesh Pro/              # TMP fonts, shaders, and sprites
│   ├── Fonts/
│   ├── Resources/
│   ├── Shaders/
│   └── Sprites/
└── Tilemap/
    └── Tiles/                 # Tile assets for tilemaps


## 📦 Setup

```bash
git clone https://github.com/your-user/your-repo.git
