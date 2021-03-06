﻿using System;
using DevelopmentInProgress.DipCore;

namespace DevelopmentInProgress.AuthorisationManager.WPF.Model
{
    [Serializable]
    public abstract class NodeEntityBase : EntityBase
    {
        public virtual string Text { get; set; }

        public virtual string Code { get; set; }

        public virtual string Description { get; set; }

        public int ParentId { get; set; }

        public ParentType ParentType { get; set; }
    }
}
