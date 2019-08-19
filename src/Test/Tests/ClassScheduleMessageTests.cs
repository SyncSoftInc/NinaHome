using Nina.Api.ContactMessage;
using Nina.DTO;
using NUnit.Framework;
using SyncSoft.App.Components;
using System;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class ClassScheduleMessageTests
    {
        private static readonly Lazy<IClassScheduleMessageApi> _lazyClassScheduleMessageApi = ObjectContainer.LazyResolve<IClassScheduleMessageApi>();
        private IClassScheduleMessageApi ClassScheduleMessageApi => _lazyClassScheduleMessageApi.Value;

        internal static ClassScheduleMessageDTO newCmd = new ClassScheduleMessageDTO
        {
            ID = new Guid("00000000-0000-0000-0000-000000000001"),
            Name = "test_ClassSchedule_name",
            Voice = "test_voice",
            Email = "test_email@sync.co",
            Class = "test_class",
            Message = "test_message",
        };

        [Test, Order(1)]
        public async Task Api_ClassScheduleMessage_Create()
        {
            var hr = await ClassScheduleMessageApi.CreateMessageAsync(newCmd).ConfigureAwait(false);
            var rs = await hr.GetResultAsync().ConfigureAwait(false);

            Assert.IsTrue(rs.IsSuccess());
            Assert.IsNotNull(rs);
        }

        [Test, Order(10)]
        public async Task Api_ClassScheduleMessage_Get()
        {
            var hr = await ClassScheduleMessageApi.GetMessageAsync(newCmd.ID).ConfigureAwait(false);
            var rs = await hr.GetResultAsync().ConfigureAwait(false);

            Assert.IsTrue(hr.IsSuccess);
            Assert.IsNotNull(rs);
        }

        [Test, Order(100)]
        public async Task Api_ClassScheduleMessage_GetPaged()
        {
            var hr = await ClassScheduleMessageApi.GetMessagesAsync(new { Name = newCmd.Name }).ConfigureAwait(false);
            var rs = await hr.GetResultAsync().ConfigureAwait(false);

            Assert.IsTrue(hr.IsSuccess);
            Assert.IsTrue(rs.Items.Count > 0);
        }

        [Test, Order(1000)]
        public async Task Api_ClassScheduleMessage_Delete()
        {
            var hr = await ClassScheduleMessageApi.DeleteMessageAsync(newCmd.ID).ConfigureAwait(false);
            var rs = await hr.GetResultAsync().ConfigureAwait(false);

            Assert.IsTrue(rs.IsSuccess());
            Assert.IsNotNull(rs);
        }
    }
}