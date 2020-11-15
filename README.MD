<h2>BeeseChurger.SqlBuilder</h2>
A lightweight C# library to build SQL queries without the need for a Database connection.

<h3>Installation</h3>
Install via NuGet or via the Package manager console using 

```
Install-Package BeeseChurger.SqlBuilder
```

<h3>Motivation</h3>
The reason I made this project was because I kept coming across large SQL strings in the legacy code I've been working on and found it quite difficult to understand/refactor in the given state. This builder provides the quick refactor to ensure the SQL is valid and adheres to our coding standards and is also a lot easier to read in C# code.

<h3>Usage</h3>
<h4>SELECT Queries</h4>

```csharp
var builder = new SelectBuilder()
    .Select("*")
    .From("table")
    .Where("x = 2")
    .And("y = 'John'");
Console.WriteLine(builder.Build()) // "SELECT * FROM table WHERE x = 2 AND y = 'John' ;

```


```csharp
var builder = new SelectBuilder()
    .Select("*")
    .From("table")
    .Where("x", 3)
    .Paginate(1, 2);
Console.WriteLine(builder.Build()) // SELECT * FROM table WHERE x = 3 OFFSET 0 ROWS FETCH NEXT 2 ROWS ONLY ;

```

<h4>UPDATE Queries </h4>

```csharp
var builder = new UpdateBuilder()
    .Update("dbo.table")
    .Set("company", "dummyCompany")
    .Where("id", 5);
Console.WriteLine(builder.Build()) // UPDATE dbo.Table SET company = 'dummyCompany' WHERE id = 5 ;

```

<h3>Submitting Issues </h3>

Have any feature requests or bugs? Create an issue and/or feel free to clone the repo and have a play!
