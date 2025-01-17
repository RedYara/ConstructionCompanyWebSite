namespace Application.CQRS.Queries.GroupTypes.GetGroupTypeListQuery
{
    public class GroupTypeListVm
    {
        public GroupTypeListVm() { GroupTypeList = []; }
        public List<GroupTypeListDto> GroupTypeList { get; set; }
    }
}
