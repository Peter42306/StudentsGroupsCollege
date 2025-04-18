using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentsGroupsCollege.Models;

namespace StudentsGroupsCollege.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<College> Colleges { get; set; }
        public DbSet<CollegeGroup> CollegeGroups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Many-to-many relation through a join table
            modelBuilder.Entity<TeacherSubject>()
                .HasKey(ts => new { ts.TeacherId, ts.SubjectId });

            modelBuilder.Entity<TeacherSubject>()
                .HasOne(ts => ts.Teacher)
                .WithMany(t => t.TeacherSubjects)
                .HasForeignKey(ts => ts.TeacherId);

            modelBuilder.Entity<TeacherSubject>()
                .HasOne(ts => ts.Subject)
                .WithMany(s => s.TeacherSubjects)
                .HasForeignKey(ts => ts.SubjectId);




            // Colleges
            modelBuilder.Entity<College>().HasData(
                new College { Id = 1, Name = "Technical Academy", Description = "Specialized in engineering and computer science" },
                new College { Id = 2, Name = "Marine University", Description = "Focuses on maritime and logistics education" },
                new College { Id = 3, Name = "IT Step Academy", Description = "IT oriented academy" }
            );

            // Groups
            modelBuilder.Entity<CollegeGroup>().HasData(
                new CollegeGroup { Id = 1, Name = "ENG-101", CollegeId = 1, Description = "Lorem ipsum dolor sit amet, consectetur  deserunt mollit minim veniam, quis anim id est adipiscing elit." },
    new CollegeGroup { Id = 2, Name = "ENG-102", CollegeId = 1, Description = "Sed do eiusmod tempor incididunt ut labore et dolore." },
    new CollegeGroup { Id = 3, Name = "CS-201", CollegeId = 2, Description = "Ut enim ad minim veniam, quis nostrudi rure dolor in exercitation." },
    new CollegeGroup { Id = 4, Name = "NAV-101", CollegeId = 2, Description = "Duis aute irure dolor in reprehenderit in voluptate." },
    new CollegeGroup { Id = 5, Name = "LOG-202", CollegeId = 2, Description = "Excepteur sint  occaecat cupidatat non proident sunt." },
    new CollegeGroup { Id = 6, Name = "MAR-203", CollegeId = 2, Description = "Culpa qui officia deserunt mollit anim id est laborum." },
    new CollegeGroup { Id = 7, Name = "BUS-101", CollegeId = 3, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
    new CollegeGroup { Id = 8, Name = "MKT-202", CollegeId = 3, Description = "Nisi ut aliquip ex ea commodo consequat minim veniam, quis nostrud ullamco laboris." },
    new CollegeGroup { Id = 9, Name = "FIN-303", CollegeId = 3, Description = "Tempor incididunt ut labore et dolore magna aliqua." }
            );

            // Students
            modelBuilder.Entity<Student>().HasData(
            // Group 1
            new Student { Id = 1, Name = "Anna Petrova", CollegeGroupId = 1, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
            new Student { Id = 2, Name = "Dmitry Ivanov", CollegeGroupId = 1, Description = "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia." },
            new Student { Id = 3, Name = "Maria Sokolova", CollegeGroupId = 1, Description = "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." },
            new Student { Id = 4, Name = "Kirill Smirnov", CollegeGroupId = 1, Description = "Enim ad minim veniam quis nostrud exercitation ullamco laboris nisi." },
            new Student { Id = 5, Name = "Elena Orlova", CollegeGroupId = 1, Description = "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore." },
            new Student { Id = 6, Name = "Sergey Kozlov", CollegeGroupId = 1, Description = "Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit." },

            // Group 2
            new Student { Id = 7, Name = "Natalia Volkova", CollegeGroupId = 2, Description = "Voluptatem accusantium doloremque laudantium, totam rem aperiam." },
            new Student { Id = 8, Name = "Alexey Egorov", CollegeGroupId = 2, Description = "Eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae." },
            new Student { Id = 9, Name = "Irina Baranova", CollegeGroupId = 2, Description = "Ut enim ad minima veniam, quis nostrum exercitationem ullam." },
            new Student { Id = 10, Name = "Anton Vinogradov", CollegeGroupId = 2, Description = "Exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },

            // Group 3
            new Student { Id = 11, Name = "Olga Dmitrieva", CollegeGroupId = 3, Description = "Sit amet, consectetur adipiscing elit, sed do eiusmod tempor." },
            new Student { Id = 12, Name = "Vadim Nikitin", CollegeGroupId = 3, Description = "Cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non." },
            new Student { Id = 13, Name = "Ekaterina Filippova", CollegeGroupId = 3, Description = "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit." },

            // Group 4
            new Student { Id = 14, Name = "Maxim Lebedev", CollegeGroupId = 4, Description = "Quis autem vel eum iure reprehenderit qui in ea voluptate velit." },
            new Student { Id = 15, Name = "Svetlana Andreeva", CollegeGroupId = 4, Description = "Velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum." },
            new Student { Id = 16, Name = "Pavel Frolov", CollegeGroupId = 4, Description = "Fugiat quo voluptas nulla pariatur. At vero eos et accusamus." },
            new Student { Id = 17, Name = "Yulia Romanova", CollegeGroupId = 4, Description = "Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis." },
            new Student { Id = 18, Name = "Nikita Sorokin", CollegeGroupId = 4, Description = "Nisi ut aliquid ex ea commodi consequatur. Quis autem vel eum." },
            new Student { Id = 19, Name = "Tatiana Belova", CollegeGroupId = 4, Description = "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet." },
            new Student { Id = 20, Name = "Egor Semenov", CollegeGroupId = 4, Description = "Ut enim ad minima veniam quis nostrum exercitationem ullam corporis suscipit laboriosam." },
        
            // Group 5
            new Student { Id = 21, Name = "Larisa Mironova", CollegeGroupId = 5, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
            new Student { Id = 22, Name = "Roman Gusev", CollegeGroupId = 5, Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque." },
            new Student { Id = 23, Name = "Elizaveta Pavlova", CollegeGroupId = 5, Description = "Accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo." },
            new Student { Id = 24, Name = "Stepan Makarov", CollegeGroupId = 5, Description = "Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe." },

            // Group 6
            new Student { Id = 25, Name = "Irina Kalinina", CollegeGroupId = 6, Description = "Sed ut perspiciatis unde omnis iste natus error sit." },
            new Student { Id = 26, Name = "Yaroslav Markov", CollegeGroupId = 6, Description = "Ut enim ad minima veniam quis nostrum exercitationem ullam." },
            new Student { Id = 27, Name = "Diana Nikiforova", CollegeGroupId = 6, Description = "Corporis suscipit laboriosam nisi ut aliquid ex ea commodi consequatur." },
            new Student { Id = 28, Name = "Alexandr Vasiliev", CollegeGroupId = 6, Description = "Ut enim ad minima veniam quis nostrum exercitationem ullam corporis suscipit laboriosam." },
            new Student { Id = 29, Name = "Galina Kuznetsova", CollegeGroupId = 6, Description = "Quis autem vel eum iure reprehenderit qui in ea voluptate velit." },
            new Student { Id = 30, Name = "Igor Fedotov", CollegeGroupId = 6, Description = "Et harum quidem rerum facilis est et expedita distinctio." },

            // Group 7
            new Student { Id = 31, Name = "Maria Stepanova", CollegeGroupId = 7, Description = "Nam libero tempore cum soluta nobis est eligendi optio cumque nihil." },
            new Student { Id = 32, Name = "Boris Lebedev", CollegeGroupId = 7, Description = "Commodi consequatur quis autem vel eum iure reprehenderit." },
            new Student { Id = 33, Name = "Kseniya Zaitseva", CollegeGroupId = 7, Description = "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut." },
            new Student { Id = 34, Name = "Denis Abramov", CollegeGroupId = 7, Description = "Consequatur aut perferendis doloribus asperiores repellat." },
            new Student { Id = 35, Name = "Victoria Ermakova", CollegeGroupId = 7, Description = "Ut enim ad minima veniam quis nostrum exercitationem ullam corporis suscipit." },
    
            // Group 8
            new Student { Id = 36, Name = "Oksana Zueva", CollegeGroupId = 8, Description = "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse." },
            new Student { Id = 37, Name = "Andrei Krylov", CollegeGroupId = 8, Description = "Et harum quidem rerum facilis est et expedita distinctio." },

            // Group 9
            new Student { Id = 38, Name = "Natalia Bobrova", CollegeGroupId = 9, Description = "Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus." },
            new Student { Id = 39, Name = "Vladimir Ignatov", CollegeGroupId = 9, Description = "Itaque earum rerum hic tenetur a sapiente delectus ut aut." },
            new Student { Id = 40, Name = "Alina Safonova", CollegeGroupId = 9, Description = "Nisi ut aliquid ex ea commodi consequatur quis autem vel." },
            new Student { Id = 41, Name = "Stanislav Rodionov", CollegeGroupId = 9, Description = "Vel illum qui dolorem eum fugiat quo voluptas nulla pariatur." },
            new Student { Id = 42, Name = "Anastasia Belaya", CollegeGroupId = 9, Description = "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet consectetur." },
            new Student { Id = 43, Name = "Grigory Eliseev", CollegeGroupId = 9, Description = "Sit amet consectetur adipiscing elit sed do eiusmod tempor incididunt." },
            new Student { Id = 44, Name = "Ekaterina Nikitina", CollegeGroupId = 9, Description = "Cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non." },
            new Student { Id = 45, Name = "Artur Kuzmin", CollegeGroupId = 9, Description = "Ut enim ad minima veniam quis nostrum exercitationem ullam." }

            );

            // Subjects
            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = 1, Name = "Mathematical Analysis", Description = "Lorem ipsum dolor sit amet consectetur." },
                new Subject { Id = 2, Name = "Linear Algebra", Description = "Ut enim ad minim veniam quis nostrud exercitation ullamco." },
                new Subject { Id = 3, Name = "Marine Navigation", Description = "Duis aute irure dolor in reprehenderit in voluptate velit esse." },
                new Subject { Id = 4, Name = "Ship Management", Description = "Excepteur sint occaecat cupidatat non proident sunt culpa." },
                new Subject { Id = 5, Name = "International Logistics", Description = "Sed ut perspiciatis unde omnis iste natus error." },
                new Subject { Id = 6, Name = "Corporate Finance", Description = "Lorem ipsum dolor sit amet adipiscing elit sed." },
                new Subject { Id = 7, Name = "Discrete Mathematics", Description = "Ut labore et dolore magna aliqua enim ad." },
                new Subject { Id = 8, Name = "Marketing Strategies", Description = "Consectetur adipiscing elit sed do eiusmod tempor." },
                new Subject { Id = 9, Name = "Business Ethics", Description = "Velit esse cillum dolore eu fugiat nulla pariatur." },
                new Subject { Id = 10, Name = "Computational Models", Description = "Nisi ut aliquip ex ea commodo consequat laboris." }
            );

            // Teachers
            modelBuilder.Entity<Teacher>().HasData(
                // College 1
                new Teacher { Id = 1, Name = "Dr. Marina Volkova", Position = "Professor", CollegeId = 1 },
                new Teacher { Id = 2, Name = "Mr. Sergey Belov", Position = "Lecturer", CollegeId = 1 },
                new Teacher { Id = 3, Name = "Ms. Yana Petrova", Position = "Senior Lecturer", CollegeId = 1 },
                new Teacher { Id = 4, Name = "Mrs. Svetlana Orlova", Position = "Associate Professor", CollegeId = 1 },

                // College 2
                new Teacher { Id = 5, Name = "Dr. Ivan Denisov", Position = "Professor", CollegeId = 2 },
                new Teacher { Id = 6, Name = "Mr. Yuri Zverev", Position = "Lecturer", CollegeId = 2 },
                new Teacher { Id = 7, Name = "Ms. Anastasia Rybakova", Position = "Senior Lecturer", CollegeId = 2 },
                new Teacher { Id = 8, Name = "Mrs. Alina Golubeva", Position = "Associate Professor", CollegeId = 2 },
                new Teacher { Id = 9, Name = "Mr. Viktor Lavrov", Position = "Instructor", CollegeId = 2 },

                // College 3
                new Teacher { Id = 10, Name = "Dr. Elena Koroleva", Position = "Professor", CollegeId = 3 },
                new Teacher { Id = 11, Name = "Mr. Artem Tarasov", Position = "Lecturer", CollegeId = 3 },
                new Teacher { Id = 12, Name = "Ms. Irina Fedorova", Position = "Senior Lecturer", CollegeId = 3 },
                new Teacher { Id = 13, Name = "Mrs. Galina Mikhailova", Position = "Associate Professor", CollegeId = 3 },
                new Teacher { Id = 14, Name = "Mr. Nikolai Alekseev", Position = "Instructor", CollegeId = 3 }
            );

            // TeacherSubject (many-to-many)
            modelBuilder.Entity<TeacherSubject>().HasData(
                new TeacherSubject { TeacherId = 1, SubjectId = 1 },
                new TeacherSubject { TeacherId = 1, SubjectId = 2 },
                new TeacherSubject { TeacherId = 2, SubjectId = 2 },
                new TeacherSubject { TeacherId = 3, SubjectId = 7 },
                new TeacherSubject { TeacherId = 4, SubjectId = 10 },

                new TeacherSubject { TeacherId = 5, SubjectId = 3 },
                new TeacherSubject { TeacherId = 6, SubjectId = 4 },
                new TeacherSubject { TeacherId = 7, SubjectId = 5 },
                new TeacherSubject { TeacherId = 8, SubjectId = 5 },
                new TeacherSubject { TeacherId = 9, SubjectId = 4 },

                new TeacherSubject { TeacherId = 10, SubjectId = 6 },
                new TeacherSubject { TeacherId = 11, SubjectId = 8 },
                new TeacherSubject { TeacherId = 12, SubjectId = 8 },
                new TeacherSubject { TeacherId = 13, SubjectId = 9 },
                new TeacherSubject { TeacherId = 14, SubjectId = 9 }
            );

            // Staff
            modelBuilder.Entity<Staff>().HasData(
                // College 1
                new Staff { Id = 1, Name = "Tatiana Morozova", Role = StaffRole.Accountant, CollegeId = 1, Description = "Lorem ipsum dolor sit amet consectetur adipiscing elit sed." },
                new Staff { Id = 2, Name = "Andrei Sokolov", Role = StaffRole.Supervisor, CollegeId = 1, Description = "Ut enim ad minim veniam quis nostrud exercitation ullamco laboris nisi." },
                new Staff { Id = 3, Name = "Irina Vlasova", Role = StaffRole.Cleaner, CollegeId = 1, Description = "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore." },
                new Staff { Id = 4, Name = "Yulia Antonova", Role = StaffRole.Librarian, CollegeId = 1, Description = "Excepteur sint occaecat cupidatat non proident sunt in culpa." },
                new Staff { Id = 5, Name = "Oksana Petrova", Role = StaffRole.Secretary, CollegeId = 1, Description = "Eiusmod tempor incididunt ut labore et dolore magna aliqua." },
                new Staff { Id = 6, Name = "Vladimir Ivanov", Role = StaffRole.Security, CollegeId = 1, Description = "Reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur." },

                // College 2
                new Staff { Id = 7, Name = "Natalia Belkina", Role = StaffRole.Accountant, CollegeId = 2, Description = "Consectetur adipiscing elit sed do eiusmod tempor incididunt ut labore." },
                new Staff { Id = 8, Name = "Sergey Zhukov", Role = StaffRole.Supervisor, CollegeId = 2, Description = "Nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo." },
                new Staff { Id = 9, Name = "Elena Voronova", Role = StaffRole.Cleaner, CollegeId = 2, Description = "Ut aliquip ex ea commodo consequat duis aute irure dolor." },
                new Staff { Id = 10, Name = "Igor Romanov", Role = StaffRole.Librarian, CollegeId = 2, Description = "Sunt in culpa qui officia deserunt mollit anim id est laborum." },
                new Staff { Id = 11, Name = "Tatiana Miroshnichenko", Role = StaffRole.Secretary, CollegeId = 2, Description = "Lorem ipsum dolor sit amet consectetur adipiscing elit." },
                new Staff { Id = 12, Name = "Pavel Ershov", Role = StaffRole.Security, CollegeId = 2, Description = "Voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint." },

                // College 3
                new Staff { Id = 13, Name = "Olga Kuzmina", Role = StaffRole.Accountant, CollegeId = 3, Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem." },
                new Staff { Id = 14, Name = "Dmitry Pavlov", Role = StaffRole.Supervisor, CollegeId = 3, Description = "Accusantium doloremque laudantium totam rem aperiam eaque ipsa." },
                new Staff { Id = 15, Name = "Svetlana Koroleva", Role = StaffRole.Cleaner, CollegeId = 3, Description = "Quis autem vel eum iure reprehenderit qui in ea." },
                new Staff { Id = 16, Name = "Kirill Trofimov", Role = StaffRole.Librarian, CollegeId = 3, Description = "Voluptas nulla pariatur at vero eos et accusamus." },
                new Staff { Id = 17, Name = "Anastasia Fedorova", Role = StaffRole.Secretary, CollegeId = 3, Description = "Ut enim ad minima veniam quis nostrum exercitationem ullam." },
                new Staff { Id = 18, Name = "Oleg Grigoriev", Role = StaffRole.Security, CollegeId = 3, Description = "Laboriosam nisi ut aliquid ex ea commodi consequatur." }

            );
        }
    }
}
