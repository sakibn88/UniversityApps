namespace UniversityApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sakib : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignCourses",
                c => new
                    {
                        AssignCourseId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        CreditTaken = c.Double(nullable: false),
                        RemaingCredit = c.Double(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignCourseId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.DepartmentId)
                .Index(t => t.TeacherId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Credit = c.Double(nullable: false),
                        Description = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                        AssignTo = c.String(),
                        CourseSemester_SemisterId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Semesters", t => t.CourseSemester_SemisterId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CourseSemester_SemisterId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        Email = c.String(nullable: false),
                        ContactNo = c.String(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        CreditTaken = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Designations", t => t.DesignationId)
                .Index(t => t.DesignationId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        SemisterId = c.Int(nullable: false, identity: true),
                        SemisterName = c.String(),
                    })
                .PrimaryKey(t => t.SemisterId);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        DayId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DayId);
            
            CreateTable(
                "dbo.RoomAllocations",
                c => new
                    {
                        RoomAllocationId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        DayId = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RoomAllocationId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Days", t => t.DayId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CourseId)
                .Index(t => t.RoomId)
                .Index(t => t.DayId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        RegistrationId = c.String(),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ContactNo = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.RoomAllocations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomAllocations", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.RoomAllocations", "DayId", "dbo.Days");
            DropForeignKey("dbo.RoomAllocations", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.AssignCourses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.AssignCourses", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AssignCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CourseSemester_SemisterId", "dbo.Semesters");
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.RoomAllocations", new[] { "DayId" });
            DropIndex("dbo.RoomAllocations", new[] { "RoomId" });
            DropIndex("dbo.RoomAllocations", new[] { "CourseId" });
            DropIndex("dbo.RoomAllocations", new[] { "DepartmentId" });
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.Teachers", new[] { "DesignationId" });
            DropIndex("dbo.Courses", new[] { "CourseSemester_SemisterId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropIndex("dbo.AssignCourses", new[] { "CourseId" });
            DropIndex("dbo.AssignCourses", new[] { "TeacherId" });
            DropIndex("dbo.AssignCourses", new[] { "DepartmentId" });
            DropTable("dbo.Students");
            DropTable("dbo.Rooms");
            DropTable("dbo.RoomAllocations");
            DropTable("dbo.Days");
            DropTable("dbo.Semesters");
            DropTable("dbo.Designations");
            DropTable("dbo.Teachers");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
            DropTable("dbo.AssignCourses");
        }
    }
}
