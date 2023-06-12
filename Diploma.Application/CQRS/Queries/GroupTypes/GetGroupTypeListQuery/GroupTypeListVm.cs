namespace Diploma.Application.CQRS.Queries.GroupTypes.GetGroupTypeListQuery
{
    public class GroupTypeListVm
    {
        public GroupTypeListVm() { GroupTypeList = new(); }
        public List<GroupTypeListDto> GroupTypeList { get; set; }
    }
}
