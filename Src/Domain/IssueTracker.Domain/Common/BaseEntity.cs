﻿using System;

namespace IssueTracker.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }

    }
}