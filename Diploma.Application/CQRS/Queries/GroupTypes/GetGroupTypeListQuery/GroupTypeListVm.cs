﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Queries.GroupTypes.GetGroupTypeListQuery
{
    public class GroupTypeListVm
    {
        public GroupTypeListVm() { GroupTypeList = new(); }
        public List<GroupTypeListDto> GroupTypeList { get; set; }
    }
}
