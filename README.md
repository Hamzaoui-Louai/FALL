# FALL!

**FALL** is a game inspired by the old Nokia game *Rapid Roll*, but with a little bit of spice and powerups.

Built with **Unity 6000.3.22f1** using the **URP 2D** pipeline. The project lives in [`FALL/`](FALL/).

## Getting started

1. Install **Unity 6000.3.22f1** via [Unity Hub](https://unity.com/download) (do not open the project with any other version).
2. Open Unity Hub → **Add project from disk** → select the `FALL/` folder.
3. Wait for the editor to import; check the **Console** for compile errors.

## Reinstalling packages

Package versions are tracked in `FALL/Packages/manifest.json`, while the downloaded copies live in the ignored `FALL/Library/PackageCache/`. If packages are missing or broken:

- **Normal case:** just opening the project in Unity 6000.3.22f1 automatically resolves and re-downloads everything from `manifest.json`.
- **If that fails:** close the editor completely (never delete `Library/` while it runs), then delete the `FALL/Library/` folder and reopen the project. Unity will regenerate it and restore all packages.
- Packages can also be managed manually via **Window → Package Manager** in the editor.
