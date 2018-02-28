namespace ContactModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactDB_V3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Contacts", "LastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Contacts", "Email", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Contacts", "PhoneNumber", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Contacts", "Email", c => c.String());
            AlterColumn("dbo.Contacts", "LastName", c => c.String());
            AlterColumn("dbo.Contacts", "FirstName", c => c.String());
        }
    }
}
