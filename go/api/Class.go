package api

import (
	"fmt"

	"github.com/SyncSoftInc/NinaHome/go/dto"
	"github.com/syncfuture/go/u"
	"github.com/syncfuture/host"
)

// var ClassActionGroup = host.NewActionGroup(
// 	nil,
// 	[]*host.Action{
// 		host.NewAction("POST/api/class/message", "api_Class_", createMessageAsync),
// 		host.NewAction("DELETE/api/class/message/{id}", "api_Class_", deleteMessageAsync),
// 		host.NewAction("GET/api/class/message/{id}", "api_Class_", getMessageAsync),
// 		host.NewAction("GET/api/class/messages", "api_Class_", getMessagesAsync),
// 	},
// 	nil,
// )

func AddClassActions(host host.IWebHost) {
	host.POST("/api/class/message", createClassMessageAsync)
	host.DELETE("/api/class/message/{id}", deleteClassMessageAsync)
	host.GET("/api/class/message/{id}", getClassMessageAsync)
	host.GET("/api/class/messages", getClassMessagesAsync)
}

func createClassMessageAsync(ctx host.IHttpContext) {
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

func deleteClassMessageAsync(ctx host.IHttpContext) {
	id := ctx.GetParamString("id")
	err := _classScheduleMessageDAL.DeleteMessage(id)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(u.StrToBytes(err.Error()))
}

func getClassMessageAsync(ctx host.IHttpContext) {
	id := ctx.GetParamString("id")
	r, err := _classScheduleMessageDAL.GetMessage(id)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(getJsonResult(ctx, r))
}

func getClassMessagesAsync(ctx host.IHttpContext) {
	in := new(dto.ClassScheduleMessageQuery)
	ctx.ReadJSON(in)

	r, err := _classScheduleMessageDAL.GetMessages(in)
	if host.HandleErr(err, ctx) {
		return
	}

	ctx.Write(getJsonResult(ctx, r))
}
