package api

import (
	"fmt"
	"time"

	"github.com/SyncSoftInc/NinaHome/go/core"
	"github.com/SyncSoftInc/NinaHome/go/dto"
	"github.com/google/uuid"
	"github.com/syncfuture/host"
)

func AddContactActions() {
	core.Host.POST("/api/contact/message", createContactMessage)
	core.Host.DELETE("/api/contact/message/{id}", deleteContactMessage)
	core.Host.GET("/api/contact/message/{id}", getContactMessage)
	core.Host.GET("/api/contact/messages", getContactMessages)
}

func createContactMessage(ctx host.IHttpContext) {
	in := new(dto.ContactMessageDTO)
	ctx.ReadJSON(in)

	in.ID = uuid.New()
	in.CreatedOnUtc = time.Now().UTC()
	err := _contactMessageDAL.InsertMessage(in)
	if host.HandleErr(err, ctx) {
		return
	}

	// send email
	subject := fmt.Sprintf("Subject: [mylightangel.com]: Contact message from %s\n", in.Email)
	mime := "MIME-version: 1.0;\nContent-Type: text/html; charset=\"UTF-8\";\n\n"
	body := fmt.Sprintf("<p>Name: %s</p><p>Phone: %s</p><p>Email: %s</p><p>Message: %s</p>", in.Name, in.Phone, in.Email, in.Message)
	err = _emailSender.Send(subject, mime, body)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(nil)
}

func deleteContactMessage(ctx host.IHttpContext) {
	id := ctx.GetParamString("id")
	err := _contactMessageDAL.DeleteMessage(id)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(nil)
}

func getContactMessage(ctx host.IHttpContext) {
	id := ctx.GetParamString("id")
	r, err := _contactMessageDAL.GetMessage(id)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(getJsonResult(ctx, r))
}

func getContactMessages(ctx host.IHttpContext) {
	in := new(dto.ContactMessageQuery)
	ctx.ReadJSON(in)

	r, err := _contactMessageDAL.GetMessages(in)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(getJsonResult(ctx, r))
}
