# M20PlaybookEditor

This playbook editor currently only supports custom playbooks.  It is in beta state with limited functionality, so bugs are possible, but it is relatively stable.

There is limited undo ability and no Save As feature, so it would be a good idea to create backups before editing.


Playbook Editor -

You need a customplaybooks.db file.  Use Frosty to export customplaybooks.db Menu>Legacy>common>database>playbooks>customplaybooks.
Open a customplaybooks.DB file from the file menu and a dropdown will appear with a list of formations.  All formations are listed together and will draw correctly, but only Offensive plays are drawn and able to be edited and saved.

Select a Formation to show Sub-Formations and list all plays in the Sub-Formation.  The play will be drawn along with a list of player assignments which can be edited.

To edit assignments, enter data manually in the data grid, or right-click a row in the data grid to show a list of assignments to choose from.  The assignments can be reset while in the popup window.  Clicking outside of this window will commit changes which can not be reverted.

Play data such as the play name can also be edited by clicking the button next to the play name, or by right-clicking the play list to reveal a new window.  These changes can also be reverted by closing the window or commited by clicking the Update button.


Route Visualizer -

The Route Visualizer tool exists in the tools menu and currently only works with the provided csv.  It can draw and save routes one at a time, or save more than one route by selecting multiple groups of ID steps and selecting save all from the menu.



V1.06 - Formation Alignments, Flip Play, Formation Edits
-

Formation Alignments -

Added the Formation Alignments and motions.  They are listed in the Motion/Alignments dropdown.  This will update in the Playart preview.
*** Routes will not flip as they do in game; i.e. flat routes

Flip Play -
Added the ability to flip the play

Formation Edits -
Added the ability to edit/save Formation Alignments (STEG) and Formation Positions (STEP).
Motions can also be edited.  Pick the motion that you want to edit in the Motions/Alignments dropdown, then click the Edit Formation button.  The inactive records (player assignments) for that motion/alignment will be disabled.  The remaining active rows are the players that account for that motion/alignment.  For example, M1le is motion player 1 to the left.  When the play is flipped the active offset is fx__, fy__ and x___, y___ when the play is not flipped.
