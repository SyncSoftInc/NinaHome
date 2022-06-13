package api

import (
	"encoding/json"

	"github.com/SyncSoftInc/NinaHome/go/dal"
	"github.com/SyncSoftInc/NinaHome/go/libs"
	"github.com/syncfuture/host"
)

var (
	_classScheduleMessageDAL = dal.CreateClassScheduleMessageDAL()
	_contactMessageDAL       = dal.CreateContactMessageDAL()
	_testimonialMessageDAL   = dal.CreateTestimonialMessageDAL()
	_emailSender             = libs.NewEmailSender()
)

// type MessageResult struct {
// 	MsgCode string
// }

func getJsonResult(ctx host.IHttpContext, in interface{}) []byte {
	json, err := json.Marshal(in)
	if host.HandleErr(err, ctx) {
		return nil
	}
	return json
}
