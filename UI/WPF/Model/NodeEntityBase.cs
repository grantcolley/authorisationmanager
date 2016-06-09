using DevelopmentInProgress.DipCore;

namespace DevelopmentInProgress.AuthorisationManager.WPF.Model
{
    public abstract class NodeEntityBase : EntityBase
    {
        public virtual string Text { get; set; }

        public virtual string Code { get; set; }

        public virtual string Description { get; set; }

        public NodeEntityBase Parent { get; set; }
    }
}
