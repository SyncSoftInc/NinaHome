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
            ID = new Guid("00000000-0000-0000-0000-000000000001"),
            Name = "test_testimonial_name",
            Message = "test_message",
            Type = "test_type"
        };

        [Test, Order(1)]
        public async Task Api_TestimonialMessage_Create()
        {
            var hr = await TestimonialMessageApi.CreateMessageAsync(newCmd).ConfigureAwait(false);
            var rs = await hr.GetResultAsync().ConfigureAwait(false);

            Assert.IsTrue(hr.IsSuccess);
            Assert.IsNotNull(rs);
        }

        [Test, Order(10)]
        public async Task Api_TestimonialMessage_Approve()
        {
            var updateCmd = newCmd;
            updateCmd.Approved = true;

            var hr = await TestimonialMessageApi.ApproveMessageAsync(updateCmd).ConfigureAwait(false);
            var rs = await hr.GetResultAsync().ConfigureAwait(false);

            Assert.IsTrue(hr.IsSuccess);
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
            var hr = await TestimonialMessageApi.GetMessagesAsync(new { Name = newCmd.Name }).ConfigureAwait(false);
            var rs = await hr.GetResultAsync().ConfigureAwait(false);

            Assert.IsTrue(hr.IsSuccess);
            Assert.IsTrue(rs.Items.Count > 0);
        }

        [Test, Order(10000)]
        public async Task Api_TestimonialMessage_Delete()
        {
            var hr = await TestimonialMessageApi.DeleteMessageAsync(newCmd.ID).ConfigureAwait(false);
            var rs = await hr.GetResultAsync().ConfigureAwait(false);

            Assert.IsTrue(hr.IsSuccess);
            Assert.IsNotNull(rs);
        }
    }
}