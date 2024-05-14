# Game Launcher
 Mel's game launcher



<img src="Assets/gamelauncher.png" style="zoom:50%;" />

## Installation

1. Download the [latest release](https://github.com/Melodi17/GameLauncher/releases/latest) `GameLauncher.exe` file
   or build it yourself.
2. Place the executable somewhere convenient.
3. Run it, if you haven't set up the IGDB credentials, a prompt will appear, these are used to grab game metadata, you can go [here](https://api-docs.igdb.com/#getting-started:~:text=NOW%2C%20IT%27S%20FREE!-,Account%20Creation,usage%20under%20the%20terms%20of%20the%20Twitch%20Developer%20Service%20Agreement.,-Note%3A%20We) to get instructions on how to do this.
4. You're done! You may want to go to settings and change the scan dir to your games folder.
5. You can add games with right click > add game manually, then select the game's executable, and then the folder it is located in, in the second dialog.
6. Enjoy! Please report any issues in the issues tab and make suggestions there.



## About

Silly little project I decided to make for fun.

### Notable Features

- Automatic game metadata fetching, including game cover image and description
- Discord RPC support, if turned on, will show the games you are playing through it on your profile
- Dark mode, so it doesn't hurt your eyes
- Cool icon (took me ages)



## FAQ

**My game is showing incorrect details, such as name and image**

You can override it in the game details screen by clicking the ... on a game, then clicking the dropdown and override metadata.



**A game isn't showing up**

Make sure the game is inside the folder you have set as the scan dir (it cannot detect outside this), and that you have tried adding it manually.



**How do I update it?**

From version 1.5.0 and above, you can automatically update in settings using the "Check for updates" button, alternatively you can download and replace the executable manually from the GitHub.



**Where does it store its data?**

All the the applications data is stored under `%UserProfile%/GameLauncher`, you may copy this between computers to copy configs, but note that it does contain your IGDB credentials. Games data is stored inside the game folder, in the `gl.resources` folder and the `launch.dat` file.



**Can I add multiple start profiles?**

Yes! You can edit the `launch.dat` file in the game's folder with another line with your profile name and the executable you want it to search for: `windowed version=GameW.exe`




## To-do

- [ ] Improve game automatic detection for launch file
- [ ] Play time counter
- [ ] Save file management and quick swapping
- [ ] Possibly add game source providing
- [ ] Note unrecognized games
- [ ] Add splash screen
- [ ] Add start profile management inside app



## Versions

### Beta 1.5.2

- Fixed updater compatibility always detecting update
- Removed themes and made dark the new default
- Major UI refresh

### Beta 1.5.1

- Fixed auto-updating to use GitHub API
- Improved dark mode
- Added compatibility mode for updating

### Beta 1.5.0

- Added auto-updating
- Added custom metadata override
- Added game name matching

### Beta 1.4.8

- Added uninstall and forget buttons
- Fixed search query to exclude DLCs and updates
- Added keyboard enter in search box trigger search

### Older versions

- Fixed workingdir issue causing some games to start
- Added offline mode
- Added folder select when scan dir is inaccessible
- Scan dir now configurable
- Added metadata overriding
- Increased IGDB database reliability
- File restructure
- Progress bar moved out of the way
- Fixed crash when refreshing metadata in detail view
- Added settings
- Added bad themes (WIP)
- Added IGDB setup screen
- Discord RPC support
- External game process attachment
- Manually add games
- Rate limiting protection
- New icon (from nothing)