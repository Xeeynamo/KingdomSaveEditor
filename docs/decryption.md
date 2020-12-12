# Save game decryption

Before using a save with Kingdom Save Editor, you need to extract the save or decrypt it. Every console has their own different way of decrypting the saves.

## PlayStation 2

For a real console, you might want to use uLaunchELF. Find the best way to launch homebrews to your console and then use uLaunchELF to copy the saves from the memory card to a USB Drive. Once you're happy with your changes, you can use the same homebrew to transfer the file back.

For PCSX2, you need to specify to the emulator you want to use the virtual memory card as a folder. Go to `Config\Memory cards`. Select the memory card you want to use as a folder and then click the button `Convert`. Do not worry, your saves will continue to function as always as a folder converted memory card. Now locate the memory card's content from that MemoryCard Manager window and you will find a bunch of folders that will look like as `BASLES`, `BISLPS` etc. . One of them is the save of the game you wish to modify.

## PlayStation 3

For a real PS3, copy the save to a USB drive and decrypt them using `BruteForce Savedata`. I realize it is a very complicated tool to use as it's not clear when saves are actually decrypted or not. If the save is supported but Kingdom Save Editor complains about the unsupported save, it means it is not decrypted. The fastest way might be searching a tutorial on YouTube.

The emulator RPCS3 loads and saves decrypted save games by default.

## PlayStation 4

There are two known way to decrypt and encrypt back a save.

1) [Playstation 4 Save Mounter](https://github.com/ChendoChap/Playstation-4-Save-Mounter): If you have a PS4 with a HEN or Custom Firmware, you may want to use [this fast and free tool](https://github.com/ChendoChap/Playstation-4-Save-Mounter)

2) [Save Wizard](https://www.savewizard.net/): If you do not have a custom firmware, you can obtain a copy of a decrypted save and re-encrypt it using [the following paid software](https://www.savewizard.net/)

Once you modify the save, you need to encrypt it back with ideally the same tool you used for the decryption.

## PlayStation 5

You can still decrypt PlayStation 4 titles running on PlayStation 5 by copying them on a USB drive and using Save Wizard. But there are currently no known ways to do it on PlayStation 5 titles.

## PlayStation Portable

If you are using PPSSPP, save files are encrypted by default. To decrypt them, go to `File\Open Memory Stick` then navigate to `PSP/SYSTEM`. You will find a file called `ppsspp.ini`. Open it and search for `EncryptSave`. You should see a line equal to `EncryptSave = True`. Change it to `EncryptSave = False`, save and restart the emulator.

For a real PSP, all saves prior to 6.xx firmware are decrypted. But for the next firmwares you need a tool to decrypt them. I recommend to still use PPSSPP to use your PSP files and decrypt them from there.

## Nintendo 3DS

If you are using the emulator Citra, saves are already decrypted. Just go to `File\Open Citra Folder` then navigate to `sdmc/Nintendo 3DS/00000000000000000000000000000000/00000000000000000000000000000000/title` to find and modify your save.

With a physical Nintendo 3DS, saves are encrypted by default. I recommend to follow [this guide](https://gbatemp.net/threads/extract-and-decrypt-games-nand-backups-and-sd-contents-with-ninfs.499994/) to do it.
