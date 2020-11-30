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
var builder = SelectBuilder.Init()
    .Select("*")
    .From("table")
    .Where("x = 2")
    .And("y = 'John'");
Console.WriteLine(builder.Build()); 
// "SELECT * FROM table WHERE x = 2 AND y = 'John' ;

```


```csharp
var builder = SelectBuilder.Init()
    .Select("x")
    .Select("y")
    .From("table")
    .Where("x", 3)
    .Paginate(1, 2);
Console.WriteLine(builder.Build()); 
// SELECT x, y FROM table WHERE x = 3 OFFSET 0 ROWS FETCH NEXT 2 ROWS ONLY ;

```

```csharp
var builder = SelectBuilder.Init()
    .Select("TOP(100) *")
    .From("table1")
    .InnerJoin("table2)
    .On("table1.Id = table2.t1Id)
Console.WriteLine(builder.Build()); 
// SELECT TOP(100) * FROM table INNER JOIN table2 ON table1.Id = table2.t1Id ;

```

<h4>UPDATE Queries </h4>

```csharp
var builder = UpdateBuilder
    .Update("dbo.table")
    .Set("company", "dummyCompany")
    .Set("name", "myName")
    .Where("id", 5);
Console.WriteLine(builder.Build()); 
// UPDATE dbo.Table SET company = 'dummyCompany' WHERE id = 5 ;

```


<h4>INSERT INTO Queries </h4>

```csharp
var builder = InsertBuilder
    .InsertInto("table", new string[] { "col1", "col2" })
    .Value(1)
    .Value("skdajhfla")
Console.WriteLine(builder.Build()); 
// INSERT INTO table (col1, col2) VALUES (1, 'skdajhfla') ;

```


```csharp
var builder = InsertBuilder
    .InsertInto("table", new string[] { "col1", "col2" })
    .Values(new object[] { 1, "skdajhfla" });
Console.WriteLine(builder.Build()); 
// INSERT INTO table (col1, col2) VALUES (1, 'skdajhfla') ;

```

<h3>Submitting Issues </h3>

Have any feature requests or bugs? Create an issue and/or feel free to clone the repo and have a play!
