Console Commands
dotnet new webapi -o RestaurantRaterAPI
cd Restaurant Rater
code . (if you want to open a vscode scoped to this project)

make sure if making git repositories that a gitignore is created
dotnet new gitignore

we can go into the program.cs file and pass a string into the start method to specify our port number.

after running the program and looking over swagger we will want to connect it to our local database that we built in the sql section

first we will want to add in a few packages.
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design

we also want to bring in our entity framework tools into a tool manifest
dotnet new tool-manifest
dotnet tool install dotnet-ef

We will now build out our context inside the RestuarantDbContext.cs file


