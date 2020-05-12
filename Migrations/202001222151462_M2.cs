namespace video.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id,SignupFee,DurationInMonths,DiscountRate)values(1,0,0,0)");
            Sql("INSERT INTO MembershipTypes(Id,SignupFee,DurationInMonths,DiscountRate)values(2,30,1,10)");
            Sql("INSERT INTO MembershipTypes(Id,SignupFee,DurationInMonths,DiscountRate)values(3,90,5,15)");
            Sql("INSERT INTO MembershipTypes(Id,SignupFee,DurationInMonths,DiscountRate)values(4,300,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
