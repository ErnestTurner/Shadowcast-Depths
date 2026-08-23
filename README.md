# Shadowcast Depths

**A legacy C# console roguelike built to explore the systems behind turn-based dungeon games.**

Shadowcast Depths is an early programming project preserved as a record of hands-on systems design and growth. Originally developed under the placeholder name `RougeLikeTest`, it now has a title that reflects its defining ideas: shadowcast visibility and a descent through increasingly dangerous dungeon depths. Rather than relying on a game engine, it implements the core roguelike loop directly in C# and renders the dungeon in the Windows console.

## What it demonstrates

- **Turn-based game loop** — coordinates player input, monster turns, regeneration, rendering, and status updates.
- **Pathfinding monster AI** — monsters detect the player, calculate a route through the map, move toward the target, and initiate combat.
- **Recursive-shadowcasting field of view** — scans all eight octants, tracks visible cells, and remembers previously explored areas.
- **Combat and character systems** — models player and monster attributes, melee encounters, health, experience, and level progression.
- **Character creation** — lets the player choose a name and configure starting attributes before entering the dungeon.
- **Procedural map and depth handling** — assembles dungeon features, places monsters and stairs, and generates a new map when the player changes depth.
- **Save/load scaffolding** — serializes player and map state to text, with the load path retained as unfinished legacy work.

## Project context

This repository is intentionally presented as a **legacy project**, not a modern production release. It reflects an earlier stage of development and contains rough edges typical of an exploratory build, including limited documentation, Windows-specific console behavior, and incomplete save/load support.

Those constraints are part of its value: the project shows the underlying implementation work and the evolution from experimentation toward more maintainable software practices.

## Technology

- C#
- .NET Framework 4.5.1
- Visual Studio solution/project files
- Windows console interface

## Running the project

The repository includes `ShadowcastDepths.sln` and targets .NET Framework 4.5.1. For the most faithful setup, open the solution in Visual Studio on Windows and build the `ShadowcastDepths` console application.

Controls shown by the game:

- Arrow keys — move
- `S` — save command (currently disabled in the legacy code)
- `Q` — quit

## Portfolio

See more of my work at [ernest-turner.pages.dev](https://ernest-turner.pages.dev).

