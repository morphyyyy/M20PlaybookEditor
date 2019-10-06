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
