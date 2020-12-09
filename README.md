Code-First Flow Demo of creation of database and tables


In Code-First flow, the database is not created, but the models (classes) are created first. These models will be transformed into tables. 

The below-detailed steps will help you to create a Code-First database:

a. Create a new project in Visual Studio 2019, and select the 'ASP .Net Web Application' template.


b. Provide a name and click 'Create'.



c. Select API.



d. Add a .cs file to the project - CodeFirstDemo.cs




e. Copy and paste the below code -


A domain Subject can have many Tags, and Tags can be tagged to many Subjects. Hence, it has many-to-many relationship. However, a Subject can have one Author (just an assumption) and once SubjectField.

public class Subject 

    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public SubjectField Field { get; set; }

        public float Price { get; set; }

        public Author Author { get; set; }

        public IList<Tag> Tags { get; set; }

    }



    public class Author

    {

        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Subject> Subjects { get; set; }

    }



    public class Tag

    {

        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Subject> Subjects { get; set; }

    }



    public enum SubjectField

    {

        Engineering = 1,

        Medical = 2,

        Commerce = 3

    }

f. Next, we need to install 'Entity Framework' NuGet package.Navigate to Tools->Nuget Package Manager->Manage Nuget package for solutions. Search for Entity Framework. Select Entity Framework 6. Click o Install. This will install Entity Framework.



g. Next, add below code. DbContextclass is defined in using System.Data.Entity; We need to create a class which overrides DbContext. This class should have DbSet. DbSet is a collections of objects which represent the tables in the Database.
 public class BookDbContext : DbContext

    {

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Tag> Tags { get; set; }



        public BookDbContext()

            : base("name=DefaultConnection")

        {



        }

    }

h. We have created domains, and DbContext class. Next, we should create connection string; connection string is required to tell the EF which DB engine to use. We can use any DB engine: AWS aurora, AQL server etc. That's the beauty of EF.

To provide a connection string in the config file, open appsettings.json and provide below code:

The connection string is Server=localhost;Database=vul_master;Trusted_Connection=True


 public BookDbContext()

            : base("Server=localhost;Database=vul_master;Trusted_Connection=True")

        {



        }

i. We have created domains, then DBConext class and also provided the connection string details. Now, we need to enable the migrations; this is a one-time task.

To enable the migrations, we need to open Packgae Manager console.

Opne Package Manager Console, and run the below command:

enable-migrations





A Migration folder would have been created.

j. A migration folder has been created. Now, we need to add a migration and update the database; this will create the tables in the database.

To add a migration, run below command:

add-migration <name of the migration>

After this, update the database by running following command:

update-database

k. To check the database and the tables, open Microsft SQL server management studio and select localhost





l. Expand the database you would have provided in the connection string; then expand the tables. You would see the tables.











