package api

import (
	"github.com/SyncSoftInc/NinaHome/go/core"
	"github.com/syncfuture/host"
)

func AddUserActions() {
	core.Host.GET("/api/user/authentication", isUserAuthenticated)
}

func isUserAuthenticated(ctx host.IHttpContext) {
	// get current user
	// user, ok := ctx.Value("user").(map[string]interface{})
	// if ok {
	// 	in.User_ID, ok = user["sub"].(string)
	// }

	// if host.HandleErr(err, ctx) {
	// 	return
	// }

	// ctx.Write(getJsonResult(ctx, r))
}
