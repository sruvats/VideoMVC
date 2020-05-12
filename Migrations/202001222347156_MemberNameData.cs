namespace video.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberNameData : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set MembershipTypeName='Pay as you Go' where Id=1");
            Sql("update MembershipTypes set MembershipTypeName='Monthly' where Id=2");
            Sql("update MembershipTypes set MembershipTypeName='Quaterly' where Id=3");
            Sql("update MembershipTypes set MembershipTypeName='Yearly' where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
