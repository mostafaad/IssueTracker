﻿using System;

namespace IssueTracker.Domain.Common
{
    public abstract class BaseEntity
    {

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        public bool IsDeleted { get; set; }

    }
}
