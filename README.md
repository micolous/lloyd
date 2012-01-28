# Lloyd #

**Lloyd** monitors alcohol tabs and consumption.

It is designed to run in a kiosk environment, where you have a barcode scanner and touchscreen attached.

This software is incomplete, and still under development.

## Database format ##

Database operations are handled through Fluent NHibernate to a SQLite3 database (lloyd.db3).

Passwords for users are stored as unsalted SHA1.  While the interface doesn't offer an interface for recovery of passwords (only changing them), it would be very easy for an attacker to recover the access codes for users by brute force (especially if you use short, 4 digit access keys).