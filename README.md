# NTouch

# Update 10.4.2024: A new video was published

DataJuggler.Blazor.Components Grand Update
https://youtu.be/ybihE8udW-w

This project has been updated with a new release of DataJuggler.Blazor.Components.

NTouch is a simple contact management website and database. This project is a demo for NuGet package 
DataJuggler.Blazor.Components. You will need SQL Server and Visual Studio 2022 to run it.

# Update 5.18.2024

New Video:

First Ever Opensource Saturday - Sunday Edition
https://youtu.be/uxa1xR6xpzk

# DataJuggler.Blazor.Components Updates

DataJuggler.Blazor.Components has a couple of major updates. First, a new Calendar ocmponent has been added 
and the ComboBox has been completely redone (now you can hit T twice, for Texas in a States list, for example).
There is also a CheckedListBox, that serves as the dropp down for the CombBox, in Checked List Mode. This project
contains two combo boxes, one for states, and one for a list of contact methods a user prefers to be contacted by.

Most of the component demo's are located in the Components folder, in the Contact Editor.

# DataTier .Net
The data tier for this project was built using DataTier .Net. DataTier .Net creates stored procedure powered data tiers,
and I much prefer it over Entity Framework. 

I do not have time to make sample projects for each of my projects, so this project will serve as a Demo for 
DataJuggler.Blazor.Components, DataJuggler.Blazor.FileUpload, DataJuggler.Excelerate, DataJuggler.UltimateHelper
and DataTier .Net.

If you think any of these projects are worth the price (free), please take the time to leave a star on Git Hub and / or
subscribe to my YouTube channel.

# Setup Instructions

1. Create a database in SQL Server Management Studio named NTouch
2. Excecute the SQL Script NTouchDatabae.sql, located in the SQL folder of this project.
3. Build a Connection String to the NTouch database. 

Tip: Install DataTier.Net from
https://github.com/DataJuggler/DataTier.Net

Install DataTier .Net from the Releases tab, on the right hand side of the page above.
DataTier .Net installs a prograam called ConnectionBuilder, and hopefully you will think it is worth the price (and worth a star on its own)

Your connection string should look something like this:

Data Source=(YourServerName);Initial Catalog=NTouch;Integrated Security=True;Encrypt=False;

Replace YourServerName with your SQL Server Name. Make sure to include the full name, including \SQLExpress if that is the case.

My server name is Rocket\SQLExpress
Data Source=Rocket\SQLExpress;Initial Catalog=NTouch;Integrated Security=True;Encrypt=False;

4. Create a System Environment Variable (at the bottom, not a user) named NTouchConnString, 
and set the value to a connection string for the NTouch database. 

That should be all you have to do.

# Video Recording In Progress

I am making a new video now for this project, and will demo how to recreate the data tier using DataTier .Net.
The video will also include (re)importing the State list from Excel, using NuGet package DataJuggler.Excelerate, and 
the opensource site Blazor Excelerate

Blazor Excelerate
https://excelerate.datajuggler.com 
Code Generate C# Classes From Exccel Header Rows.

# Limitations

This is a demo project, and therefore does not include authentication or logging into user accounts, or complex error handling.

The Grid currently does not handle paging, so limit your contacts to about 10 for now. If I ever get time I will update the project
and Grid with paging, filtering and maybe some other features.

Let me know what you think of DataJuggler.Blazor.Components? Are they worth the price?

Corby / Data Juggler