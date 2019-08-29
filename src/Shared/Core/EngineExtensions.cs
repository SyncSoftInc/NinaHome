using Nina.Api.ContactMessage;
using Nina.Api.TestimonialMessage;
using Nina.Components;
using Nina.DataAccess;
using Nina.DataAccess.ContactMessage;
using Nina.DataAccess.TestimonialMessage;
using SyncSoft.App.Components;
using SyncSoft.App.EngineConfigs;

namespace SyncSoft.App
{
    public static class EngineExtensions
    {
        public static CommonConfigurator UseHomeComponents(this CommonConfigurator configurator)
        {
            Engine.PreventDuplicateRegistration(nameof(UseHomeComponents));

            if (!Engine.IsStarted)
            {
                configurator.Engine.Starting += (o, e) =>
                {
                    ObjectContainer.Register<IContactMessageApi, ContactMessageApi>(LifeCycleEnum.Singleton);
                    ObjectContainer.Register<IContactMessageDAL, ContactMessageDAL>(LifeCycleEnum.Singleton);

                    ObjectContainer.Register<ITestimonialMessageApi, TestimonialMessageApi>(LifeCycleEnum.Singleton);
                    ObjectContainer.Register<ITestimonialMessageDAL, TestimonialMessageDAL>(LifeCycleEnum.Singleton);

                    ObjectContainer.Register<IClassScheduleMessageApi, ClassScheduleMessageApi>(LifeCycleEnum.Singleton);
                    ObjectContainer.Register<IClassScheduleMessageDAL, ClassScheduleMessageDAL>(LifeCycleEnum.Singleton);

                    ObjectContainer.Register<IEmailSender, EmailSender>(LifeCycleEnum.Singleton);
                };
            }

            return configurator;
        }
    }
}
