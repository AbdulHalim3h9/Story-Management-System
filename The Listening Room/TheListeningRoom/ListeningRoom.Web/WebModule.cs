using Autofac;
using ListeningRoom.Web.Areas.Admin.Models;

namespace ListeningRoom.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<>().as<> ().
            //    instance

            builder.RegisterType<AddStoryModel>().AsSelf();
            builder.RegisterType<StoryListModel>().AsSelf();
            builder.RegisterType<EditStoryModel>().AsSelf();
            base.Load(builder);
        }
    }
}
