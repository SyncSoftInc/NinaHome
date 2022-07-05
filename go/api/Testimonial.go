package api

import (
	"time"

	"github.com/SyncSoftInc/NinaHome/go/core"
	"github.com/SyncSoftInc/NinaHome/go/dto"
	"github.com/google/uuid"
	"github.com/syncfuture/host"
)

func AddTestimonialActions() {
	core.Host.POST("/api/testimonial/message", createTestimonialMessage)
	core.Host.PATCH("/api/testimonial/message", approveTestimonialMessage)
	core.Host.DELETE("/api/testimonial/message/{id}", deleteTestimonialMessage)
	core.Host.GET("/api/testimonial/message/{id}", getTestimonialMessage)
	core.Host.GET("/api/testimonial/messages", getTestimonialMessages)
}

func createTestimonialMessage(ctx host.IHttpContext) {
	in := new(dto.TestimonialMessageDTO)
	ctx.ReadJSON(in)

	in.ID = uuid.New()
	in.CreatedOnUtc = time.Now().UTC()
	err := _testimonialMessageDAL.InsertMessage(in)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(nil)
}

func approveTestimonialMessage(ctx host.IHttpContext) {
	in := new(dto.TestimonialMessageDTO)
	ctx.ReadJSON(in)

	err := _testimonialMessageDAL.ApproveMessage(in.ID.String(), in.Approved)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(nil)
}

func deleteTestimonialMessage(ctx host.IHttpContext) {
	id := ctx.GetParamString("id")
	err := _testimonialMessageDAL.DeleteMessage(id)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(nil)
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
