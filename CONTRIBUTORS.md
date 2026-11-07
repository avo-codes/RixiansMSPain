# Setup

1. Decompile the game with GDRE
2. In your `Directory.Build.props` add `<AssetSourcePath>C:\..\SlayTheSpire2Decompiled</AssetSourcePath>`
3. If you have an existing `.godot/`, delete it.
4. Run build once, or run `./build/link-assets.ps1`
5. Task: BuildMod to build the mod
6. Task: PublishMod to build with assets
