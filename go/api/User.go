package api

import (
	"strconv"

	"github.com/SyncSoftInc/NinaHome/go/core"
	"github.com/syncfuture/armos/go/user/protoc/user"
	"github.com/syncfuture/go/u"
	"github.com/syncfuture/host"
)

func AddUserActions() {
	core.Host.GET("/api/user/authentication", isUserAuthenticated)
}

func isUserAuthenticated(ctx host.IHttpContext) {
	var users []*user.UserDTO
	err := core.ConfigProvider.GetStruct("Users", &users)
	if host.HandleErr(err, ctx) {
		return
	}

	// get cookie username
	username := ctx.GetEncryptedCookieString(core.COOKIE_KEY)
	if u.IsMissing(username) {
		return
	}

	// check username
	isAuthenticated := false
	for _, u := range users {
		if u.Username == username {
			isAuthenticated = true
		}
	}

	ctx.Write(u.StrToBytes(strconv.FormatBool(isAuthenticated)))
}
