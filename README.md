# Madden 20 - Custom Playbook Editor

Only supports custom playbook db files.

There is limited undo ability and no Save As feature, so it would be a good idea to create backup playbook before editing.


Playbook Editor
-
You need a customplaybooks.db file.  Use Frosty to export customplaybooks.db Menu>Legacy>common>database>playbooks>customplaybooks.
Open a customplaybooks.DB file from the file menu and a dropdown will appear with a list of formations.  All formations are listed together and will draw correctly, but only Offensive plays are drawn and able to be edited and saved.

Select a Formation to show Sub-Formations and list all plays in the Sub-Formation.  The play will be drawn along with a list of player assignments which can be edited.

To edit assignments, enter data manually in the data grid, or right-click a row in the data grid to show a list of assignments to choose from.  The assignments can be reset while in the popup window.  Clicking outside of this window will commit changes which can not be reverted.

Play data such as the play name can also be edited by clicking the button next to the play name, or by right-clicking the play list to reveal a new window.  These changes can also be reverted by closing the window or commited by clicking the Update button.


Route Visualizer
-
The Route Visualizer tool exists in the tools menu and currently only works with the provided csv.  It can draw and save routes one at a time, or save more than one route by selecting multiple groups of ID steps and selecting save all from the menu.

# v1.36 - Small bug fix for a crash copy/pasting plays with Swing Routes

# v1.35 - Fixed a bug that prevented PBFM from copying to Team Playbooks

# v1.34 - Custom Route Colors

Available in PLYS table context menu
Doesn't stick or save

# v1.33 - Copy/Paste entire Formation, Sub-Formations and Plays from CPB to TPB

Copy is a little slow.  Let is cycle through all the Formations and Plays before pasting.

# v1.32 - Bug Fixes with Copy/Paste from CPB to TPB

# v1.31 - Add/Remove SETG Motion Alignments

Motions accessible in options>Playart>PSAL
Edit Formation > Right-Clight a player row in the SETG Alignment tab to add or remove from motion

# v1.21 - Code 58 and PLYL search

Search for Code 58 copies all code 58 data to clipboard in csv format
PLYL Search looks for matching PLYL id and loadds the play if it exists

Supports Copy/Paste to Custom Playbook Editor

# v1.20 - Copy Entire Play to Team Playbook Editor

Supports Copy/Paste to Custom Playbook Editor

https://github.com/morphyyyy/Madden-20-Team-Playbook-Editor

# v1.14 - Copy/Paste PSAL

-
Added copy and paste to PSAL Assignment Table.  Copies and pastes selected player PLYS rows. 

# v1.11 - Playart Update

-
Option Routes and Play-Action Blocking now draw correctly in ARTL Playart.

# v1.10 - Playart Update, Edit Sub-Formation (SETL), Add/Remove PLPD and PLRD, Add/Remove SRFT

Playart Update
-
Offensive Playart draws in proper order now.  I.E. Blocking, QB, Base Routes, Primary Receiver, Delay Route, Motion Route, then Running.
Defensive Playart draws in proper order now.  I.E. Rush/Blitz, Deep Zone, Hook then Flat.

Edit Sub-Formation (SETL)
-
Added the ability to edit SETL (Sub-Formation) name, MOTN, CLAS, SETT, SITT, SLF_ (determines the defensive set) and poso.

Add/Remove PLPD and PLRD
-
Added the ability to add or remove PLPD/PLRD records in Edit Play, under Options menu.

Add/Remove SRFT
-
Added the ability to add or remove SRFT records.

# v1.09 - Edit and Create PSAL

Edit PSAL
-
Added the ability to edit existing PSALs.  Right-Click on the Player Assignment Table and select Swap/Edit PSAL.  A new window will open where new PSALs can be assigned.  Click the Edit checkbox to edit the current PSAL.  Right-Click a cell to Insert/Delete steps.  (WARNING - PSALs exist in multiple plays, so edit with caution)

Create PSAL
-
Added an option to create a new PSAL.  Select a Player Assignment in the Player Assignment Table to use as a base for the new PSAL.  Right-Click on the Player Assignment Table and select Create New PSAL.  A new Window will open with the steps from the default PSAL.  Right-Click a cell to Insert/Delete steps and/or manually edit the PSAL by entering data into the cells of the table.  When finished, click the Create button to create the new PSAL.  To create a PSAL without assigning it, uncheck the 'Assign PSAL to Selected poso' checkbox, or leave the box checked to create and assign the PSAL.  Unassigned newly created PSALs will show in the Unused PSALs PLRR list in the Swap/Edit PSAL window.  Click the Discard button to cancel and discard the new PSAL.

# v1.08 - Devensive Playart Update

Defensive Playart is 99% complete if not 100% accurate. (ARTL)

Playart can be saved by right-clicking the playart.

# v1.07 - Defensive Edits, Playart Option, Player Assignment List

Defensive Edits
-
Added support to edit and save Defensive Assignments and Defensive Play edits to the db.  Edit Play now populates with SRFT table that can be edited and saved.

Playart Option
-
Playart can be drawn with raw data or with the Playart from Menu>Tools>Playart.  Still a WIP but good enough to view Defense as the Defensive raw data is incomplete at the moment.

Player Assignment List
-
Right-clicking the Player Assignment Table now populates with a Data Grid of the current assignment, along with a list of assignments to choose from.

# v1.06 - Formation Alignments, Flip Play, Formation (Alignment and Position) Edits

Formation Alignments
-
Added the Formation Alignments and motions.  They are listed in the Motion/Alignments dropdown.  This will update in the Playart preview.
*** Routes will not flip as they do in game; i.e. flat routes

Flip Play
-
Added the ability to flip the play

Formation Edits
-
Added the ability to edit/save Formation Alignments (STEG) and Formation Positions (STEP).
Motions and alignments can be edited/saved.  Pick the motion that you want to edit in the Motions/Alignments dropdown, then click the Edit Formation button.  The inactive records (player assignments) for that motion/alignment will be disabled.  The remaining active rows are the players that account for that motion/alignment.  For example, M1le is motion player 1 to the left.  When the play is flipped the active offset is fx__, fy__; x___, y___ when the play is not flipped.
