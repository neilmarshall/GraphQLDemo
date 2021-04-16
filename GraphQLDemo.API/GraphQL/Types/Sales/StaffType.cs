using GraphQL.Types;
using GraphQLDemo.Interfaces.Models.Sales;

namespace GraphQLDemo.API.GraphQLModel.Types.Sales
{
    public class StaffType : ObjectGraphType<Staff>
    {
        public StaffType()
        {
            Field(t => t.Active);
            Field(t => t.Email);
            Field(t => t.FirstName);
            Field(t => t.LastName);
            Field(t => t.ManagerId);
            Field(t => t.Phone);
            Field(t => t.StaffId);
            Field(t => t.StoreId);
        }
    }
}
