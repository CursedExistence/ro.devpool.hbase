This project aims to simplify the interaction between HBase and an application written in C#.

What can you do with this project:

1) Map an object to a hbase row
     * Map a column from a column family to a property
     * Map an entire column family into a list of objects or a dictionary.
 2) Issue SCAN commands that return a list of objects or an object (With filters as delegates)
 3) Issue GET commands that return one or more objects.
 4) Issue PUT commands to persist objects into HBase rows
 5) Issue DELETE commands for row/columns removal.
 
 This project is currently a work in progress and should NOT be used in a production environment.
 
 NOTE: This project DOES NOT provide relational mapping!
