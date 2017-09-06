The items are listed in item_list.txt.
This is necessary since Unity can't create a list of items in the Resource directory

The list was created with this command line 
ls -1 | sed 's/\(.*\)\..*/\1/' > item_list.txt
