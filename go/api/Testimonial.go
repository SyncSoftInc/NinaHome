package api

import (
	"github.com/SyncSoftInc/NinaHome/go/dto"
	"github.com/syncfuture/go/u"
	"github.com/syncfuture/host"
)

func AddTestimonialActions(host host.IWebHost) {
	host.POST("/api/testimonial/message", createTestimonialMessageAsync)
	host.DELETE("/api/testimonial/message/{id}", deleteTestimonialMessageAsync)
	host.GET("/api/testimonial/message/{id}", getTestimonialMessageAsync)
	host.GET("/api/testimonial/messages", getTestimonialMessagesAsync)
}

func createTestimonialMessageAsync(ctx host.IHttpContext) {
	in := new(dto.TestimonialMessageDTO)
	ctx.ReadJSON(in)

	err := _testimonialMessageDAL.InsertMessage(in)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(u.StrToBytes(err.Error()))
}

func deleteTestimonialMessageAsync(ctx host.IHttpContext) {
	id := ctx.GetParamString("id")
	err := _testimonialMessageDAL.DeleteMessage(id)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(u.StrToBytes(err.Error()))
}

func getTestimonialMessageAsync(ctx host.IHttpContext) {
	id := ctx.GetParamString("id")
	r, err := _testimonialMessageDAL.GetMessage(id)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(getJsonResult(ctx, r))
}

func getTestimonialMessagesAsync(ctx host.IHttpContext) {
	in := new(dto.TestimonialMessageQuery)
	ctx.ReadJSON(in)

	r, err := _testimonialMessageDAL.GetMessages(in)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(getJsonResult(ctx, r))
}
