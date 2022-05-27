With general store we will take the concepts we learned with RestaurantRater and expand them
we will also utilize a code scaffolding tool to build our classes off of the prebuilt database

First go ahead and create a new webapi
dotnet new webapi -o GeneralStoreAPI

and navigate into it 
cd GeneralStoreAPI

you should have students go ahead and setup a git repo for this including a gitignore for extra practice

finally run a code . to open a  vscode scoped to that window

We will go ahead and add in our packages

dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

Additionally this time through we do not want to put our connection string straight into the code so we will utilize something called user secrets.
To do this we will run a few commands

dotnet user-secrets init
initializes the secrets file

dotnet user-secrets set ConnectionStrings:GeneralStoreDB "[Connection String]"
Here we are creating a connection string inside the user secrets file and attaching a connection that we named GeneralStoreDB

so final product should look something like

dotnet user-secrets init
dotnet user-secrets set ConnectionStrings:GeneralStoreDB "Server=localhost;Database=GeneralStoreDB;User Id=sa;Password=[PASSWORD];"

once all of that is setup we can now scaffold out our app
this will utilize some entity framework tools so we will want to go ahead and install a tool manifest once again
dotnet new tool-manifest
dotnet tool install dotnet-ef

Then we should be able to run 

dotnet ef dbcontext scaffold Name=ConnectionStrings:GeneralStoreDB --context-dir Data --output-dir Models Microsoft.EntityFrameworkCore.SqlServer

to scaffold out the project.

once that is complete go through the models and the DB Context to show that it has all been scaffolded out for us. Although it may look different from what we hand coded it is still the same idea.

Once you have done that we can go ahead and get started on some controllers so lets get started with Products. Likely starting with the product edit model in a similar fashion to what we did with restaurant rater. 