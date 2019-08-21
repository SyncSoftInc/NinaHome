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
            Name = "test_ClassSchedule_name",
            Phone = "111-222-3333",
            Email = "test_email@sync.co",
            Type = "test_class_type",
            Message = "test_message",
        };

        [Test]
        public async Task Api_ContactMessage_BatchCreate()
        {
            for (int i = 1; i < 100; i++)
            {
                var cmd = new ClassScheduleMessageDTO
                {
                    Name = "test_ClassSchedule_name",
                    Phone = "111-222-3333",
                    Email = $"test_email_{i}@sync.co",
                    Type = "test_class_type",
                    Message = "test_message",
                };
                var hr = await ClassScheduleMessageApi.CreateMessageAsync(cmd).ConfigureAwait(false);
                var rs = await hr.GetResultAsync().ConfigureAwait(false);

                Assert.IsTrue(rs.IsSuccess());
                Assert.IsNotNull(rs);
            }
        }

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
            var hr = await ClassScheduleMessageApi.GetMessagesAsync(newCmd.Name).ConfigureAwait(false);
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