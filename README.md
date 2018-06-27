
# Info
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

# How to use


1) Create a configuration object and add the relevant information in it:
    ```csharp
    var configuration = new HBaseConfiguration()
            {
                ThriftHost = "localhost",
                ThriftPort = 9090
            };
    ```
2) Create the factory object and configure it with the above configuration object and the relevant mappings:
    ```csharp
    var factory = new HBaseSessionFactory();
    factory.Configure(configuration);
    factory.Map(new UserConfig());
    
    ```
 3) Register the factory object as a singleton with your favorite DI container.
 4) Inject the factory as a dependency in your constructor by using the interface:
 ```csharp
  private readonly IHBaseSessionFactory _repoFactory;
  
  public MyConsumerObject(IHBaseSessionFactory repoFactory)
  {
    _repoFactory = repoFactory;
  }
 ```
 5) Use the repository like this:
 ```csharp
 private void MyDalMethod()
 {
    var repo = factory.BuildSession();
    
    //Get command - single row
    var user = repo.Get<User>().Row("my-row-key").SingleOrDefault();
    
    //Get command - multiple rows
    var users = repo.Get<User>().Rows("my-row-key-1","my-row-key-2","my-row-key-3").List();
    
    // or
    var sameUsers = repo.Get<User>().Row("my-row-key-1").Row("my-row-key-2").Row("my-row-key-3").List();
    
    //Scan - no filters
    var usersScan = repo.Scan<User>().List();
    
    //Scan - ValueFilter NOTE: all of the filters are implemented as methods of x
     var usersScanValueFilter = repo.Scan<User>().Filter(x=> x.ValueFilter().Value("Test Name")
                                                                            .Comparator(Comparator.Binary)
                                                                            .ComparisonOperator(ComparisonOperator.Equal)).List();
    
    
    // Put - Single object
    repo.Put<User>().Entity(user).Execute();
    
    // Put - List
    repo.Put<User>().Entities(users).Execute();
    
    
    }
 ```
 
 # Mapping
 
 In order to map a c# object to a HBase row you need to create:
 
 1) The domain entity or entities. For example:
 ```csharp
    public class User
    {
        public virtual string Rowkey { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        
        public virtual List<Permission> Permissions { get; set; }
        public virtual List<Role> Roles { get; set; }
                
        public override string ToString() => $"{Name} (Active: {IsActive})";

    }
    
    public class Permission
    {
        public virtual string Name { get; set; }
        public virtual int Id { get; set; }
        public override string ToString() => $"({Id}) {Name}";
    }
    
    public class Role
    {
        public virtual string Name { get; set; }
        public virtual int Id { get; set; }

        public override string ToString() => $"({Id}) {Name}";

    }
 ```
2) The mapping configuration(s):

If you want to map an entire row then create a new class that extends ClassMap<TEntity> like so:
    
   ```csharp
       public class UserConfig : ClassMap<User>
        {
            public UserConfig()
            {
                Table("ai_Users");
                RowKey(x=> x.Email);

                Property(x => x.Name).FromColumnFamily("u").WithColumn("Name");
                Property(x => x.IsActive).FromColumnFamily("u").WithColumn("IsActive");
            
                //Note: this transforms a column family to a IEnumerable<T> if you specify what property is the column name and what property is the column value.
                Property(x => x.Roles).EntireCFAsObject("r", x => x.Name, x => x.Id); 
                Property(x => x.Permissions).EntireCFAsObject("p", x => x.Name, x => x.Id);
            }
        }
   ```



