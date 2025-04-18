using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentsGroupsCollege.Data;

namespace StudentsGroupsCollege
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();


            // Output LINQ query results to the console for testing purposes
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var students = db.Students
                    .Include(s => s.CollegeGroup)
                    .ThenInclude(g => g.College)
                    .ToList();

                var teachers = db.Teachers
                    .Include(t => t.College)
                    .Include(t => t.TeacherSubjects)
                        .ThenInclude(ts => ts.Subject)
                    .ToList();

                var subjects = db.Subjects
                    .Include(s => s.TeacherSubjects)
                        .ThenInclude(ts => ts.Teacher)
                    .ToList();

                var staff = db.Staffs
                    .Include(s => s.College)
                    .ToList();

                Console.WriteLine();
                Console.WriteLine("============================================= STUDENTS ========================================================");
                Console.WriteLine($"{"Name",-20}{"Group",-20}{"College",-30}");
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.Name,-20}{student.CollegeGroup.Name,-20}{student.CollegeGroup.College.Name,-30}");
                }

                Console.WriteLine();
                Console.WriteLine("============================================= TEACHERS ========================================================");
                Console.WriteLine($"{"Name",-25}{"Position",-20}{"College",-30}{"Subjects",-40}");
                foreach (var teacher in teachers)
                {
                    var subjectsList = string.Join(", ", teacher.TeacherSubjects.Select(ts => ts.Subject.Name));
                    Console.WriteLine($"{teacher.Name,-25}{teacher.Position,-20}{teacher.College.Name,-30}{subjectsList,-40}");
                }

                Console.WriteLine();
                Console.WriteLine("============================================= SUBJECTS ========================================================");
                Console.WriteLine($"{"Subject",-30}{"Teachers",-50}");
                foreach (var subject in subjects)
                {
                    var teachersList = string.Join(", ", subject.TeacherSubjects.Select(ts => ts.Teacher.Name));
                    Console.WriteLine($"{subject.Name,-30}{teachersList,-50}");
                }

                Console.WriteLine();
                Console.WriteLine("============================================= STAFF ===========================================================");
                Console.WriteLine($"{"Name",-25}{"Role",-20}{"College",-30}");
                foreach (var staffMember in staff)
                {
                    Console.WriteLine($"{staffMember.Name,-25}{staffMember.Role,-20}{staffMember.College.Name,-30}");
                }

                Console.WriteLine();
                Console.WriteLine("===============================================================================================================");

            }

            app.Run();
        }
    }
}
