package api

import (
	"fmt"

	"github.com/SyncSoftInc/NinaHome/go/dto"
	"github.com/syncfuture/go/u"
	"github.com/syncfuture/host"
)

func AddContactActions(host host.IWebHost) {
	host.POST("/api/contact/message", createContactMessageAsync)
	host.DELETE("/api/contact/message/{id}", deleteContactMessageAsync)
	host.GET("/api/contact/message/{id}", getContactMessageAsync)
	host.GET("/api/contact/messages", getContactMessagesAsync)
}

func createContactMessageAsync(ctx host.IHttpContext) {
	in := new(dto.ContactMessageDTO)
	ctx.ReadJSON(in)

	err := _contactMessageDAL.InsertMessage(in)
	if host.HandleErr(err, ctx) {
		return
	}

	// send email
	subject := fmt.Sprintf("Subject: [mylightangel.com]: Contact message from %s\n", in.Email)
	mime := "MIME-version: 1.0;\nContent-Type: text/html; charset=\"UTF-8\";\n\n"
	body := fmt.Sprintf("<p>Name: %s</p><p>Phone: %s</p><p>Email: %s</p><p>Message: %s</p>", in.Name, in.Phone, in.Email, in.Message)
	err = _emailSender.Send(subject, mime, body)

	ctx.Write(u.StrToBytes(err.Error()))
}

func deleteContactMessageAsync(ctx host.IHttpContext) {
	id := ctx.GetParamString("id")
	err := _contactMessageDAL.DeleteMessage(id)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(u.StrToBytes(err.Error()))
}

func getContactMessageAsync(ctx host.IHttpContext) {
	id := ctx.GetParamString("id")
	r, err := _contactMessageDAL.GetMessage(id)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(getJsonResult(ctx, r))
}

func getContactMessagesAsync(ctx host.IHttpContext) {
	in := new(dto.ContactMessageQuery)
	ctx.ReadJSON(in)

	r, err := _contactMessageDAL.GetMessages(in)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(getJsonResult(ctx, r))
}
