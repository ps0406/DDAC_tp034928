namespace DDAC_TP034928.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        cargoWeight = c.Int(nullable: false),
                        amount = c.Int(nullable: false),
                        customerId = c.Int(nullable: false),
                        scheduleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.customerId, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.scheduleId, cascadeDelete: true)
                .Index(t => t.customerId)
                .Index(t => t.scheduleId);
            
            //CreateTable(
            //    "dbo.Customers",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            customerName = c.String(nullable: false),
            //            customerEmail = c.String(nullable: false),
            //            contactNo = c.String(nullable: false, maxLength: 11),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        vesselId = c.Int(nullable: false),
                        origin = c.String(nullable: false, maxLength: 100),
                        destination = c.String(nullable: false, maxLength: 100),
                        departureTime = c.DateTime(nullable: false),
                        arrivalTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vessels", t => t.vesselId, cascadeDelete: true)
                .Index(t => t.vesselId);
            
            CreateTable(
                "dbo.Vessels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        vesselName = c.String(nullable: false, maxLength: 50),
                        capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.AspNetRoles",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Bookings", "scheduleId", "dbo.Schedules");
            DropForeignKey("dbo.Schedules", "vesselId", "dbo.Vessels");
            DropForeignKey("dbo.Bookings", "customerId", "dbo.Customers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Schedules", new[] { "vesselId" });
            DropIndex("dbo.Bookings", new[] { "scheduleId" });
            DropIndex("dbo.Bookings", new[] { "customerId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Vessels");
            DropTable("dbo.Schedules");
            DropTable("dbo.Customers");
            DropTable("dbo.Bookings");
        }
    }
}
