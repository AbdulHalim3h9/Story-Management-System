using Autofac;

namespace ListeningRoom.Web.Areas.Admin.Models
{
    public class BaseModel
    {
        protected ILifetimeScope _scope;

        public BaseModel()
        {

        }

        public virtual void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
        }
    }
}
