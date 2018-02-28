namespace ContactModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactDB_V2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "AddedTimestamp", c => c.DateTime());
            AlterColumn("dbo.Contacts", "UpdatedTimestamp", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "UpdatedTimestamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contacts", "AddedTimestamp", c => c.DateTime(nullable: false));
        }
    }
}
