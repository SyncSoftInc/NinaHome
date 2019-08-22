using Nina.Api.TestimonialMessage;
using Nina.DTO;
using NUnit.Framework;
using SyncSoft.App.Components;
using System;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class TestimonialMessageTests
    {
        private static readonly Lazy<ITestimonialMessageApi> _lazyTestimonialMessageApi = ObjectContainer.LazyResolve<ITestimonialMessageApi>();
        private ITestimonialMessageApi TestimonialMessageApi => _lazyTestimonialMessageApi.Value;

        internal static TestimonialMessageDTO newCmd = new TestimonialMessageDTO
        {
            Name = "test_testimonial_name",
            Message = "test_message",
            Type = "test_type"
        };

        [Test]
        public async Task Api_TestimonialMessage_BatchCreate()
        {
            for (int i = 1; i < 100; i++)
            {
                var cmd = new TestimonialMessageDTO
                {
                    Name = "batchTest_testimonial_name",
                    Message = $"test_message_{i}",
                    Type = $"test_type_{i}"
                };
                var hr = await TestimonialMessageApi.CreateMessageAsync(cmd).ConfigureAwait(false);
                var rs = await hr.GetResultAsync().ConfigureAwait(false);

                Assert.IsTrue(rs.IsSuccess());
                Assert.IsNotNull(rs);
            }
        }

        [Test, Order(1)]
        public async Task Api_TestimonialMessage_Create()
        {
            var hr = await TestimonialMessageApi.CreateMessageAsync(newCmd).ConfigureAwait(false);
            var rs = await hr.GetResultAsync().ConfigureAwait(false);

            Assert.IsTrue(rs.IsSuccess());
            Assert.IsNotNull(rs);
        }

        [Test, Order(10)]
        public async Task Api_TestimonialMessage_Approve()
        {
            var updateCmd = newCmd;
            updateCmd.Approved = true;

            var hr = await TestimonialMessageApi.ApproveMessageAsync(updateCmd).ConfigureAwait(false);
            var rs = await hr.GetResultAsync().ConfigureAwait(false);

            Assert.IsTrue(rs.IsSuccess());
            Assert.IsNotNull(rs);
        }

        [Test, Order(100)]
        public async Task Api_TestimonialMessage_Get()
        {
            var hr = await TestimonialMessageApi.GetMessageAsync(newCmd.ID).ConfigureAwait(false);
            var rs = await hr.GetResultAsync().ConfigureAwait(false);

            Assert.IsTrue(hr.IsSuccess);
            Assert.IsNotNull(rs);
        }

        [Test, Order(1000)]
        public async Task Api_TestimonialMessage_GetPaged()
        {
            var hr = await TestimonialMessageApi.GetMessagesAsync("test_testimonial_name", null, 10, 1).ConfigureAwait(false);
            var rs = await hr.GetResultAsync().ConfigureAwait(false);

            Assert.IsTrue(hr.IsSuccess);
            Assert.IsTrue(rs.Items.Count > 0);
        }

        [Test, Order(10000)]
        public async Task Api_TestimonialMessage_Delete()
        {
            var hr = await TestimonialMessageApi.DeleteMessageAsync(newCmd.ID).ConfigureAwait(false);
            var rs = await hr.GetResultAsync().ConfigureAwait(false);

            Assert.IsTrue(rs.IsSuccess());
            Assert.IsNotNull(rs);
        }
    }
}