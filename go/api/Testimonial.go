package api

import (
	"github.com/SyncSoftInc/NinaHome/go/core"
	"github.com/SyncSoftInc/NinaHome/go/dto"
	"github.com/syncfuture/go/u"
	"github.com/syncfuture/host"
)

func AddTestimonialActions() {
	core.Host.POST("/api/testimonial/message", createTestimonialMessage)
	core.Host.DELETE("/api/testimonial/message/{id}", deleteTestimonialMessage)
	core.Host.GET("/api/testimonial/message/{id}", getTestimonialMessage)
	core.Host.GET("/api/testimonial/messages", getTestimonialMessages)
}

func createTestimonialMessage(ctx host.IHttpContext) {
	in := new(dto.TestimonialMessageDTO)
	ctx.ReadJSON(in)

	err := _testimonialMessageDAL.InsertMessage(in)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(u.StrToBytes(err.Error()))
}

func deleteTestimonialMessage(ctx host.IHttpContext) {
	id := ctx.GetParamString("id")
	err := _testimonialMessageDAL.DeleteMessage(id)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(u.StrToBytes(err.Error()))
}

func getTestimonialMessage(ctx host.IHttpContext) {
	id := ctx.GetParamString("id")
	r, err := _testimonialMessageDAL.GetMessage(id)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(getJsonResult(ctx, r))
}

func getTestimonialMessages(ctx host.IHttpContext) {
	in := new(dto.TestimonialMessageQuery)
	ctx.ReadJSON(in)

	r, err := _testimonialMessageDAL.GetMessages(in)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(getJsonResult(ctx, r))
}
