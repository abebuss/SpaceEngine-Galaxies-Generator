# Galaxy Catalog Generator

## Description
The Galaxy Catalog Generator is a console application that allows users to generate a catalog of galaxies in CSV format. This program is designed for use with SpaceEngine to create large galaxy catalogs.
Generator creates a large 'sphere' that starts generating from the initial distance, stated by the user until all galaxies will be generated.

## Features
- Generate a specified number of galaxies with random attributes.
- Customize the catalog name and initial distance from the sun.
- Save the generated catalog in a user-defined location.
- User-friendly console interface with colorful prompts and messages.

## How to use it
- Download the project and launch the Generator.exe file
- Follow the instructions and you're good to go!
- Example of the program launching:
```
Welcome to the Galaxy Catalog Generator by abebuss!

Please follow the prompts to set everything up.
Enter the name for your catalog (e.g., SEvDSOG): SEvDSOG
Enter the initial distance from the sun (all galaxies would be generated from this distance) (in parsecs): 11000000
Enter the number of galaxies you want to create (the more galaxies you have - the more density of them you will get): 100
Enter the file path for the galaxy catalog (e.g., yourpath\SpaceEngine\addons\catalogs\galaxies\yourfile.csv):  C:\Path\To\Your\Catalog.csv

File has been successfully generated at:  C:\Path\To\Your\Catalog.csv
Thank you for using the Galaxy Catalog Generator! Press any key to exit.
```
## It is recommended to save the .csv file directly into the appropriate SE' mods folder "SpaceEngine\addons\catalogs\galaxies\file name".
# Also make sure you setted up the initial distance not so close to the real galaxies (Milky Way, etc.) or it would break them (1 parsec = 3.26 light years), so it is recommended to create the galaxies at the edge of the universe (up to you).
## - NOTE that your .csv file will be cleared if you will launch the program again on the same file
