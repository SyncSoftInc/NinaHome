package api

import (
	"fmt"

	"github.com/SyncSoftInc/NinaHome/go/core"
	"github.com/SyncSoftInc/NinaHome/go/dto"
	"github.com/syncfuture/go/u"
	"github.com/syncfuture/host"
)

// var ClassActionGroup = host.NewActionGroup(
// 	nil,
// 	[]*host.Action{
// 		host.NewAction("POST/api/class/message", "api_Class_", createMessage),
// 		host.NewAction("DELETE/api/class/message/{id}", "api_Class_", deleteMessage),
// 		host.NewAction("GET/api/class/message/{id}", "api_Class_", getMessage),
// 		host.NewAction("GET/api/class/messages", "api_Class_", getMessages),
// 	},
// 	nil,
// )

func AddClassActions() {
	core.Host.POST("/api/class/message", createClassMessage)
	core.Host.DELETE("/api/class/message/{id}", deleteClassMessage)
	core.Host.GET("/api/class/message/{id}", getClassMessage)
	core.Host.GET("/api/class/messages", getClassMessages)
}

func createClassMessage(ctx host.IHttpContext) {
	in := new(dto.ClassScheduleMessageDTO)
	ctx.ReadJSON(in)

	err := _classScheduleMessageDAL.InsertMessage(in)
	if host.HandleErr(err, ctx) {
		return
	}

	// send email
	subject := fmt.Sprintf("Subject: [mylightangel.com]: Class Schedule message from %s\n", in.Email)
	mime := "MIME-version: 1.0;\nContent-Type: text/html; charset=\"UTF-8\";\n\n"
	body := fmt.Sprintf("<p>Name: %s</p><p>Phone: %s</p><p>Email: %s</p><p>Message: %s</p>", in.Name, in.Phone, in.Email, in.Message)
	err = _emailSender.Send(subject, mime, body)

	ctx.Write(u.StrToBytes(err.Error()))
}

func deleteClassMessage(ctx host.IHttpContext) {
	id := ctx.GetParamString("id")
	err := _classScheduleMessageDAL.DeleteMessage(id)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(u.StrToBytes(err.Error()))
}

func getClassMessage(ctx host.IHttpContext) {
	id := ctx.GetParamString("id")
	r, err := _classScheduleMessageDAL.GetMessage(id)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(getJsonResult(ctx, r))
}

func getClassMessages(ctx host.IHttpContext) {
	in := new(dto.ClassScheduleMessageQuery)
	ctx.ReadJSON(in)

	r, err := _classScheduleMessageDAL.GetMessages(in)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(getJsonResult(ctx, r))
}
